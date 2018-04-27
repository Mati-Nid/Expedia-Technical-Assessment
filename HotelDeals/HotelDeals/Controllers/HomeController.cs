using Microsoft.AspNetCore.Mvc;

namespace HotelDeals.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}