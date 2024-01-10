using Microsoft.AspNetCore.Mvc;
using RestSharp;
using WebApi.ApplicationConfig;

[ApiController]
[Route("[controller]")]
public class CurrenciesController : ControllerBase
{
    private readonly RestClient _restClient;

    public CurrenciesController()
    {
        _restClient = new RestClient();
    }

    [HttpGet("exchange")]
    public IActionResult GetExchangeRate(string baseCurrency = "USD", string targetCurrency = "EUR")
    {
        var client = new RestClient($"{Config.BaseUrl}/exchange?int=10&to={targetCurrency}&base={baseCurrency}");
        var request = new RestRequest();
        request.AddHeader("authorization", $"apikey {Config.APIKEY}");
        request.AddHeader("content-type", "application/json");
        
        RestResponse response = client.Execute(request);

        if (response.IsSuccessful)
        {
            return Ok(response.Content);
        }
        else
        {
            return StatusCode(500, "Döviz kuru verileri alınamadı.");
        }
    }

    [HttpGet]
    public IActionResult GetLatestExchangeRates(string baseCurrency = "USD")
    {
        var client = new RestClient($"{Config.BaseUrl}/economy/currencyToAll");
        var request = new RestRequest();
        request.AddHeader("authorization", $"apikey {Config.APIKEY}");
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
            return StatusCode(500, "Döviz kuru verileri alınamadı.");
        }
    }

    [HttpGet("allCurrency")]
    public IActionResult GetAllCurrencies()
    {
        var client = new RestClient($"{Config.BaseUrl}/economy/allCurrency");
        var request = new RestRequest();
        request.AddHeader("authorization", $"apikey {Config.APIKEY}");
        request.AddHeader("content-type", "application/json");
        
        RestResponse response = client.Execute(request);

        if (response.IsSuccessful)
        {
            return Ok(response.Content);
        }
        else
        {
            return StatusCode(500, "Döviz kuru verileri alınamadı.");
        }
    }
}
