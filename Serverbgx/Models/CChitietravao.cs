using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serverbgx.Models
{
    internal class CChitietravao
    {
        public CChitietravao ()
        {
            hinh =new List<CHinhravao> ();
        }

        public int Ma { get; set; }
        public DateTime? Ngayvao { get; set; }
        public DateTime? Giovao { get; set; }
        public DateTime? Ngayra { get; set; }
        public DateTime? Giora { get; set; }
        public string? BiensoXe { get; set; }
        public int? MaHoadon { get; set; }

        public List<CHinhravao> hinh { get; set; }


     
     

        public static Chitietravao chuyendoi(CChitietravao x)
        {
            if (x == null) return null;
            return new Chitietravao
            {
             
                Ngayvao = x.Ngayvao,
                Ngayra = x.Ngayra,
                BiensoXe = x.BiensoXe,
                MaHoadon = x.MaHoadon,
            };
        }
    }
}
