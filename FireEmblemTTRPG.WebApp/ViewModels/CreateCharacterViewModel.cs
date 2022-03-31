using FireEmblemTTRPG.Domain.Entities;

namespace FireEmblemTTRPG.WebApp.ViewModels
{
    public class CreateCharacterViewModel
    {

        public string Name { get; set; }
        public int Level { get; set; }
        public int Experience { get; set; }
        public int StatGrowthHP { get; set; }
        public int StatGrowthStr { get; set; }
        public int StatGrowthMag { get; set; }
        public int StatGrowthSkl { get; set; }
        public int StatGrowthSpd { get; set; }
        public int StatGrowthLck { get; set; }
        public int StatGrowthDef { get; set; }
        public int StatGrowthRes { get; set; }
        public int StatGrowthMov { get; set; }
        public int GrowthHP { get; set; }
        public int GrowthStr { get; set; }
        public int GrowthMag { get; set; }
        public int GrowthSkl { get; set; }
        public int GrowthSpd { get; set; }
        public int GrowthLck { get; set; }
        public int GrowthDef { get; set; }
        public int GrowthRes { get; set; }
        public List<ClassCheckSelect> ClassNames { get; set; }
        public List<WeaponCheckSelect> WeaponNames { get; set; }
        public List<int> SelectedClasses { get; set; }
        public List<int> SelectedWeapons { get; set; }

    }
}

public class ClassCheckSelect
{
    public int ClassId { get; set; }
    public string Name { get; set; }
    public bool isSelected { get; set; }
}

public class WeaponCheckSelect
{
    public int WeaponId { get; set; }
    public string Name { get; set; }
    public bool isSelected { get; set; }
}
