using Microsoft.EntityFrameworkCore;
using Management_Internet_Cafe.Models;

namespace Management_Internet_Cafe.Data
{
  public class AppDbContext : DbContext
  {
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
      options.UseSqlServer(
          @"Server=.\SQLEXPRESS;Database=Internet_Cafe_DB;Trusted_Connection=True;TrustServerCertificate=True;");
    }

    public DbSet<Client> Clients { get; set; }
    public DbSet<Computer> Computers { get; set; }
    public DbSet<Game> Games { get; set; }
    public DbSet<Session> Sessions { get; set; }
    public DbSet<SessionGame> SessionGames { get; set; }
    public DbSet<Payment> Payments { get; set; }
  }
}