using Microsoft.EntityFrameworkCore;
using System;
using System.IO;

namespace Management_Internet_Cafe.Data
{
  public static class DatabaseInitializer
  {
    public static void Initialize()
    {
      try
      {
        using (var db = new AppDbContext())
        {
          db.Database.EnsureCreated();

          RunInitSql(db);
          RunSeedSqlIfNeeded(db);
        }
      }
      catch (Exception ex)
      {
        throw new Exception("Database initialization failed: " + ex.Message);
      }
    }

    private static void RunInitSql(AppDbContext db)
    {
      string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"Data","init.sql");

      if (!File.Exists(path))
        throw new Exception("init.sql file not found!");

      string sql = File.ReadAllText(path);
      db.Database.ExecuteSqlRaw(sql);
    }

    private static void RunSeedSqlIfNeeded(AppDbContext db)
    {
      // 🔥 RAW SQL CHECK (no EF models)
      var result = db.Database
          .SqlQuery<int>($"SELECT COUNT(*) AS Value FROM Clients")
          .First();

      if (result > 0)
        return; // already seeded

      string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"Data","seed.sql");

      if (!File.Exists(path))
        throw new Exception("seed.sql file not found!");

      string sql = File.ReadAllText(path);
      db.Database.ExecuteSqlRaw(sql);
    }
  }
}