using System;
using System.Collections.Generic;

namespace Serverbgx.Models
{
    public partial class Vaitro
    {
        public Vaitro()
        {
            Nguoidungs = new HashSet<Nguoidung>();
        }

        public int Ma { get; set; }
        public string Ten { get; set; } = null!;

        public virtual ICollection<Nguoidung> Nguoidungs { get; set; }
    }
}
