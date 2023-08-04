namespace ReloadingDB.Models
{
    public class Recipes
    {
        public Recipes() 
        {
        }

        public int ID { get; set; }
        public bool MyLoad { get; set; }
        public string? Mfg { get; set; }
        public bool Copper { get; set; }
        public string? Caliber { get; set; }
        public string? Primer { get; set; }
        public string? BarrelLength { get; set; }
        public string? TwistRate { get; set; }
        public string? COAL { get; set; }
        public string? BulletType { get; set; }
        public int BulletWeight { get; set;}
        public double BC { get; set; }
        public string? Powder { get; set; }
        public string? MinCharge { get; set; }
        public string? MaxCharge { get; set; }
        public int VelocityAtMax { get; set; }
    }
}
