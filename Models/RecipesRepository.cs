using Dapper;
using System.Data;

namespace ReloadingDB.Models
{
    public class RecipesRepository : IRecipesRepository
    {
        private readonly IDbConnection _conn;

        public RecipesRepository(IDbConnection conn)
        {
            _conn = conn;
        }
        public IEnumerable<Recipes> GetAllRecipes()
        {
            return _conn.Query<Recipes>("SELECT * FROM RECIPES;");
        }
        public IEnumerable<Recipes> Get7mmRemMagRecipes()
        {
            return _conn.Query<Recipes>("SELECT * FROM RECIPES WHERE Caliber = '7mm Rem Mag';");
        }
        public IEnumerable<Recipes> Get308WinRecipes()
        {
            return _conn.Query<Recipes>("SELECT * FROM RECIPES WHERE Caliber = '308 Winchester';");
        }
        public IEnumerable<Recipes> GetMyLoads()
        {
            return _conn.Query<Recipes>("SELECT * FROM RECIPES WHERE MyLoad = True;");
        }
        public Recipes GetRecipes(int id)
        {
            return _conn.QuerySingle<Recipes>("SELECT * FROM RECIPES WHERE ID = @id", new { id = id });
        }
        public void UpdateRecipes(Recipes recipes)
        {
            _conn.Execute("UPDATE recipes SET Mfg = @mfg, Caliber = @caliber, BulletType = @bulletType, BulletWeight = @weight, Powder = @powder, MinCharge = @minCharge, MaxCharge = @maxCharge, VelocityAtMax = @velocity WHERE ID = @id",
             new { mfg = recipes.Mfg, caliber = recipes.Caliber, bulletType = recipes.BulletType, weight = recipes.BulletWeight, powder = recipes.Powder, minCharge = recipes.MinCharge, maxCharge = recipes.MaxCharge, velocity = recipes.VelocityAtMax, id = recipes.ID });
        }
        public void InsertRecipes(Recipes recipesToInsert)
        {
            _conn.Execute("INSERT INTO recipes (MyLoad, Mfg, Copper, Caliber, Primer, BarrelLength, TwistRate, COAL, BulletType, BulletWeight, BC, Powder, MinCharge, MaxCharge, VelocityAtMax) VALUES (@myLoad, @mfg, @copper, @caliber, @primer, @barrelLength, @twistRate, @coal, @bulletType, @weight, @bc, @powder, @minCharge, @maxCharge, @velocity);",
             new { myLoad = recipesToInsert.MyLoad, mfg = recipesToInsert.Mfg, copper = recipesToInsert.Copper, caliber = recipesToInsert.Caliber, primer = recipesToInsert.Primer, barrelLength = recipesToInsert.BarrelLength, twistRate = recipesToInsert.TwistRate, coal = recipesToInsert.COAL, bulletType = recipesToInsert.BulletType, weight = recipesToInsert.BulletWeight, bc = recipesToInsert.BC, powder = recipesToInsert.Powder, minCharge = recipesToInsert.MinCharge, maxCharge = recipesToInsert.MaxCharge, velocity = recipesToInsert.VelocityAtMax });
        }
        public void DeleteRecipes(Recipes recipes)
        {
            _conn.Execute("DELETE FROM recipes WHERE ID = @id;", new { id = recipes.ID });
        }
    }
}
