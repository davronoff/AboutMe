using Microsoft.AspNetCore.Mvc;

namespace AboutMe.View.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }    
}
