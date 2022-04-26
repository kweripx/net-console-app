namespace nobelPrizes
{

  public partial class Prize
  {
    public long Year { get; set; }
    public string Category { get; set; }

  }
  public class RootPrize
  {
    public List<Prize> Prizes { get; set; }
  }
}
