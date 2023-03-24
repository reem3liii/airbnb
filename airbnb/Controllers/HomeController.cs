using Microsoft.AspNetCore.Mvc;

namespace airbnb.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult AirbnbYourHome()
        {
            return View();
        }
        public IActionResult AirCover()
        {
            return View();
        }

    }
}