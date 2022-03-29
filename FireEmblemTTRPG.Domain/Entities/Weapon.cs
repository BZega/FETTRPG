using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FireEmblemTTRPG.Domain.Enums;

namespace FireEmblemTTRPG.Domain.Entities
{
    public class Weapon
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public WeaponType WeaponType { get; set; }
        public string Might { get; set; }
        public string Hit { get; set; }
        public string Crit { get; set; }
        public string Range { get; set; }
        public string? Extra { get; set; }
        public List<Character> Characters { get; set; } = new List<Character>();
    }
}
