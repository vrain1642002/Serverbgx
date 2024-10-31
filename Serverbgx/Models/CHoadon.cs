using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serverbgx.Models
{
    internal class CHoadon
    {

        public int Ma { get; set; }
        public DateTime? Ngaylap { get; set; }
        public int? Sotien { get; set; }
        public byte? Loai { get; set; }

        public static Hoadon chuyendoi(CHoadon x)
        {
            if (x == null) return null;
            return new Hoadon
            {

                Ngaylap=x.Ngaylap,
                Sotien=x.Sotien,
                Loai=x.Loai,

            };
        }
    }
}
