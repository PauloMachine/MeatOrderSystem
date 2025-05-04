namespace MeatOrderSystem.Service.Interfaces;

public interface ICurrencyConverterService
{
    Task<decimal> ConvertToBRLAsync(string currencyCode, decimal amount);
}
