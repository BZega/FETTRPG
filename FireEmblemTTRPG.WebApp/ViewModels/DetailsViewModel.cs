namespace FireEmblemTTRPG.WebApp.ViewModels
{
    public class DetailsViewModel
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public int Experience { get; set; }
        public List<ClassViewModel> Classes { get; set; }
        public List<string> Weapon { get; set; }

    }

    public class ClassViewModel
    {
        public string Name { get; set; }
        public int HPBase { get; set; }
    }
}
