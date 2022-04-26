using System;
using System.Net.Http;


namespace ConsoleAppTeste
{
  class Program
  {
    static readonly HttpClient _client = new HttpClient();
    static async Task Main(string[] args)
    {
      try
      {
        HttpResponseMessage response = await _client.GetAsync("https://api.nobelprize.org/v1/prize.json?category=");
      }
      catch (HttpRequestException e)
      {
        Console.WriteLine("\nException Caught");
        Console.WriteLine("Message: {0}", e.Message);
      }
    }
  }
}