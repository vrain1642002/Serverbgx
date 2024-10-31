using System;
using System.Collections.Generic;

namespace Serverbgx.Models
{
    public partial class Ve
    {
        public int Ma { get; set; }
        public DateTime? Ngaykh { get; set; }
        public DateTime? Ngaygh { get; set; }
        public DateTime? Ngayhh { get; set; }
        public byte? Trangthai { get; set; }
        public int? MaHoadon { get; set; }
        public string? BiensoXe { get; set; }
        public int? MaLoaive { get; set; }

        public virtual Xe? BiensoXeNavigation { get; set; }
        public virtual Hoadon? MaHoadonNavigation { get; set; }
        public virtual Loaive? MaLoaiveNavigation { get; set; }
    }
}
