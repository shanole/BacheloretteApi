using System.Collections.Generic;

namespace BacheloretteApi.Models
{
  public class Bachelorette
  {
    public int BacheloretteId {get; set;}
    public string Name {get; set;}
    public int Age {get; set;}
    public string Job {get; set;}
    public string Hometown {get; set;}
    public int Season {get; set;} 
  }
}