using System;

namespace Management_Internet_Cafe.Models
{
  // =========================
  // CLIENTS
  // =========================
  public class Client
  {
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
  }

  // =========================
  // COMPUTERS
  // =========================
  public class Computer
  {
    public int Id { get; set; }
    public string PcNumber { get; set; }
    public string Status { get; set; }
    public string Specifications { get; set; }
  }

  // =========================
  // GAMES
  // =========================
  public class Game
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Genre { get; set; }
  }

  // =========================
  // SESSIONS
  // =========================
  public class Session
  {
    public int Id { get; set; }
    public int ClientId { get; set; }
    public int ComputerId { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime? EndTime { get; set; }

    // Navigation (optional but useful later)
    public Client Client { get; set; }
    public Computer Computer { get; set; }
  }

  // =========================
  // SESSION GAMES
  // =========================
  public class SessionGame
  {
    public int Id { get; set; }
    public int SessionId { get; set; }
    public int GameId { get; set; }

    public Session Session { get; set; }
    public Game Game { get; set; }
  }

  // =========================
  // PAYMENTS
  // =========================
  public class Payment
  {
    public int Id { get; set; }
    public int SessionId { get; set; }
    public decimal Amount { get; set; }
    public string PaymentMethod { get; set; }
    public DateTime PaymentDate { get; set; }

    public Session Session { get; set; }
  }
}