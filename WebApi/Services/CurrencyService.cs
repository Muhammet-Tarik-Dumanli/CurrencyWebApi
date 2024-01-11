using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using WebApi.ApplicationConfig;

namespace WebApi.Services;

public class CurrencyService : ICurrencyService
{
    public object GetAllCurrencies()
    {
        var client = new RestClient($"{Config.BaseUrl}/allCurrency");
        var request = new RestRequest();
        request.AddHeader("authorization", $"apikey {Config.APIKEY}");
        request.AddHeader("content-type", "application/json");

        RestResponse response = client.Execute(request);

        if (response.IsSuccessful)
        {
            var parsedJson = JsonConvert.DeserializeObject(response.Content);
            var deserializedObject = JsonConvert.SerializeObject(parsedJson, Formatting.Indented);
            return deserializedObject;
        }
        else
        {
            return null;
        }
    }

    public object GetExchangeRate(string baseCurrency = "USD", string targetCurrency = "EUR")
    {
        var client = new RestClient($"{Config.BaseUrl}/exchange?int=10&to={targetCurrency}&base={baseCurrency}");
        var request = new RestRequest();
        request.AddHeader("authorization", $"apikey {Config.APIKEY}");
        request.AddHeader("content-type", "application/json");

        RestResponse response = client.Execute(request);

        if (response.IsSuccessful)
        {
            var parsedJson = JsonConvert.DeserializeObject(response.Content);
            var deserializedObject = JsonConvert.SerializeObject(parsedJson, Formatting.Indented);
            return deserializedObject;
        }
        else
        {
            return null;
        }
    }

    public object GetLatestExchangeRates(string baseCurrency = "USD")
    {
        var client = new RestClient($"{Config.BaseUrl}/currencyToAll");
        var request = new RestRequest();
        request.AddHeader("authorization", $"apikey {Config.APIKEY}");
        request.AddHeader("content-type", "application/json");
        request.AddParameter("int", "10");
        request.AddParameter("base", baseCurrency);

        RestResponse response = client.Execute(request);

        if (response.IsSuccessful)
        {
            var parsedJson = JsonConvert.DeserializeObject(response.Content);
            var deserializedObject = JsonConvert.SerializeObject(parsedJson, Formatting.Indented);
            return deserializedObject;
        }
        else
        {
            return null;
        }
    }

    public object GetSingleCurrency(decimal amount = 10, string baseCurrency = "USD")
    {
        var client = new RestClient($"{Config.BaseUrl}/singleCurrency?int={amount}&tag={baseCurrency}");
        var request = new RestRequest();
        request.AddHeader("authorization", $"apikey {Config.APIKEY}");
        request.AddHeader("content-type", "application/json");

        RestResponse response = client.Execute(request);

        if (response.IsSuccessful)
        {
            var parsedJson = JsonConvert.DeserializeObject(response.Content);
            var deserializedObject = JsonConvert.SerializeObject(parsedJson, Formatting.Indented);
            return deserializedObject;
        }
        else
        {
            return null;
        }
    }
}