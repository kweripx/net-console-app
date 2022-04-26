using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using nobelPrizes;
namespace ConsoleAppTeste
{
  class Program
  {
    static readonly HttpClient _client = new HttpClient();
    static async Task Main(string[] args)
    {
      try
      {
        Console.WriteLine("Insert a category: ");
        var category = Console.ReadLine().ToLower();
        Console.WriteLine("Insert a year: ");
        var year = Console.ReadLine();

        HttpResponseMessage response = await _client.GetAsync($"https://api.nobelprize.org/v1/prize.json?category={category}&year={year}");
        var content = await response.Content.ReadAsStringAsync();

        var nobelPrize = JsonConvert.DeserializeObject<RootPrize>(content);

        foreach (var item in nobelPrize.Prizes)
        {
          foreach (var i in nobelPrize.Prizes)
          {
            Console.WriteLine($"\n{item.Category}\n");
            Console.WriteLine($"{item.Year}\n");
            Console.WriteLine($"{i.Laureates}\n");
          }
        }
      }
      catch (HttpRequestException e)
      {
        Console.WriteLine("\nException Caught");
        Console.WriteLine("Message: {0}", e.Message);
      }
    }
  }
}