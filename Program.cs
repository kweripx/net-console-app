using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Threading;
using nobelPrizes;
namespace ConsoleAppTeste
{
  class Program
  {
    static readonly HttpClient _client = new HttpClient();


    static async Task GetData(string category, string year)
    {
      HttpResponseMessage response = await _client.GetAsync($"https://api.nobelprize.org/v1/prize.json?category={category}&year={year}");
      var content = await response.Content.ReadAsStringAsync();
      var nobelPrize = JsonConvert.DeserializeObject<RootPrize>(content);

      foreach (var item in nobelPrize.Prizes)
      {
        Console.WriteLine($"\nCategory: {item.Category}\n");
        Console.WriteLine($"Year: {item.Year}\n");
        foreach (var laureate in item.Laureates)
        {
          Console.WriteLine($"ID: {laureate.Id}\n");
          Console.WriteLine($"Firstname: {laureate.Firstname}\n");
          Console.WriteLine($"Surname: {laureate.Surname}\n");
          Console.WriteLine($"Motivation: {laureate.Motivation}\n");
          Console.WriteLine($"Share: {laureate.Share}\n");
        }
      }
      string log = content.ToString();
      await File.WriteAllTextAsync("log.txt", log);
      Thread.Sleep(TimeSpan.FromSeconds(15));
    }
    static async Task Main()
    {
      string[] request = System.IO.File.ReadAllLines(@"request.txt");
      //Display the file contents
      System.Console.WriteLine("Contents of request.txt = ");
      foreach (string line in request)
      {
        // Split the request content to become a request parameter.
        var splitData = line.Split(';');
        var category = splitData[0];
        var year = splitData[1];
        Console.WriteLine("\t" + line);
        await GetData(category, year);
      }


      Console.WriteLine("Press any key to exit.");
      System.Console.ReadKey();
      Thread.Sleep(TimeSpan.FromSeconds(5));
    }

  }
}