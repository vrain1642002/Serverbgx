using System;
using System.Collections.Generic;

namespace Serverbgx.Models
{
    public partial class Khachhang
    {
        public Khachhang()
        {
            Xes = new HashSet<Xe>();
        }

        public int Ma { get; set; }
        public string? Hoten { get; set; }
        public string? Sdt { get; set; }
        public string? Tenhinh { get; set; }

        public virtual ICollection<Xe> Xes { get; set; }
    }
}
