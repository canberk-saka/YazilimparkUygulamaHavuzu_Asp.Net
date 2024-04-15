using Microsoft.AspNetCore.Mvc;
using UygulamaHavuzu.Web.Models;

public class RandomQuotesController : Controller
{
    private readonly HttpClient httpClient;
    int randomIndex = 0;

    public RandomQuotesController()
    {
        httpClient = new HttpClient();
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> RastgeleSoz()
    {
        List<string> ozluSozler = await GetRandomSozler();

        randomIndex = new Random().Next(ozluSozler.Count);
        return Json(ozluSozler[randomIndex].ToString());
    }

    public async Task<IActionResult> SozYazari()
    {


        List<string> sozSahibi = await GetSozYazari();
        randomIndex = new Random().Next(sozSahibi.Count);


        return Json(sozSahibi[randomIndex].ToString());
    }

    private async Task<List<string>> GetRandomSozler()
    {
        List<string> ozluSozler = new List<string>();

        try
        {
            string apiUrl = "https://type.fit/api/quotes";

            HttpResponseMessage response = await httpClient.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                ozluSozler = Newtonsoft.Json.JsonConvert.DeserializeObject<List<RandomQuotesModel>>(content).Select(s => s.text).ToList();
            }
            else
            {

            }
        }
        catch (Exception ex)
        {

        }

        return ozluSozler;
    }

    private async Task<List<string>> GetSozYazari()
    {
        List<string> sozYazari = new List<string>();

        try
        {
            string apiUrl = "https://type.fit/api/quotes";

            HttpResponseMessage response = await httpClient.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                sozYazari = Newtonsoft.Json.JsonConvert.DeserializeObject<List<RandomQuotesModel>>(content).Select(s => s.author).ToList();
            }
            else
            {

            }
        }
        catch (Exception ex)
        {

        }

        return sozYazari;
    }

}
