using Microsoft.AspNetCore.Mvc;
using ReloadingDB.Models;

namespace ReloadingDB.Controllers
{
    public class RecipesController : Controller
    {
        private readonly IRecipesRepository repo;

        public RecipesController(IRecipesRepository repo)
        {
            this.repo = repo;
        }
        public IActionResult Index()
        {
            var recipes = repo.GetAllRecipes();
            return View(recipes);
        }
        public IActionResult All7mmRemMagRecipes()
        {
            var recipes = repo.Get7mmRemMagRecipes();
            return View(recipes);
        }
        public IActionResult All308WinRecipes()
        {
            var recipes = repo.Get308WinRecipes();
            return View(recipes);
        }
        public IActionResult AllMyLoads()
        {
            var recipes = repo.GetMyLoads();
            return View(recipes);
        }
        public IActionResult ViewRecipes(int id)
        {
            var recipes = repo.GetRecipes(id);
            return View(recipes);
        }
        public IActionResult UpdateRecipes(int id)
        {
            Recipes recip = repo.GetRecipes(id);
            if (recip == null)
            {
                return View("RecipeNotFound");
            }
            return View(recip);
        }
        public IActionResult UpdateRecipesToDatabase(Recipes recipes)
        {
            repo.UpdateRecipes(recipes);

            return RedirectToAction("ViewRecipes", new { id = recipes.ID });
        }
        public IActionResult InsertRecipes(Recipes recipesToInsert)
        {
            return View(recipesToInsert);
        }
        public IActionResult InsertRecipesToDatabase(Recipes recipesToInsert)
        {
            repo.InsertRecipes(recipesToInsert);

            return RedirectToAction("Index");
        }
        public IActionResult DeleteRecipes(Recipes recipes)
        {
            repo.DeleteRecipes(recipes);
            return RedirectToAction("Index");
        }
        public IActionResult RunBallistics(int id)
        {
            Recipes recip = repo.GetRecipes(id);
            if (recip == null)
            {
                return View("RecipeNotFound");
            }
            return View(recip);
        }        
        public IActionResult ShowBallistics(Recipes recipes)
        {
            repo.RunBallistics(recipes);
            
            return View("ShowBallistics", recipes);
        }
    }
}
