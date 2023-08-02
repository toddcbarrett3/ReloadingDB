namespace ReloadingDB.Models
{
    public interface IRecipesRepository
    {
        public IEnumerable<Recipes> GetAllRecipes();
        public Recipes GetRecipes(int id);
        public void UpdateRecipes(Recipes recipes);
        public void InsertRecipes(Recipes recipesToInsert);
        public void DeleteRecipes(Recipes recipes);
    }
}
