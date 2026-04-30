namespace Management_Internet_Cafe.Models
{
  public class SessionGame
  {
    public int Id { get; set; }
    public int SessionId { get; set; }
    public int GameId { get; set; }

    public Session Session { get; set; }
    public Game Game { get; set; }
  }
}