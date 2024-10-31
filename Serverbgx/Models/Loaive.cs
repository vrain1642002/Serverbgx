using System;
using System.Collections.Generic;

namespace Serverbgx.Models
{
    public partial class Loaive
    {
        public Loaive()
        {
            Ves = new HashSet<Ve>();
        }

        public int Ma { get; set; }
        public string? Tenloaive { get; set; }
        public int? Giave { get; set; }
        public string? Loaixe { get; set; }
        public DateTime? Ngaytao { get; set; }
        public DateTime? Ngaysua { get; set; }
        public byte? Trangthai { get; set; }

        public virtual ICollection<Ve> Ves { get; set; }
    }
}
