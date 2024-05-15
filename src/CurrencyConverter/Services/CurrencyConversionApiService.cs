using CurrencyConverter.DTOs;
using Newtonsoft.Json;

namespace CurrencyConverter.Services
{
    internal class CurrencyConversionApiService : ICurrencyConversionApiService
    {
        private HttpClient HttpClient { get; }

        public CurrencyConversionApiService()
        {
            HttpClient = new HttpClient
            {
                BaseAddress = new Uri("https://v6.exchangerate-api.com")
            };
        }

        public async Task<CurrencyConversionResponseDTO?> ConvertCurrencyAsync(string baseCode, string targetCode, decimal amount)
        {
            var response = await HttpClient.GetAsync($"v6/ea1dac06c76d73e87ffd46f9/pair/{baseCode}/{targetCode}/{amount}");

            string content = await response.Content.ReadAsStringAsync();

            CurrencyConversionResponseDTO? convertedCurrency = JsonConvert.DeserializeObject<CurrencyConversionResponseDTO>(content);

            return convertedCurrency;
        }
    }
}
