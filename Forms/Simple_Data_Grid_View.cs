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
  }
}