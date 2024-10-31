using Serverbgx.Models;
using System;
using System.ComponentModel.Design;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

//fix
class Program
{
    public static csdl_baigiuxeContext db = new csdl_baigiuxeContext();

    static async Task Main(string[] args)
    {
        IPAddress ipAddress = IPAddress.Parse("192.168.1.2");
        int port = 8031;

        TcpListener listener = new TcpListener(ipAddress, port);
        listener.Start();

        Console.WriteLine($"Listening for TCP connections at {ipAddress}:{port}...");

        while (true)
        {
            TcpClient client = await listener.AcceptTcpClientAsync();
            Console.WriteLine($"Connection accepted from {((IPEndPoint)client.Client.RemoteEndPoint).Address}:{((IPEndPoint)client.Client.RemoteEndPoint).Port}.");

            _ = Task.Run(async () =>
            {
                using (NetworkStream stream = client.GetStream())
                using (StreamReader reader = new StreamReader(stream))
                {
                    while (true)
                    {
                        string receivedData = await reader.ReadLineAsync();
                        if (receivedData == null)
                            break;

                        await ProcessReceivedDataAsync(receivedData);
                    }
                }

                client.Close();
            });
        }
    }

    static async Task ProcessReceivedDataAsync(string receivedData)

    {
        //Neu chanel name=API dua vao de xac dinh

        //Console.WriteLine(receivedData);
        string snapIdPrefix = "SnapId\":\"";
        int snapIdStartIndex = receivedData.IndexOf(snapIdPrefix);
        if (snapIdStartIndex != -1)
        {
            snapIdStartIndex += snapIdPrefix.Length;
            int snapIdEndIndex = receivedData.IndexOf("\"", snapIdStartIndex);
            if (snapIdEndIndex != -1)
            {
                string snapId = receivedData.Substring(snapIdStartIndex, snapIdEndIndex - snapIdStartIndex);
                Console.WriteLine($"SnapId: {snapId}");

                string endTimePrefix = "EndTime\":";
                int endTimeStartIndex = receivedData.IndexOf(endTimePrefix);
                if (endTimeStartIndex != -1)
                {
                    endTimeStartIndex += endTimePrefix.Length;
                    int endTimeEndIndex = receivedData.IndexOf(",", endTimeStartIndex);
                    if (endTimeEndIndex != -1)
                    {
                        string endTimeString = receivedData.Substring(endTimeStartIndex, endTimeEndIndex - endTimeStartIndex);

                        long endTimeUnixTimestamp = long.Parse(endTimeString);
                        DateTimeOffset utcTime = DateTimeOffset.FromUnixTimeSeconds(endTimeUnixTimestamp);
                        DateTime vietnamTime = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(utcTime.DateTime, "SE Asia Standard Time");

                        Console.WriteLine($"EndTime (Vietnam Time): {vietnamTime.ToString("yyyy-MM-dd_HH-mm-ss")}");

                        string plateImgPrefix = "PlateImg\":\"";
                       


                                var chiTietRaVao = db.Chitietravaos
                                 .Where(ct => ct.BiensoXe == snapId && ct.Ngayra == null)
                                 .ToList();

                        // Kiểm tra có chi tiết nào ra vào rồi mà chưa ra không, phải bằng 0 thì mới lưu
                        if (chiTietRaVao.Count == 0)

                        { // Decode PlateImg
                            int plateImgStartIndex = receivedData.IndexOf(plateImgPrefix);
                            if (plateImgStartIndex != -1)
                            {
                                plateImgStartIndex += plateImgPrefix.Length;
                                int plateImgEndIndex = receivedData.IndexOf("\"", plateImgStartIndex);
                                if (plateImgEndIndex != -1)
                                {
                                    string plateImgBase64 = receivedData.Substring(plateImgStartIndex, plateImgEndIndex - plateImgStartIndex);
                                    Console.WriteLine($"PlateImg: {plateImgBase64}");

                                    // Decode Base64 PlateImg to byte array
                                    byte[] imageBytes = Convert.FromBase64String(plateImgBase64);

                                    // Create file name based on SnapId and EndTime (Vietnam Time)
                                    string fileName = $"{snapId}_{vietnamTime.ToString("yyyy-MM-dd_HH-mm-ss")}.jpg";

                                    // Get directory path of the current project
                                    string currentDirectory = Directory.GetCurrentDirectory();
                                    string directoryPath = @"D:\C#\Thuctap\CameraServerAPI\CameraServerAPI\Images\";

                                    // Create directory if it doesn't exist
                                    if (!Directory.Exists(directoryPath))
                                    {
                                        Directory.CreateDirectory(directoryPath);
                                    }


                                    // Save image to directory
                                    string imagePath = Path.Combine(directoryPath, fileName);
                                    File.WriteAllBytes(imagePath, imageBytes);

                                    Console.WriteLine($"Plate image saved at: {imagePath}");



                                    try
                                    {
                                        CHoadon hd = new CHoadon();
                                        hd.Loai = 1;
                                        db.Hoadons.Add(CHoadon.chuyendoi(hd));
                                        db.SaveChanges();

                                        Console.WriteLine("Lưu thành công!");
                                        var mahd = db.Hoadons.Max(h => h.Ma);
                                        Console.WriteLine("Mã hóa đơn vừa được tạo: " + mahd);
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine("Lỗi khi lưu dữ liệu: " + ex.Message);
                                    }

                                    try
                                    {
                                        CChitietravao ct = new CChitietravao();
                                        ct.Ngayvao = vietnamTime;
                                        ct.MaHoadon = db.Hoadons.Max(h => h.Ma);
                                        ct.BiensoXe = snapId;
                                        db.Chitietravaos.Add(CChitietravao.chuyendoi(ct));
                                        db.SaveChanges();
                                        Console.WriteLine("Lưu thành công!");

                                        Console.WriteLine("Mã chi tiết vừa tạo là: " + db.Chitietravaos.Max(h => h.Ma));
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine("Lỗi khi lưu dữ liệu: " + ex.Message);
                                    }

                                    try
                                    {
                                        CHinhravao h = new CHinhravao();
                                        h.MaChitietravao = db.Chitietravaos.Max(h => h.Ma);
                                        h.Tenhinh = fileName;

                                        db.Hinhravaos.Add(CHinhravao.chuyendoi(h));
                                        db.SaveChanges();

                                        Console.WriteLine("Lưu thành công!");
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine("Lỗi khi lưu dữ liệu: " + ex.Message);
                                    }
                                }





                            }
                            else
                            {
                                Console.WriteLine("Invalid format: PlateImg" );
                            }
                        }
                        //else
                        //{
                        //    Console.WriteLine("PlateImg not found in the received data.");
                        //}
                    }
                    else
                    {
                        Console.WriteLine("Invalid format: EndTime.");
                    }
                }
                else
                {
                    Console.WriteLine("EndTime not found in the received data.");
                }
            }
            else
            {
                Console.WriteLine("Invalid format: SnapId ");
            }
        }
        else
        {
            Console.WriteLine("SnapId not found in the received data.");
        }
    }
}
