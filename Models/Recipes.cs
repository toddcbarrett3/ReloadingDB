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
        public int BulletWeight { get; set; }
        public double BC { get; set; }
        public string? Powder { get; set; }
        public string? MinCharge { get; set; }
        public string? MaxCharge { get; set; }
        public int VelocityAtMax { get; set; }

        //Ballistics Properties
        public int BallisticsVelocity { get; set; }
        public int BallisticsBulletWeight { get; set; }
        public double BallisticsBC { get; set; }
        public int Altitude { get; set; } = 0;
        public int Temperature { get; set; } = 60;
        public double ScopeHeight { get; set; } = 1.50;
        public int ZeroRange { get; set; } = 200;


        public void RunBallistics(Recipes recipes)
        {
            var sendValues = new GoogleSheetsUpdate();
            
            var velList = new List<object>() { recipes.BallisticsVelocity };
            var bwList = new List<object>() { recipes.BallisticsBulletWeight };
            var bcList = new List<object>() { recipes.BallisticsBC };
            var srList = new List<object>() { 0 };
            var riList = new List<object>() { 50 };
            var altList = new List<object>() { recipes.Altitude };
            var tempList = new List<object>() { recipes.Temperature };
            var shList = new List<object>() { recipes.ScopeHeight };
            var zrList = new List<object>() { recipes.ZeroRange };

            var updateList = new List<IList<object>> { velList, bwList, bcList, srList, riList, altList, tempList, shList, zrList };

            sendValues.Init();
            sendValues.UpdateCells(updateList);
        }
    }
}
