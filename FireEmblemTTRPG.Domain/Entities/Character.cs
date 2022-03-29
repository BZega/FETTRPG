namespace FireEmblemTTRPG.Domain.Entities
{
    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public int Experience { get; set; }
        public Stat StatGrowth { get; set; }
        public GrowthRate GrowthRate { get; set; }
        public List<Weapon> Weapons { get; set; } = new List<Weapon>();
        public List<Class> Classes { get; set; } = new List<Class>();
    }
}