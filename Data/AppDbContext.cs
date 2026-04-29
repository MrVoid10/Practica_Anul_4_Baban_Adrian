using Microsoft.EntityFrameworkCore;

namespace Management_Internet_Cafe.Data
{
  public class AppDbContext : DbContext
  {
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
      options.UseSqlServer(
          @"Server=.\SQLEXPRESS;Database=Internet_Cafe_DB;Trusted_Connection=True;TrustServerCertificate=True;");
    }
  }
}