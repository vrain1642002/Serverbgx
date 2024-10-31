using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serverbgx.Models
{
    internal class CHinhravao
    {
        public int Ma { get; set; }
        public string? Tenhinh { get; set; }
        public int? MaChitietravao { get; set; }

        public static Hinhravao chuyendoi(CHinhravao x)
        {
            if (x == null) return null;
            return new Hinhravao
            {
             
               Tenhinh = x.Tenhinh,
               MaChitietravao=x.MaChitietravao,
            };
        }


    }
}
