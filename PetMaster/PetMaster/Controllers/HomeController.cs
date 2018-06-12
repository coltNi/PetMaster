using Microsoft.AspNetCore.Mvc;

namespace PetMaster.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

    }
}
