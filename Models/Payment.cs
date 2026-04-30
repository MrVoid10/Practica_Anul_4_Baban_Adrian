using System;

namespace Management_Internet_Cafe.Models
{
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