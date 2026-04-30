using Management_Internet_Cafe.Data;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Management_Internet_Cafe.Forms
{
  public partial class Simple_Data_Grid_View : Form
  {
    private AppDbContext _context;

    public Simple_Data_Grid_View()
    {
      InitializeComponent();
      _context = new AppDbContext();
    }

    private void Simple_Data_Grid_View_Load(object sender, EventArgs e)
    {
      LoadData();
      //SetupGrids();
      ApplySmartColumnSizing(dgv_Clients);
      ApplySmartColumnSizing(dgv_Computers);
      ApplySmartColumnSizing(dgv_Games);
      ApplySmartColumnSizing(dgv_Session_Game);
      ApplySmartColumnSizing(dgv_Payments);
    }

    private void LoadData()
    {
      // CLIENTS 
      dgv_Clients.DataSource = _context.Clients
          .Select(c => new
          {
            c.FirstName,
            c.LastName,
            c.Phone,
            c.Email
          })
          .ToList();

      // COMPUTERS 
      dgv_Computers.DataSource = _context.Computers
          .Select(c => new
          {
            c.PcNumber,
            c.Status,
            c.Specifications
          })
          .ToList();

      // GAMES 
      dgv_Games.DataSource = _context.Games
          .Select(g => new
          {
            g.Name,
            g.Genre
          })
          .ToList();

      // SESSION GAMES 
      dgv_Session_Game.DataSource = _context.SessionGames
          .Select(sg => new
          {
            sg.SessionId,
            sg.GameId
          })
          .ToList();

      // PAYMENTS 
      dgv_Payments.DataSource = _context.Payments
          .Select(p => new
          {
            p.SessionId,
            p.Amount,
            p.PaymentMethod,
            p.PaymentDate
          })
          .ToList();
    }
    // GRID FORMATTING
    private void SetupGrids()
    {
      SetupGrid(dgv_Clients);
      SetupGrid(dgv_Computers);
      SetupGrid(dgv_Games);
      SetupGrid(dgv_Session_Game);
      SetupGrid(dgv_Payments);
    }

    // REUSABLE GRID STYLE
    private void SetupGrid(DataGridView dgv)
    {
      dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
      dgv.RowHeadersVisible = false;
      dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      dgv.ReadOnly = true;
    }

    private void ApplySmartColumnSizing(DataGridView dgv)
    {
      dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

      foreach (DataGridViewColumn col in dgv.Columns)
      {
        string name = col.Name.ToLower();

        Type type = col.ValueType;

        // =========================
        // INTEGER / ID COLUMNS
        // =========================
        if (type == typeof(int) || name.Contains("id"))
        {
          col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
          col.MinimumWidth = 40;
          col.Width = 60;
          continue;
        }

        // =========================
        // DECIMAL / FLOAT / CURRENCY
        // =========================
        if (type == typeof(decimal) ||
            type == typeof(double) ||
            type == typeof(float))
        {
          col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

          // small but readable for money
          col.MinimumWidth = 80;
          col.Width = 100;

          col.DefaultCellStyle.Format = "0.00"; // optional formatting
          continue;
        }

        // =========================
        // DATE / TIME
        // =========================
        if (type == typeof(DateTime) || name.Contains("date") || name.Contains("time"))
        {
          col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
          col.MinimumWidth = 120;

          col.DefaultCellStyle.Format = "yyyy-MM-dd HH:mm";
          continue;
        }

        // =========================
        // SHORT TEXT (status, name, genre)
        // =========================
        if (name.Contains("name") ||
            name.Contains("status") ||
            name.Contains("genre") ||
            name.Contains("method"))
        {
          col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
          col.MinimumWidth = 100;
          continue;
        }

        // =========================
        // LONG TEXT (default)
        // =========================
        col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        col.FillWeight = 200;
      }
    }
  }
}