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
        //string sqlFilePath = "init.sql";
        string sqlFilePath = "E:\\Programare\\Anul_4\\Practica_Anul_4\\Management_Internet_Cafe\\Data\\init.sql";

        if (!File.Exists(sqlFilePath))
        {
          throw new Exception("init.sql file not found!");
        }

        string sql = File.ReadAllText(sqlFilePath);

        using (var db = new AppDbContext())
        {
          db.Database.ExecuteSqlRaw(sql);
        }
      }
      catch (Exception ex)
      {
        throw new Exception("Database initialization failed: " + ex.Message);
      }
    }
  }
}