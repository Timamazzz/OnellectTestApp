using Microsoft.Extensions.Options;
using OnellectRandomizer.Domain;
using OnellectRandomizer.Domain.Confiuration;
using System.Text.Json;

//Подключение конфига
var options = Options.Create(JsonSerializer.Deserialize<Configuration>(File.OpenRead("appsettings.json"))!);

//Бизнес логика генерации и сортировки
RandomizerService randomizerService = new RandomizerService(
   new SortingService(), options);


var result = await randomizerService.Generate();

Console.WriteLine($"Оригинальная последовательность чисел: {string.Join(", ", result.OriginalSequence)}");
Console.WriteLine($"Отсортированная последовательность чисел: { string.Join(", ", result.SortedSequence)}");
Console.WriteLine($"Кол-во сгенерированных символов в последовательности: {result.OriginalSequence.Count()}");

//Имитация отправки на сервер
/*ApiClient apiClient = new ApiClient(options);
await apiClient.SendData(result);*/