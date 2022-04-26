namespace nobelPrizes
{

  public partial class Prize
  {
    public long Year { get; set; }
    public string Category { get; set; }
    public Laureate[] Laureates { get; set; }

  }

  public partial class Laureate
  {
    public long Id { get; set; }
    public string Firstname { get; set; }
    public string Surname { get; set; }
    public string Motivation { get; set; }
    public long Share { get; set; }
  }
  public class RootPrize
  {
    public List<Prize>? Prizes { get; set; }
  }
}
