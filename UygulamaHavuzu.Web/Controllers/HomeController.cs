using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using UygulamaHavuzu.Web.Models;

namespace UygulamaHavuzu.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var appCardModel = new List<AppModel>
            {
                new AppModel{Id = 1, Name = "ToDo App",Description="Yapılacaklar Listesi Uygulaması",PhotoSource="/images/todo.png"},
                new AppModel{Id = 2, Name = "Random Quotes",Description="Rastgele Özlü Söz Uygulaması",PhotoSource="/images/ozlu_soz.png"},
                new AppModel{Id = 3, Name = "Weather App",Description="Hava Durumu Uygulaması",PhotoSource="/images/weather.png"},
                new AppModel{Id = 4, Name = "BMI Calculator",Description="Vücut Kitle Endeksi Uygulaması", PhotoSource = "/images/bmi.png"}

            };



            return View(appCardModel);
        }

        
    }
}