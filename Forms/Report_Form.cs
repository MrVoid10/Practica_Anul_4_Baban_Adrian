using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Management_Internet_Cafe.Data;
using Management_Internet_Cafe.Models;


namespace Management_Internet_Cafe.Forms
{
  public partial class Report_Form : Form
  {
    public Report_Form()
    {
      InitializeComponent();
    }

    private void btn_Generate_Report_Click(object sender, EventArgs e)
    {
      using var context = new AppDbContext();

      var selectedTables = GetSelectedTables();
      var detailLevel = GetDetailLevel();

      StringBuilder report = new StringBuilder();

      foreach (var table in selectedTables)
      {
        switch (table)
        {
          case "Clients":
            report.AppendLine(GenerateClientsReport(context, detailLevel));
            break;

          case "Computers":
            report.AppendLine(GenerateComputersReport(context, detailLevel));
            break;

          case "Games":
            report.AppendLine(GenerateGamesReport(context, detailLevel));
            break;

          case "Sessions":
            report.AppendLine(GenerateSessionsReport(context, detailLevel));
            break;

          case "SessionGames":
            report.AppendLine(GenerateSessionGamesReport(context, detailLevel));
            break;

          case "Payments":
            report.AppendLine(GeneratePaymentsReport(context, detailLevel));
            break;
        }

        report.AppendLine("\n----------------------\n");
      }

      tb_Report_Preview.Text = report.ToString();
      ExportReport(report.ToString());
    }
    // HELPERS
    private List<string> GetSelectedTables()
    {
      List<string> tables = new List<string>();

      foreach (var item in CLB_Selected_Tables.CheckedItems)
        tables.Add(item.ToString());

      return tables;
    }
    private string GetDetailLevel()
    {
      if (RB_Basic.Checked)
        return "Basic";

      if (RB_Detailed.Checked)
        return "Detailed";

      return "Advanced";
    }
    private string EstimateMemory<T>(List<T> data)
    {
      long bytes = System.Text.Json.JsonSerializer.Serialize(data).Length;

      if (bytes < 1024)
        return $"{bytes} B";

      double kb = bytes / 1024.0;
      if (kb < 1024)
        return $"{kb:0.00} KB";

      double mb = kb / 1024.0;
      if (mb < 1024)
        return $"{mb:0.00} MB";

      double gb = mb / 1024.0;
      return $"{gb:0.00} GB";
    }
    private List<string> GetSelectedFormats()
    {
      List<string> formats = new List<string>();

      foreach (var item in CLB_Export_Formats.CheckedItems)
      {
        formats.Add(item.ToString());
      }

      return formats;
    }
    // Table Report Queries
    // Clients
    private string GenerateClientsReport(AppDbContext context, string level)
    {
      var data = context.Clients.ToList();

      StringBuilder sb = new StringBuilder();

      sb.AppendLine("=== CLIENTS REPORT ===");

      if (level == "Basic")
      {
        sb.AppendLine($"Rows: {data.Count}");
        sb.AppendLine($"Estimated Memory: {EstimateMemory(data)}");

        sb.AppendLine("Main Column: FirstName + LastName");

        sb.AppendLine("Preview:");
        foreach (var c in data.Take(5))
          sb.AppendLine($"{c.FirstName} {c.LastName}");
      }
      else if (level == "Detailed")
      {
        sb.AppendLine("Full Data:");

        foreach (var c in data)
          sb.AppendLine($"{c.Id} | {c.FirstName} | {c.LastName} | {c.Phone} | {c.Email}");
      }
      else // Advanced
      {
        sb.AppendLine($"Total Clients: {data.Count}");

        var domainGroups = data
            .Where(c => c.Email != null)
            .GroupBy(c => c.Email.Split('@').Last())
            .OrderByDescending(g => g.Count());

        sb.AppendLine("Email Domains:");
        foreach (var g in domainGroups)
          sb.AppendLine($"{g.Key}: {g.Count()}");
      }

      return sb.ToString();
    }
    // Computers
    private string GenerateComputersReport(AppDbContext context, string level)
    {
      var data = context.Computers.ToList();

      StringBuilder sb = new StringBuilder();
      sb.AppendLine("=== COMPUTERS REPORT ===");

      if (level == "Basic")
      {
        sb.AppendLine($"Rows: {data.Count}");
        sb.AppendLine($"Estimated Memory: {EstimateMemory(data)}");
        sb.AppendLine("Main Column: PcNumber");

        foreach (var c in data.Take(5))
          sb.AppendLine($"{c.PcNumber} - {c.Status}");
      }
      else if (level == "Detailed")
      {
        foreach (var c in data)
          sb.AppendLine($"{c.Id} | {c.PcNumber} | {c.Status} | {c.Specifications}");
      }
      else
      {
        sb.AppendLine($"Total PCs: {data.Count}");
        sb.AppendLine($"Available: {data.Count(x => x.Status == "Available")}");
        sb.AppendLine($"Broken: {data.Count(x => x.Status == "Broken")}");
    }

    return sb.ToString();
}
    //games
    private string GenerateGamesReport(AppDbContext context, string level)
    {
      var data = context.Games.ToList();

      StringBuilder sb = new StringBuilder();
      sb.AppendLine("=== GAMES REPORT ===");

      if (level == "Basic")
      {
        sb.AppendLine($"Rows: {data.Count}");
        sb.AppendLine("Main Column: Name");

        foreach (var g in data.Take(5))
          sb.AppendLine(g.Name);
      }
      else if (level == "Detailed")
      {
        foreach (var g in data)
          sb.AppendLine($"{g.Id} | {g.Name} | {g.Genre}");
      }
      else
      {
        sb.AppendLine($"Total Games: {data.Count}");

        var genres = data
            .GroupBy(g => g.Genre)
            .OrderByDescending(g => g.Count());

        foreach (var g in genres)
          sb.AppendLine($"{g.Key}: {g.Count()}");
      }

      return sb.ToString();
    }
    //Sessions
    private string GenerateSessionsReport(AppDbContext context, string level)
    {
      var data = context.Sessions.ToList();

      StringBuilder sb = new StringBuilder();
      sb.AppendLine("=== SESSIONS REPORT ===");

      if (level == "Basic")
      {
        sb.AppendLine($"Rows: {data.Count}");
        sb.AppendLine("Main Column: ClientId / ComputerId");

        foreach (var s in data.Take(5))
          sb.AppendLine($"{s.ClientId} - PC {s.ComputerId}");
      }
      else if (level == "Detailed")
      {
        foreach (var s in data)
          sb.AppendLine($"{s.Id} | {s.ClientId} | {s.ComputerId} | {s.StartTime} - {s.EndTime}");
      }
      else
      {
        sb.AppendLine($"Active Sessions: {data.Count(x => x.EndTime == null)}");
        sb.AppendLine($"Finished Sessions: {data.Count(x => x.EndTime != null)}");
      }

      return sb.ToString();
    }
    //Session Games
    private string GenerateSessionGamesReport(AppDbContext context, string level)
    {
      var data = context.SessionGames.ToList();

      StringBuilder sb = new StringBuilder();

      sb.AppendLine("=== SESSION GAMES REPORT ===");

      if (level == "Basic")
      {
        sb.AppendLine($"Rows: {data.Count}");
        sb.AppendLine($"Estimated Memory: {EstimateMemory(data)}");
        sb.AppendLine("Main Column: SessionId + GameId relation");

        sb.AppendLine("Preview:");
        foreach (var sg in data.Take(5))
          sb.AppendLine($"Session {sg.SessionId} → Game {sg.GameId}");
      }
      else if (level == "Detailed")
      {
        sb.AppendLine("Full Data:");

        foreach (var sg in data)
          sb.AppendLine($"{sg.Id} | Session {sg.SessionId} | Game {sg.GameId}");
      }
      else // Advanced
      {
        sb.AppendLine($"Total Relations: {data.Count}");

        var mostUsedGames = data
            .GroupBy(x => x.GameId)
            .OrderByDescending(g => g.Count())
            .Take(5);

        sb.AppendLine("Most Played Games:");
        foreach (var g in mostUsedGames)
          sb.AppendLine($"Game {g.Key}: {g.Count()} sessions");

        var mostActiveSessions = data
            .GroupBy(x => x.SessionId)
            .OrderByDescending(g => g.Count())
            .Take(5);

        sb.AppendLine("Most Active Sessions:");
        foreach (var s in mostActiveSessions)
          sb.AppendLine($"Session {s.Key}: {s.Count()} games linked");
      }

      return sb.ToString();
    }
    //Payment
    private string GeneratePaymentsReport(AppDbContext context, string level)
    {
      var data = context.Payments.ToList();

      StringBuilder sb = new StringBuilder();
      sb.AppendLine("=== PAYMENTS REPORT ===");

      if (level == "Basic")
      {
        sb.AppendLine($"Rows: {data.Count}");
        sb.AppendLine($"Estimated Memory: {EstimateMemory(data)}");
        sb.AppendLine($"Main Column: Amount");

        foreach (var p in data.Take(5))
          sb.AppendLine($"{p.Amount} ({p.PaymentMethod})");
      }
      else if (level == "Detailed")
      {
        foreach (var p in data)
          sb.AppendLine($"{p.Id} | {p.SessionId} | {p.Amount} | {p.PaymentMethod} | {p.PaymentDate}");
      }
      else
      {
        sb.AppendLine($"Total Revenue: {data.Sum(p => p.Amount)}");
        sb.AppendLine($"Max Payment: {data.Max(p => p.Amount)}");
        sb.AppendLine($"Cash Payments: {data.Count(p => p.PaymentMethod == "Cash")}");
      }

      return sb.ToString();
    }
    // EXPORT Functions
    private void ExportReport(string reportText)
    {
      var formats = GetSelectedFormats();

      foreach (var format in formats)
      {
        switch (format)
        {
          case "TXT":
            ExportToTxt(reportText);
            break;

          case "PDF":
            //ExportToPdf(reportText);
            break;

          case "EXCEL":
            //ExportToExcel(reportText);
            break;
        }
      }
    }
    private void ExportToTxt(string reportText)
    {
      using (SaveFileDialog sfd = new SaveFileDialog())
      {
        sfd.Filter = "Text File (*.txt)|*.txt";
        sfd.FileName = "report.txt";

        if (sfd.ShowDialog() == DialogResult.OK)
        {
          File.WriteAllText(sfd.FileName, reportText);
        }
      }
    }

  }
}
