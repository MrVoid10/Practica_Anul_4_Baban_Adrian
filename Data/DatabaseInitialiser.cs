using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

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
        // ONLY ERROR POPUP
        MessageBox.Show(
          "Database initialization failed:\n" + ex.Message,
          "Database Error",
          MessageBoxButtons.OK,
          MessageBoxIcon.Error
        );
      }
    }

    private static void RunInitSql(AppDbContext db)
    {
      string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "init.sql");

      if (!File.Exists(path))
        throw new Exception("init.sql file not found!");

      string sql = File.ReadAllText(path);

      db.Database.ExecuteSqlRaw(sql);
    }

    private static void RunSeedSqlIfNeeded(AppDbContext db)
    {
      try
      {
        // RAW SQL CHECK (fast, no UI delay)
        var result = db.Database
          .SqlQueryRaw<int>("SELECT COUNT(*) AS VALUE FROM Clients")
          .First();

        if (result > 0)
          return; // already seeded

        string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "seed.sql");

        if (!File.Exists(path))
          throw new Exception("seed.sql file not found!");

        string sql = File.ReadAllText(path);

        db.Database.ExecuteSqlRaw(sql);
      }
      catch (Exception ex)
      {
        throw new Exception("Seed initialization failed: " + ex.Message);
      }
    }
  }
}