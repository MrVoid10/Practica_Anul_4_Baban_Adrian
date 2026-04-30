using System;

namespace Management_Internet_Cafe.Models
{
  public class Session
  {
    public int Id { get; set; }
    public int ClientId { get; set; }
    public int ComputerId { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime? EndTime { get; set; }

    public Client Client { get; set; }
    public Computer Computer { get; set; }
  }
}