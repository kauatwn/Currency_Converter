using CurrencyConverter.DTOs;

namespace CurrencyConverter.Services
{
    internal interface ICurrencyConversionApiService
    {
        Task<CurrencyConversionResponseDTO> ConvertCurrency(string baseCode, string targetCode, decimal amount);
    }
}
