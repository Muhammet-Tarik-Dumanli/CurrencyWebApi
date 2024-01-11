using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using WebApi.ApplicationConfig;
using WebApi.Services;

[ApiController]
[Route("[controller]")]
public class CurrenciesController : ControllerBase
{
    private readonly RestClient _restClient;
    private readonly ICurrencyService _currencyService;
    public CurrenciesController(ICurrencyService currencyService)
    {
        _restClient = new RestClient();
        _currencyService = currencyService;
    }

    [HttpGet("exchange")]
    public IActionResult GetExchangeRate(string baseCurrency = "USD", string targetCurrency = "TRY")
    {
        var result = _currencyService.GetExchangeRate(baseCurrency, targetCurrency);

        if (result != null)
        {
            return Ok(result);
        }
        else
        {
            return StatusCode(500, "Döviz kuru verileri alınamadı.");
        }
    }

    [HttpGet]
    public IActionResult GetLatestExchangeRates(string baseCurrency = "USD")
    {
        var result = _currencyService.GetLatestExchangeRates(baseCurrency);

        if (result != null)
        {
            return Ok(result);
        }
        else
        {
            return StatusCode(500, "Döviz kuru verileri alınamadı.");
        }
    }

    [HttpGet("allCurrency")]
    public IActionResult GetAllCurrencies()
    {
        var result = _currencyService.GetLatestExchangeRates();

        if (result != null)
        {
            return Ok(result);
        }
        else
        {
            return StatusCode(500, "Döviz kuru verileri alınamadı.");
        }
    }

    [HttpGet("singleCurrency")]
    public IActionResult GetSingleCurrency(string baseCurrency = "USD")
    {
        var result = _currencyService.GetLatestExchangeRates(baseCurrency);

        if (result != null)
        {
            return Ok(result);
        }
        else
        {
            return StatusCode(500, "Döviz kuru verileri alınamadı.");
        }
    }

}
