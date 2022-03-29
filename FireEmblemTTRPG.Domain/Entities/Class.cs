using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FireEmblemTTRPG.Domain.Enums;

namespace FireEmblemTTRPG.Domain.Entities
{
    public class Class
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MaxLevel { get; set; }
        public Stat BaseStat { get; set; }
        public Stat MaxStat { get; set; }
        public GrowthRate GrowthRate { get; set; }
        public WeaponType WeaponType { get; set; }
        public WeaponType WeaponType2 { get; set; }
        public WeaponType WeaponType3 { get; set; }
        public List<Character> Characters { get; set; } = new List<Character>();

    }
}
