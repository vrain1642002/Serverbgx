using System;
using System.Collections.Generic;

namespace Serverbgx.Models
{
    public partial class Hinhravao
    {
        public int Ma { get; set; }
        public string? Tenhinh { get; set; }
        public int? MaChitietravao { get; set; }

        public virtual Chitietravao? MaChitietravaoNavigation { get; set; }
    }
}
