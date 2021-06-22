namespace BacheloretteApi.Models
{
  public class Contestant
  {
    public int ContestantId {get; set;}
    public string Name {get; set;}
    public int Age {get; set;}
    public string Job {get; set;}
    public string Hometown {get; set;}
    public bool IsEliminated {get; set;} = false;
    public int Season {get; set;}
    public int BacheloretteId {get; set;}
  }
}