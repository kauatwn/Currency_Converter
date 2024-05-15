using CurrencyConverter.DTOs;

namespace CurrencyConverter.Services
{
    internal interface ICurrencyConversionApiService
    {
        Task<CurrencyConversionResponseDTO?> ConvertCurrencyAsync(string baseCode, string targetCode, decimal amount);
    }
}
