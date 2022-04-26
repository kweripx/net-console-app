using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;


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
        var category = Console.ReadLine();
        Console.WriteLine("Insert a year: ");
        var year = Console.ReadLine();

        HttpResponseMessage response = await _client.GetAsync($"https://api.nobelprize.org/v1/prize.json?category={category}&year={year}");
        var content = await response.Content.ReadAsStringAsync();
        // foreach (var item in nobel)
        // {
        //   Console.WriteLine(item.Category);
        // }
        var prizes = JsonConvert.DeserializeObject(content);
        Console.WriteLine(prizes);
      }
      catch (HttpRequestException e)
      {
        Console.WriteLine("\nException Caught");
        Console.WriteLine("Message: {0}", e.Message);
      }
    }
  }
}