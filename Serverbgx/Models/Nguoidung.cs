using System;
using System.Collections.Generic;

namespace Serverbgx.Models
{
    public partial class Nguoidung
    {
        public int Ma { get; set; }
        public string? Hoten { get; set; }
        public string Taikhoan { get; set; } = null!;
        public string Matkhau { get; set; } = null!;
        public DateTime? Ngaytao { get; set; }
        public DateTime? Ngaysua { get; set; }
        public byte? Trangthai { get; set; }
        public int? MaVaitro { get; set; }

        public virtual Vaitro? MaVaitroNavigation { get; set; }
    }
}
