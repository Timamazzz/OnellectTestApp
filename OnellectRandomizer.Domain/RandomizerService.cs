using Microsoft.Extensions.Options;
using OnellectRandomizer.Domain.Confiuration;
using OnellectRandomizer.Domain.Interfaces;
using OnellectRandomizer.Domain.Models;
using System.Text.Json;

namespace OnellectRandomizer.Domain;

public class RandomizerService : IRandomizerService
{
    private readonly ISortingService sortingService;
    private readonly IOptions<Configuration> configuration;

    public RandomizerService(
        ISortingService sortigService,
        IOptions<Configuration> configuration)
    {
        this.sortingService = sortigService;
        this.configuration = configuration;
    }

    public async Task<RandomizeResult> Generate()
    {
        // Генерация случайного количества чисел от 20 до 100, диапазон берется из конфиг файла
        Random random = new Random();
        int count = random.Next(configuration.Value.MinSize, configuration.Value.MaxSize);

        // Генерация случайных чисел в диапазоне от -100 до 100, , диапазон берется из конфиг файла
        List<int> numbers = new List<int>();
        for (int i = 0; i < count; i++)
        {
            numbers.Add(random.Next(configuration.Value.MinValue, configuration.Value.MaxValue));
        }

        // Сортировка последовательности
        var sortedNumbers = new List<int>(numbers);
        sortingService.Sort(sortedNumbers);

        return new RandomizeResult
        {
            OriginalSequence = numbers,
            SortedSequence = sortedNumbers
        };
    }

}