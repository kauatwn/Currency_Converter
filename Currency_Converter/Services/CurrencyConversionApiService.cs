using Currency_Converter.DTOs;
using Newtonsoft.Json;

namespace Currency_Converter.Services
{
    internal class CurrencyConversionApiService
    {
        private HttpClient HttpClient { get; }

        public CurrencyConversionApiService()
        {
            HttpClient = new HttpClient
            {
                BaseAddress = new Uri("https://v6.exchangerate-api.com")
            };
        }

        public async Task<CurrencyConversionResponseDTO> ConvertCurrency(string baseCode, string targetCode, decimal amount)
        {
            var response = await HttpClient.GetAsync($"v6/ea1dac06c76d73e87ffd46f9/pair/{baseCode}/{targetCode}/{amount}");

            string content = await response.Content.ReadAsStringAsync();

            var currencyConverted = JsonConvert.DeserializeObject<CurrencyConversionResponseDTO>(content);

            return currencyConverted;
        }
    }
}
