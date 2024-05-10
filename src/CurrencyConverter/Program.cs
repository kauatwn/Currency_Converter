using CurrencyConverter.DTOs;
using CurrencyConverter.Services;
using System.Globalization;

var culture = new CultureInfo("en-US");
CultureInfo.DefaultThreadCurrentCulture = culture;
CultureInfo.DefaultThreadCurrentUICulture = culture;

ICurrencyConversionApiService service = new CurrencyConversionApiService();

Console.WriteLine("Seja bem-vindo ao conversor de moedas!\n");

Console.WriteLine("Escolha uma opção abaixo para fazer a conversão:\n");

Console.WriteLine("[1] Real brasileiro (BRL) -> Dólar americano (USD)");
Console.WriteLine("[2] Real brasileiro (BRL) -> Euro (EUR)");
Console.WriteLine("[3] Real brasileiro (BRL) -> Libra esterlina (GBP)");
Console.WriteLine("[4] Libra esterlina (GBP) -> Dólar americano (USD)");
Console.WriteLine("[5] Libra esterlina (GBP) -> Euro (EUR)");
Console.WriteLine("[6] Dólar americano (USD) -> Euro (EUR)\n");

int option;
while (!int.TryParse(Console.ReadLine(), out option) || option < 1 || option > 6)
{
    Console.Write("Opção inválida! Digite uma opção válida: ");
}

Console.WriteLine();

Console.Write("Digite o valor que deseja converter: ");

decimal amount;
while (!decimal.TryParse(Console.ReadLine(), out amount) || amount <= 0)
{
    Console.Write("Valor inválido! Digite um valor válido que deseja converter: ");
}

Console.WriteLine();

await PrintCurrencyConvertedAsync(service, option, amount);

static async Task PrintCurrencyConvertedAsync(ICurrencyConversionApiService service, int option, decimal amount)
{
    CurrencyConversionResponseDTO? response = null;

    switch (option)
    {
        case 1:
            response = await service.ConvertCurrencyAsync("BRL", "USD", amount);
            break;

        case 2:
            response = await service.ConvertCurrencyAsync("BRL", "EUR", amount);
            break;

        case 3:
            response = await service.ConvertCurrencyAsync("BRL", "GBP", amount);
            break;

        case 4:
            response = await service.ConvertCurrencyAsync("GBP", "USD", amount);
            break;

        case 5:
            response = await service.ConvertCurrencyAsync("GBP", "EUR", amount);
            break;

        case 6:
            response = await service.ConvertCurrencyAsync("USD", "EUR", amount);
            break;

        default:
            Console.WriteLine("Opção inválida!");
            break;
    }

    if (response != null)
    {
        Console.WriteLine($"Conversão de {response.BaseCode} {amount} para {response.TargetCode} {response.ConversionResult}.");
    } else
    {
        Console.WriteLine("Falha ao converter moeda.");
    }
}
