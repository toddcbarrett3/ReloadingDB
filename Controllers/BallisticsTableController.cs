using Microsoft.AspNetCore.Mvc;

namespace ReloadingDB.Controllers
{
    public class BallisticsTableController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
