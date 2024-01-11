namespace WebApi.Services;

public interface ICurrencyService
{
    public object GetExchangeRate(string baseCurrency = "USD", string targetCurrency = "EUR");
    public object GetLatestExchangeRates(string baseCurrency = "USD");
    public object GetAllCurrencies();
    public object GetSingleCurrency(decimal amount, string baseCurrency = "USD");

}