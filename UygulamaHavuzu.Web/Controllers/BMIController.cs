using Microsoft.AspNetCore.Mvc;
using UygulamaHavuzu.Web.Models;

namespace UygulamaHavuzu.Web.Controllers
{
    public class BMIController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Hesapla(VucutKitleEndeksModel model)
        {
            if (ModelState.IsValid)
            {
                model.VKE = HesaplaVKE(model.Boy, model.Kilo);
                return Json(model.VKE);
            }
            return BadRequest();
        }

        private double HesaplaVKE(double boy, double kilo)
        {
            return (kilo / (boy * boy) * 10000);
        }
    }
}
