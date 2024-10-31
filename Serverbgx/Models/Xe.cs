using System;
using System.Collections.Generic;

namespace Serverbgx.Models
{
    public partial class Xe
    {
        public Xe()
        {
            Ves = new HashSet<Ve>();
        }

        public string Bienso { get; set; } = null!;
        public string? Tenhinh { get; set; }
        public int? MaKhachhang { get; set; }

        public virtual Khachhang? MaKhachhangNavigation { get; set; }
        public virtual ICollection<Ve> Ves { get; set; }
    }
}
