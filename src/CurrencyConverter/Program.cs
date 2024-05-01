using CurrencyConverter.DTOs;
using CurrencyConverter.Services;

var service = new CurrencyConversionApiService();

Console.WriteLine("Seja bem-vindo ao conversor de moedas!\n");

Console.WriteLine("Escolha uma opção abaixo para fazer a conversão:\n");

Console.WriteLine("[1] Real brasileiro (BRL) -> Dólar americano (USD)");
Console.WriteLine("[2] Real brasileiro (BRL) -> Euro (EUR)");
Console.WriteLine("[3] Real brasileiro (BRL) -> Libra esterlina (GBP)");
Console.WriteLine("[4] Libra esterlina (GBP) -> Dólar americano (USD)");
Console.WriteLine("[5] Libra esterlina (GBP) -> Euro (EUR)");
Console.WriteLine("[6] Dólar americano (USD) -> Euro (EUR)\n");

int option = int.Parse(Console.ReadLine());
Console.WriteLine();

Console.Write("Digite o valor inteiro que deseja converter (sem centavos): ");

long amount = long.Parse(Console.ReadLine());

switch (option)
{
    case 1:
        CurrencyConversionResponseDTO response1 = await service.ConvertCurrency("BRL", "USD", amount);
        Console.WriteLine($"Conversão de {amount} BRL para {response1.ConversionResult} USD.");
        break;

    case 2:
        CurrencyConversionResponseDTO response2 = await service.ConvertCurrency("BRL", "EUR", amount);
        Console.WriteLine($"Conversão de {amount} BRL para {response2.ConversionResult} EUR.");
        break;
    case 3:
        CurrencyConversionResponseDTO response3 = await service.ConvertCurrency("BRL", "GBP", amount);
        Console.WriteLine($"Conversão de {amount} BRL para {response3.ConversionResult} GBP.");
        break;

    case 4:
        CurrencyConversionResponseDTO response4 = await service.ConvertCurrency("GBP", "USD", amount);
        Console.WriteLine($"Conversão de {amount} GBP para {response4.ConversionResult} USD.");
        break;

    case 5:
        CurrencyConversionResponseDTO response5 = await service.ConvertCurrency("GBP", "EUR", amount);
        Console.WriteLine($"Conversão de {amount} GBP para {response5.ConversionResult} EUR.");
        break;

    case 6:
        CurrencyConversionResponseDTO response6 = await service.ConvertCurrency("USD", "EUR", amount);
        Console.WriteLine($"Conversão de {amount} USD para {response6.ConversionResult} EUR.");
        break;

    default:
        Console.WriteLine("Opção inválida!");
        break;
}
