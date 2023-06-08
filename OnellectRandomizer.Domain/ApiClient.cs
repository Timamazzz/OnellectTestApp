using Microsoft.Extensions.Options;
using OnellectRandomizer.Domain.Confiuration;
using OnellectRandomizer.Domain.Interfaces;
using OnellectRandomizer.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace OnellectRandomizer.Domain;

public class ApiClient : IApiClient
{
    private readonly IOptions<Configuration> configuration;

    public ApiClient(IOptions<Configuration> configuration)
    {
        this.configuration = configuration;
    }

    public async Task SendData(RandomizeResult data)
    {
        using (HttpClient client = new HttpClient())
        {
            // Преобразование данных в формат JSON (предполагается, что сервер ожидает JSON)
            string jsonData = JsonSerializer.Serialize(data);

            // Отправка данных на сервер
            var response = await client.PostAsync(configuration.Value.ApiUrl, new StringContent(jsonData));

            // Обработка ответа сервера
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Данные успешно отправлены на сервер.");
            }
            else
            {
                Console.WriteLine("Ошибка при отправке данных на сервер.");
            }
        }
    }
}
