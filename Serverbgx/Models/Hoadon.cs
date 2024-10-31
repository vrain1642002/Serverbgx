using System;
using System.Collections.Generic;

namespace Serverbgx.Models
{
    public partial class Hoadon
    {
        public Hoadon()
        {
            Chitietravaos = new HashSet<Chitietravao>();
            Ves = new HashSet<Ve>();
        }

        public int Ma { get; set; }
        public DateTime? Ngaylap { get; set; }
        public int? Sotien { get; set; }
        public byte? Loai { get; set; }

        public virtual ICollection<Chitietravao> Chitietravaos { get; set; }
        public virtual ICollection<Ve> Ves { get; set; }
    }
}
