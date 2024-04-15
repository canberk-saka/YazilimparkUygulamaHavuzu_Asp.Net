using Microsoft.AspNetCore.Mvc;

namespace UygulamaHavuzu.Web.Controllers
{
    public class WeatherController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
