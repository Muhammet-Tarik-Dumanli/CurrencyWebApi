using Microsoft.AspNetCore.Mvc;
using RestSharp;

[ApiController]
[Route("[controller]")]
public class CurrenciesController : ControllerBase
{
    private readonly RestClient _restClient;

    public CurrenciesController()
    {
        _restClient = new RestClient();
    }
    [HttpGet]
    public IActionResult GetLatestExchangeRates(string baseCurrency = "USD")
    {
        var client = new RestClient("https://api.collectapi.com/economy/currencyToAll");
        var request = new RestRequest();
        request.AddHeader("authorization", "apikey 3hRPpifkKwiSm7hwI2vODH:5PmwOCIoBlPrntlXrYfUot");
        request.AddHeader("content-type", "application/json");
        request.AddParameter("int", "10");
        request.AddParameter("base", baseCurrency);

        RestResponse response = client.Execute(request);

        if (response.IsSuccessful)
        {
            return Ok(response.Content); // Alınan veriyi JSON olarak döndür
        }
        else
        {
            // Hata durumlarını uygun şekilde işleyin
            return StatusCode(500, "Döviz kuru verileri alınamadı.");
        }
    }
}
