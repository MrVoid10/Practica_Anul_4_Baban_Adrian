using Management_Internet_Cafe.Data;
using Management_Internet_Cafe.Models;
using System;
using System.Linq;
using System.Net.Mail;
using System.Text.RegularExpressions;
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
      ApplySmartColumnSizing(dgv_Clients);
      ApplySmartColumnSizing(dgv_Computers);
      ApplySmartColumnSizing(dgv_Games);
      ApplySmartColumnSizing(dgv_Session_Game);
      ApplySmartColumnSizing(dgv_Session);
      ApplySmartColumnSizing(dgv_Payments);
    }

    private void LoadData()
    {
      // CLIENTS 
      dgv_Clients.DataSource = _context.Clients
          .Select(c => new
          {
            c.Id,
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
            c.Id,
            c.PcNumber,
            c.Status,
            c.Specifications
          })
          .ToList();

      // GAMES 
      dgv_Games.DataSource = _context.Games
          .Select(g => new
          {
            g.Id,
            g.Name,
            g.Genre
          })
          .ToList();

      // SESSION GAMES 
      dgv_Session_Game.DataSource = _context.SessionGames
          .Select(sg => new
          {
            sg.Id,
            sg.SessionId,
            sg.GameId
          })
          .ToList();
      // SESSION 
      dgv_Session.DataSource = _context.Sessions
          .Select(s => new
          {
            s.Id,
            s.ClientId,
            s.ComputerId,
            s.StartTime,
            s.EndTime
          })
          .ToList();

      // PAYMENTS 
      dgv_Payments.DataSource = _context.Payments
          .Select(p => new
          {
            p.Id,
            p.SessionId,
            p.Amount,
            p.PaymentMethod,
            p.PaymentDate
          })
          .ToList();
      // hide ID from UI
      dgv_Clients.Columns["Id"].Visible = false;
      dgv_Computers.Columns["Id"].Visible = false;
      dgv_Games.Columns["Id"].Visible = false;
      dgv_Session.Columns["Id"].Visible = false;
      dgv_Session_Game.Columns["Id"].Visible = false;
      dgv_Payments.Columns["Id"].Visible = false;

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
    // dgv_Clients
    private void dgv_Clients_CellClick(object sender, DataGridViewCellEventArgs e)
    {
      if (e.RowIndex < 0)
        return;

      DataGridViewRow row = dgv_Clients.Rows[e.RowIndex];

      tb_CL_FirstName.Text = row.Cells["FirstName"].Value?.ToString();
      tb_CL_LastName.Text = row.Cells["LastName"].Value?.ToString();
      tb_CL_Phone.Text = row.Cells["Phone"].Value?.ToString();
      tb_CL_Email.Text = row.Cells["Email"].Value?.ToString();
    }
    private void btn_CL_Add_Click(object sender, EventArgs e)
    {
      try
      {
        if (!ValidateClientInputs())
          return;

        Client client = new Client()
        {
          FirstName = tb_CL_FirstName.Text.Trim(),
          LastName = tb_CL_LastName.Text.Trim(),
          Phone = tb_CL_Phone.Text.Trim(),
          Email = tb_CL_Email.Text.Trim().ToLower()
        };

        _context.Clients.Add(client);

        _context.SaveChanges();

        LoadData();

        ClearClientFields();

        MessageBox.Show("Client added successfully!");
      }
      catch (Exception ex)
      {
        MessageBox.Show("Add error: " + ex.Message);
      }
    }

    private void btn_CL_Edit_Click(object sender, EventArgs e)
    {
      try
      {
        if (!ValidateClientInputs())
          return;

        if (dgv_Clients.CurrentRow == null)
        {
          MessageBox.Show("Select a client first!");
          return;
        }

        int clientId = Convert.ToInt32(
            dgv_Clients.CurrentRow.Cells["Id"].Value);

        Client client = _context.Clients.Find(clientId);

        if (client == null)
        {
          MessageBox.Show("Client not found!");
          return;
        }

        client.FirstName = tb_CL_FirstName.Text.Trim();
        client.LastName = tb_CL_LastName.Text.Trim();
        client.Phone = tb_CL_Phone.Text.Trim();
        client.Email = tb_CL_Email.Text.Trim().ToLower();

        _context.SaveChanges();

        LoadData();

        ClearClientFields();

        MessageBox.Show("Client updated successfully!");
      }
      catch (Exception ex)
      {
        MessageBox.Show("Edit error: " + ex.Message);
      }
    }

    private void btn_CL_Delete_Click(object sender, EventArgs e)
    {
      try
      {
        if (dgv_Clients.CurrentRow == null)
        {
          MessageBox.Show("Select a client first!");
          return;
        }

        DialogResult result = MessageBox.Show(
            "Delete selected client?",
            "Confirm Delete",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning);

        if (result != DialogResult.Yes)
          return;

        int clientId = Convert.ToInt32(
            dgv_Clients.CurrentRow.Cells["Id"].Value);

        Client client = _context.Clients.Find(clientId);

        if (client == null)
        {
          MessageBox.Show("Client not found!");
          return;
        }

        _context.Clients.Remove(client);

        _context.SaveChanges();

        LoadData();

        ClearClientFields();

        MessageBox.Show("Client deleted successfully!");
      }
      catch (Exception ex)
      {
        MessageBox.Show("Delete error: " + ex.Message);
      }
    }

    private void btn_CL_Search_Click(object sender, EventArgs e)
    {
      try
      {
        if (!ValidateSearchInputs())
          return;

        string firstName = tb_CL_FirstName.Text.Trim().ToLower();
        string lastName = tb_CL_LastName.Text.Trim().ToLower();
        string phone = tb_CL_Phone.Text.Trim().ToLower();
        string email = tb_CL_Email.Text.Trim().ToLower();

        dgv_Clients.DataSource = _context.Clients
            .Where(c =>
                c.FirstName.ToLower().Contains(firstName) &&
                c.LastName.ToLower().Contains(lastName) &&
                c.Phone.ToLower().Contains(phone) &&
                c.Email.ToLower().Contains(email))
            .Select(c => new
            {
              c.Id,
              c.FirstName,
              c.LastName,
              c.Phone,
              c.Email
            })
            .ToList();

        dgv_Clients.Columns["Id"].Visible = false;
      }
      catch (Exception ex)
      {
        MessageBox.Show("Search error: " + ex.Message);
      }
    }
    private bool ValidateClientInputs(bool validateEmpty = true)
    {
      // =========================
      // EMPTY FIELD VALIDATION
      // =========================
      if (validateEmpty)
      {
        if (
          string.IsNullOrWhiteSpace(tb_CL_FirstName.Text) ||
          string.IsNullOrWhiteSpace(tb_CL_LastName.Text) ||
          string.IsNullOrWhiteSpace(tb_CL_Phone.Text) ||
          string.IsNullOrWhiteSpace(tb_CL_Email.Text))
        {
          MessageBox.Show("All fields are required!");
          return false;
        }
      }

      // =========================
      // PHONE VALIDATION
      // =========================
      string phone = tb_CL_Phone.Text.Trim();

      bool validPhone =
          Regex.IsMatch(phone, @"^0\d{7,9}$") ||       // 07xxxxxxx
          Regex.IsMatch(phone, @"^\+373\d{8}$");       // +373xxxxxxxx

      if (!validPhone)
      {
        MessageBox.Show(
            "Invalid phone number!\n" +
            "Examples:\n" +
            "071234567\n" +
            "+37371234567");

        return false;
      }

      // =========================
      // EMAIL VALIDATION
      // =========================
      try
      {
        MailAddress mail = new MailAddress(tb_CL_Email.Text);
      }
      catch
      {
        MessageBox.Show("Invalid email address!");
        return false;
      }

      return true;
    }
    private bool ValidateSearchInputs()
    {
      string phone = tb_CL_Phone.Text.Trim();

      if (!string.IsNullOrWhiteSpace(phone))
      {
        bool validPhone =
            Regex.IsMatch(phone, @"^0\d{7,9}$") ||
            Regex.IsMatch(phone, @"^\+373\d{8}$");

        if (!validPhone)
        {
          MessageBox.Show("Invalid phone format!");
          return false;
        }
      }

      if (!string.IsNullOrWhiteSpace(tb_CL_Email.Text))
      {
        try
        {
          MailAddress mail = new MailAddress(tb_CL_Email.Text);
        }
        catch
        {
          MessageBox.Show("Invalid email format!");
          return false;
        }
      }

      return true;
    }
    private void ClearClientFields()
    {
      tb_CL_FirstName.Clear();
      tb_CL_LastName.Clear();
      tb_CL_Phone.Clear();
      tb_CL_Email.Clear();
    }
    private void btn_CL_Clear_Data_Click(object sender, EventArgs e)
    {
      ClearClientFields();
    }
    // dgv_Computers
    private void dgv_Computers_CellClick(object sender, DataGridViewCellEventArgs e)
    {
      if (e.RowIndex >= 0)
      {
        DataGridViewRow row = dgv_Computers.Rows[e.RowIndex];

        tb_PC_PcNumber.Text = row.Cells["PcNumber"].Value?.ToString();
        tb_PC_Status.Text = row.Cells["Status"].Value?.ToString();
        tb_PC_Specifications.Text = row.Cells["Specifications"].Value?.ToString();
      }
    }
    private void btn_PC_Add_Click(object sender, EventArgs e)
    {
      try
      {
        if (string.IsNullOrWhiteSpace(tb_PC_PcNumber.Text) ||
            string.IsNullOrWhiteSpace(tb_PC_Status.Text))
        {
          MessageBox.Show("PcNumber and Status are required!");
          return;
        }

        Computer computer = new Computer()
        {
          PcNumber = tb_PC_PcNumber.Text.Trim(),
          Status = tb_PC_Status.Text.Trim(),
          Specifications = tb_PC_Specifications.Text.Trim()
        };

        _context.Computers.Add(computer);
        _context.SaveChanges();

        LoadData();
        ClearComputerFields();

        MessageBox.Show("Computer added successfully!");
      }
      catch (Exception ex)
      {
        MessageBox.Show("Add error: " + ex.Message);
      }
    }

    private void btn_PC_Edit_Click(object sender, EventArgs e)
    {
      try
      {
        if (dgv_Computers.CurrentRow == null)
        {
          MessageBox.Show("Select a computer first!");
          return;
        }

        int id = Convert.ToInt32(
            dgv_Computers.CurrentRow.Cells["Id"].Value);

        Computer computer = _context.Computers.Find(id);

        if (computer == null)
        {
          MessageBox.Show("Computer not found!");
          return;
        }

        if (string.IsNullOrWhiteSpace(tb_PC_PcNumber.Text) ||
            string.IsNullOrWhiteSpace(tb_PC_Status.Text))
        {
          MessageBox.Show("PcNumber and Status are required!");
          return;
        }

        computer.PcNumber = tb_PC_PcNumber.Text.Trim();
        computer.Status = tb_PC_Status.Text.Trim();
        computer.Specifications = tb_PC_Specifications.Text.Trim();

        _context.SaveChanges();

        LoadData();
        ClearComputerFields();

        MessageBox.Show("Computer updated successfully!");
      }
      catch (Exception ex)
      {
        MessageBox.Show("Edit error: " + ex.Message);
      }
    }

    private void btn_PC_Delete_Click(object sender, EventArgs e)
    {
      try
      {
        if (dgv_Computers.CurrentRow == null)
        {
          MessageBox.Show("Select a computer first!");
          return;
        }

        DialogResult result = MessageBox.Show(
            "Are you sure you want to delete this computer?",
            "Delete Confirmation",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning);

        if (result != DialogResult.Yes)
          return;

        int id = Convert.ToInt32(
            dgv_Computers.CurrentRow.Cells["Id"].Value);

        Computer computer = _context.Computers.Find(id);

        if (computer == null)
        {
          MessageBox.Show("Computer not found!");
          return;
        }

        _context.Computers.Remove(computer);
        _context.SaveChanges();

        LoadData();
        ClearComputerFields();

        MessageBox.Show("Computer deleted successfully!");
      }
      catch (Exception ex)
      {
        MessageBox.Show("Delete error: " + ex.Message);
      }
    }

    private void btn_PC_Search_Click(object sender, EventArgs e)
    {
      try
      {
        string searchPc = tb_PC_PcNumber.Text.Trim().ToLower();
        string searchStatus = tb_PC_Status.Text.Trim().ToLower();

        dgv_Computers.DataSource = _context.Computers
            .Where(c =>
                (string.IsNullOrEmpty(searchPc) ||
                 c.PcNumber.ToLower().Contains(searchPc))
                &&
                (string.IsNullOrEmpty(searchStatus) ||
                 c.Status.ToLower().Contains(searchStatus))
            )
            .Select(c => new
            {
              c.Id,
              c.PcNumber,
              c.Status,
              c.Specifications
            })
            .ToList();

        dgv_Computers.Columns["Id"].Visible = false;
      }
      catch (Exception ex)
      {
        MessageBox.Show("Search error: " + ex.Message);
      }
    }
    private void ClearComputerFields()
    {
      tb_PC_PcNumber.Clear();
      tb_PC_Status.Clear();
      tb_PC_Specifications.Clear();
    }

    private void btn_PC_Clear_Fields_Click(object sender, EventArgs e)
    {
      ClearComputerFields();
    }

    // dgv_Games
    private void dgv_Games_CellClick(object sender, DataGridViewCellEventArgs e)
    {
      if (e.RowIndex >= 0)
      {
        DataGridViewRow row = dgv_Games.Rows[e.RowIndex];

        tb_GM_Name.Text = row.Cells["Name"].Value?.ToString();
        tb_GM_Genre.Text = row.Cells["Genre"].Value?.ToString();
      }
    }
    private void btn_GM_Add_Click(object sender, EventArgs e)
    {
      try
      {
        if (string.IsNullOrWhiteSpace(tb_GM_Name.Text) ||
            string.IsNullOrWhiteSpace(tb_GM_Genre.Text))
        {
          MessageBox.Show("All fields are required!");
          return;
        }

        Game game = new Game()
        {
          Name = tb_GM_Name.Text.Trim(),
          Genre = tb_GM_Genre.Text.Trim()
        };

        _context.Games.Add(game);
        _context.SaveChanges();

        LoadData();
        ClearGameFields();

        MessageBox.Show("Game added successfully!");
      }
      catch (Exception ex)
      {
        MessageBox.Show("Add error: " + ex.Message);
      }
    }


    private void btn_GM_Edit_Click(object sender, EventArgs e)
    {
      try
      {
        if (dgv_Games.CurrentRow == null)
        {
          MessageBox.Show("Select a game first!");
          return;
        }

        int id = Convert.ToInt32(
            dgv_Games.CurrentRow.Cells["Id"].Value);

        Game game = _context.Games.Find(id);

        if (game == null)
        {
          MessageBox.Show("Game not found!");
          return;
        }

        if (string.IsNullOrWhiteSpace(tb_GM_Name.Text) ||
            string.IsNullOrWhiteSpace(tb_GM_Genre.Text))
        {
          MessageBox.Show("All fields are required!");
          return;
        }

        game.Name = tb_GM_Name.Text.Trim();
        game.Genre = tb_GM_Genre.Text.Trim();

        _context.SaveChanges();

        LoadData();
        ClearGameFields();

        MessageBox.Show("Game updated successfully!");
      }
      catch (Exception ex)
      {
        MessageBox.Show("Edit error: " + ex.Message);
      }
    }

    private void btn_GM_Delete_Click(object sender, EventArgs e)
    {
      try
      {
        if (dgv_Games.CurrentRow == null)
        {
          MessageBox.Show("Select a game first!");
          return;
        }

        DialogResult result = MessageBox.Show(
            "Are you sure you want to delete this game?",
            "Delete Confirmation",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning);

        if (result != DialogResult.Yes)
          return;

        int id = Convert.ToInt32(
            dgv_Games.CurrentRow.Cells["Id"].Value);

        Game game = _context.Games.Find(id);

        if (game == null)
        {
          MessageBox.Show("Game not found!");
          return;
        }

        _context.Games.Remove(game);
        _context.SaveChanges();

        LoadData();
        ClearGameFields();

        MessageBox.Show("Game deleted successfully!");
      }
      catch (Exception ex)
      {
        MessageBox.Show("Delete error: " + ex.Message);
      }
    }

    private void btn_GM_Search_Click(object sender, EventArgs e)
    {
      try
      {
        string searchName = tb_GM_Name.Text.Trim().ToLower();
        string searchGenre = tb_GM_Genre.Text.Trim().ToLower();

        dgv_Games.DataSource = _context.Games
            .Where(g =>
                (string.IsNullOrEmpty(searchName) ||
                 g.Name.ToLower().Contains(searchName))
                &&
                (string.IsNullOrEmpty(searchGenre) ||
                 g.Genre.ToLower().Contains(searchGenre))
            )
            .Select(g => new
            {
              g.Id,
              g.Name,
              g.Genre
            })
            .ToList();

        dgv_Games.Columns["Id"].Visible = false;
      }
      catch (Exception ex)
      {
        MessageBox.Show("Search error: " + ex.Message);
      }
    }
    private void ClearGameFields()
    {
      tb_GM_Name.Clear();
      tb_GM_Genre.Clear();
    }

    private void btn_GM_Clear_Fields_Click(object sender, EventArgs e)
    {
      ClearGameFields();
    }
    // dgv_Session_Game
    private void dgv_Session_Game_CellClick(object sender, DataGridViewCellEventArgs e)
    {

    }
    // dgv_Payments
    private void dgv_Payments_CellClick(object sender, DataGridViewCellEventArgs e)
    {

    }
    // dgv_Sessions
    private void dgv_Sessions_CellClick(object sender, DataGridViewCellEventArgs e)
    {

    }
    private void btn_S_Add_Click(object sender, EventArgs e)
    {

    }

    private void btn_S_Edit_Click(object sender, EventArgs e)
    {

    }

    private void btn_S_Delete_Click(object sender, EventArgs e)
    {

    }

    private void btn_S_Search_Click(object sender, EventArgs e)
    {

    }
    // EXTRA CODE


  }
}