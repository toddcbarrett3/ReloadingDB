namespace ReloadingDB.Models
{
    public interface IRecipesRepository
    {
        public IEnumerable<Recipes> GetAllRecipes();
        public IEnumerable<Recipes> Get7mmRemMagRecipes();
        public IEnumerable<Recipes> Get308WinRecipes();
        public IEnumerable<Recipes> GetMyLoads();
        public Recipes GetRecipes(int id);
        public void UpdateRecipes(Recipes recipes);
        public void InsertRecipes(Recipes recipesToInsert);
        public void DeleteRecipes(Recipes recipes);

    }
}
