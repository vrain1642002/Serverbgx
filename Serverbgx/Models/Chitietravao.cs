using System;
using System.Collections.Generic;

namespace Serverbgx.Models
{
    public partial class Chitietravao
    {
        public Chitietravao()
        {
            Hinhravaos = new HashSet<Hinhravao>();
        }

        public int Ma { get; set; }
        public DateTime? Ngayvao { get; set; }
        public DateTime? Ngayra { get; set; }
        public string? BiensoXe { get; set; }
        public int? MaHoadon { get; set; }

        public virtual Hoadon? MaHoadonNavigation { get; set; }
        public virtual ICollection<Hinhravao> Hinhravaos { get; set; }
    }
}
