using System.Globalization;
using System.Net.Http.Json;
using MeatOrderSystem.Service.Interfaces;

namespace MeatOrderSystem.Service.Services;

public class CurrencyConverterService : ICurrencyConverterService
{
    private readonly HttpClient _httpClient;

    public CurrencyConverterService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<decimal> ConvertToBRLAsync(string currencyCode, decimal amount)
    {
        if (currencyCode == "BRL") return amount;

        var url = $"https://economia.awesomeapi.com.br/json/last/{currencyCode}-BRL";

        try
        {
            var response = await _httpClient.GetFromJsonAsync<Dictionary<string, CurrencyResponse>>(url);
            if (response is not null && response.TryGetValue($"{currencyCode}BRL", out var rate))
            {
                var bid = decimal.Parse(rate.bid, CultureInfo.InvariantCulture);
                return amount * bid;
            }
        }
        catch { }

        return 0m;
    }

    private class CurrencyResponse
    {
        public string bid { get; set; } = "0";
    }
}
