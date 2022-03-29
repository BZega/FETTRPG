using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireEmblemTTRPG.Domain.Entities
{
    public class GrowthRate
    {
        public int HPGrowthRate { get; set; }
        public int StrGrowthRate { get; set; }
        public int MagGrowthRate { get; set; }
        public int SklGrowthRate { get; set; }
        public int SpdGrowthRate { get; set; }
        public int LckGrowthRate { get; set; }
        public int DefGrowthRate { get; set; }
        public int ResGrowthRate { get; set; }
    }
}
