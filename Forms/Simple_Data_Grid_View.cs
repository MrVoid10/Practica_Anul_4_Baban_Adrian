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
    // dgv_Sessions
    private void dgv_Sessions_CellClick(object sender, DataGridViewCellEventArgs e)
    {
      if (e.RowIndex >= 0)
      {
        DataGridViewRow row = dgv_Session.Rows[e.RowIndex];

        tb_S_ClientID.Text = row.Cells["ClientId"].Value?.ToString();
        tb_S_ComputerID.Text = row.Cells["ComputerId"].Value?.ToString();
        tb_S_StartTime.Text = row.Cells["StartTime"].Value?.ToString();
        tb_S_EndTime.Text = row.Cells["EndTime"].Value?.ToString();
      }
    }
    private void btn_S_Add_Click(object sender, EventArgs e)
    {
      try
      {
        // Required fields
        if (string.IsNullOrWhiteSpace(tb_S_ClientID.Text) ||
            string.IsNullOrWhiteSpace(tb_S_ComputerID.Text) ||
            string.IsNullOrWhiteSpace(tb_S_StartTime.Text))
        {
          MessageBox.Show("ClientId, ComputerId and StartTime are required!");
          return;
        }

        // Parse IDs
        if (!int.TryParse(tb_S_ClientID.Text, out int clientId))
        {
          MessageBox.Show("Invalid Client ID!");
          return;
        }

        if (!int.TryParse(tb_S_ComputerID.Text, out int computerId))
        {
          MessageBox.Show("Invalid Computer ID!");
          return;
        }

        // Validate existing client
        bool clientExists = _context.Clients.Any(c => c.Id == clientId);

        if (!clientExists)
        {
          MessageBox.Show("Client ID does not exist!");
          return;
        }

        // Validate existing computer
        bool computerExists = _context.Computers.Any(c => c.Id == computerId);

        if (!computerExists)
        {
          MessageBox.Show("Computer ID does not exist!");
          return;
        }

        // Parse dates
        if (!DateTime.TryParse(tb_S_StartTime.Text, out DateTime startTime))
        {
          MessageBox.Show("Invalid StartTime!");
          return;
        }

        DateTime? endTime = null;

        if (!string.IsNullOrWhiteSpace(tb_S_EndTime.Text))
        {
          if (!DateTime.TryParse(tb_S_EndTime.Text, out DateTime parsedEnd))
          {
            MessageBox.Show("Invalid EndTime!");
            return;
          }

          // Validate time order
          if (parsedEnd < startTime)
          {
            MessageBox.Show("EndTime cannot be earlier than StartTime!");
            return;
          }

          endTime = parsedEnd;
        }

        Session session = new Session()
        {
          ClientId = clientId,
          ComputerId = computerId,
          StartTime = startTime,
          EndTime = endTime
        };

        _context.Sessions.Add(session);
        _context.SaveChanges();

        LoadData();
        ClearSessionFields();

        MessageBox.Show("Session added successfully!");
      }
      catch (Exception ex)
      {
        MessageBox.Show("Add error: " + ex.Message);
      }
    }

    private void btn_S_Edit_Click(object sender, EventArgs e)
    {
      try
      {
        if (dgv_Session.CurrentRow == null)
        {
          MessageBox.Show("Select a session first!");
          return;
        }

        int id = Convert.ToInt32(
            dgv_Session.CurrentRow.Cells["Id"].Value);

        Session session = _context.Sessions.Find(id);

        if (session == null)
        {
          MessageBox.Show("Session not found!");
          return;
        }

        // Validate IDs
        if (!int.TryParse(tb_S_ClientID.Text, out int clientId) ||
            !int.TryParse(tb_S_ComputerID.Text, out int computerId))
        {
          MessageBox.Show("Invalid IDs!");
          return;
        }

        bool clientExists = _context.Clients.Any(c => c.Id == clientId);

        if (!clientExists)
        {
          MessageBox.Show("Client ID does not exist!");
          return;
        }

        bool computerExists = _context.Computers.Any(c => c.Id == computerId);

        if (!computerExists)
        {
          MessageBox.Show("Computer ID does not exist!");
          return;
        }

        // Validate dates
        if (!DateTime.TryParse(tb_S_StartTime.Text, out DateTime startTime))
        {
          MessageBox.Show("Invalid StartTime!");
          return;
        }

        DateTime? endTime = null;

        if (!string.IsNullOrWhiteSpace(tb_S_EndTime.Text))
        {
          if (!DateTime.TryParse(tb_S_EndTime.Text, out DateTime parsedEnd))
          {
            MessageBox.Show("Invalid EndTime!");
            return;
          }

          if (parsedEnd < startTime)
          {
            MessageBox.Show("EndTime cannot be earlier than StartTime!");
            return;
          }

          endTime = parsedEnd;
        }

        session.ClientId = clientId;
        session.ComputerId = computerId;
        session.StartTime = startTime;
        session.EndTime = endTime;

        _context.SaveChanges();

        LoadData();
        ClearSessionFields();

        MessageBox.Show("Session updated successfully!");
      }
      catch (Exception ex)
      {
        MessageBox.Show("Edit error: " + ex.Message);
      }
    }

    private void btn_S_Delete_Click(object sender, EventArgs e)
    {
      try
      {
        if (dgv_Session.CurrentRow == null)
        {
          MessageBox.Show("Select a session first!");
          return;
        }

        DialogResult result = MessageBox.Show(
            "Are you sure you want to delete this session?",
            "Delete Confirmation",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning);

        if (result != DialogResult.Yes)
          return;

        int id = Convert.ToInt32(
            dgv_Session.CurrentRow.Cells["Id"].Value);

        Session session = _context.Sessions.Find(id);

        if (session == null)
        {
          MessageBox.Show("Session not found!");
          return;
        }

        _context.Sessions.Remove(session);
        _context.SaveChanges();

        LoadData();
        ClearSessionFields();

        MessageBox.Show("Session deleted successfully!");
      }
      catch (Exception ex)
      {
        MessageBox.Show("Delete error: " + ex.Message);
      }
    }

    private void btn_S_Search_Click(object sender, EventArgs e)
    {
      try
      {
        string clientSearch = tb_S_ClientID.Text.Trim();
        string computerSearch = tb_S_ComputerID.Text.Trim();

        dgv_Session.DataSource = _context.Sessions
            .Where(s =>
                (string.IsNullOrEmpty(clientSearch) ||
                 s.ClientId.ToString().Contains(clientSearch))
                &&
                (string.IsNullOrEmpty(computerSearch) ||
                 s.ComputerId.ToString().Contains(computerSearch))
            )
            .Select(s => new
            {
              s.Id,
              s.ClientId,
              s.ComputerId,
              s.StartTime,
              s.EndTime
            })
            .ToList();

        dgv_Session.Columns["Id"].Visible = false;
      }
      catch (Exception ex)
      {
        MessageBox.Show("Search error: " + ex.Message);
      }
    }

    private void ClearSessionFields()
    {
      tb_S_ClientID.Clear();
      tb_S_ComputerID.Clear();
      tb_S_StartTime.Clear();
      tb_S_EndTime.Clear();
    }

    private void btn_S_Clear_Fields_Click(object sender, EventArgs e)
    {
      ClearSessionFields();
    }
    // dgv_Session_Game
    private void dgv_Session_Game_CellClick(object sender, DataGridViewCellEventArgs e)
    {
      if (e.RowIndex >= 0)
      {
        DataGridViewRow row = dgv_Session_Game.Rows[e.RowIndex];

        tb_SG_SessionID.Text = row.Cells["SessionId"].Value?.ToString();
        tb_SG_GameID.Text = row.Cells["GameId"].Value?.ToString();
      }
    }
    private void btn_SG_Add_Click(object sender, EventArgs e)
    {
      try
      {
        if (!int.TryParse(tb_SG_SessionID.Text, out int sessionId) ||
            !int.TryParse(tb_SG_GameID.Text, out int gameId))
        {
          MessageBox.Show("Invalid SessionId or GameId!");
          return;
        }

        // FK VALIDATION
        bool sessionExists = _context.Sessions.Any(s => s.Id == sessionId);
        bool gameExists = _context.Games.Any(g => g.Id == gameId);

        if (!sessionExists)
        {
          MessageBox.Show("Session does not exist!");
          return;
        }

        if (!gameExists)
        {
          MessageBox.Show("Game does not exist!");
          return;
        }

        // DUPLICATE CHECK
        bool exists = _context.SessionGames
            .Any(sg => sg.SessionId == sessionId && sg.GameId == gameId);

        if (exists)
        {
          MessageBox.Show("This game is already assigned to this session!");
          return;
        }

        SessionGame sgEntity = new SessionGame()
        {
          SessionId = sessionId,
          GameId = gameId
        };

        _context.SessionGames.Add(sgEntity);
        _context.SaveChanges();

        LoadData();
        ClearSessionGameFields();

        MessageBox.Show("SessionGame added successfully!");
      }
      catch (Exception ex)
      {
        MessageBox.Show("Add error: " + ex.Message);
      }
    }

    private void btn_SG_Edit_Click(object sender, EventArgs e)
    {
      try
      {
        if (dgv_Session_Game.CurrentRow == null)
        {
          MessageBox.Show("Select a record first!");
          return;
        }

        int id = Convert.ToInt32(
            dgv_Session_Game.CurrentRow.Cells["Id"].Value);

        SessionGame sg = _context.SessionGames.Find(id);

        if (sg == null)
        {
          MessageBox.Show("Record not found!");
          return;
        }

        if (!int.TryParse(tb_SG_SessionID.Text, out int sessionId) ||
            !int.TryParse(tb_SG_GameID.Text, out int gameId))
        {
          MessageBox.Show("Invalid SessionId or GameId!");
          return;
        }

        bool sessionExists = _context.Sessions.Any(s => s.Id == sessionId);
        bool gameExists = _context.Games.Any(g => g.Id == gameId);

        if (!sessionExists || !gameExists)
        {
          MessageBox.Show("Session or Game does not exist!");
          return;
        }

        sg.SessionId = sessionId;
        sg.GameId = gameId;

        _context.SaveChanges();

        LoadData();
        ClearSessionGameFields();

        MessageBox.Show("SessionGame updated!");
      }
      catch (Exception ex)
      {
        MessageBox.Show("Edit error: " + ex.Message);
      }
    }

    private void btn_SG_Delete_Click(object sender, EventArgs e)
    {
      try
      {
        if (dgv_Session_Game.CurrentRow == null)
        {
          MessageBox.Show("Select a record first!");
          return;
        }

        DialogResult result = MessageBox.Show(
            "Are you sure you want to delete this relation?",
            "Delete Confirmation",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning);

        if (result != DialogResult.Yes)
          return;

        int id = Convert.ToInt32(
            dgv_Session_Game.CurrentRow.Cells["Id"].Value);

        SessionGame sg = _context.SessionGames.Find(id);

        if (sg == null)
        {
          MessageBox.Show("Record not found!");
          return;
        }

        _context.SessionGames.Remove(sg);
        _context.SaveChanges();

        LoadData();
        ClearSessionGameFields();

        MessageBox.Show("Deleted successfully!");
      }
      catch (Exception ex)
      {
        MessageBox.Show("Delete error: " + ex.Message);
      }
    }

    private void btn_SG_Search_Click(object sender, EventArgs e)
    {
      try
      {
        string sessionSearch = tb_SG_SessionID.Text.Trim();
        string gameSearch = tb_SG_GameID.Text.Trim();

        dgv_Session_Game.DataSource = _context.SessionGames
            .Where(sg =>
                (string.IsNullOrEmpty(sessionSearch) ||
                 sg.SessionId.ToString().Contains(sessionSearch))
                &&
                (string.IsNullOrEmpty(gameSearch) ||
                 sg.GameId.ToString().Contains(gameSearch))
            )
            .Select(sg => new
            {
              sg.Id,
              sg.SessionId,
              sg.GameId
            })
            .ToList();

        dgv_Session_Game.Columns["Id"].Visible = false;
      }
      catch (Exception ex)
      {
        MessageBox.Show("Search error: " + ex.Message);
      }
    }

    private void ClearSessionGameFields()
    {
      tb_SG_SessionID.Clear();
      tb_SG_GameID.Clear();
    }

    private void btn_SG_Clear_Fields_Click(object sender, EventArgs e)
    {
      ClearSessionGameFields();
    }
    // dgv_Payments
    private void dgv_Payments_CellClick(object sender, DataGridViewCellEventArgs e)
    {
      if (e.RowIndex < 0) return;

      var row = dgv_Payments.Rows[e.RowIndex];

      tb_PY_SessionID.Text = row.Cells["SessionId"].Value?.ToString();
      tb_PY_Amount.Text = row.Cells["Amount"].Value?.ToString();
      tb_PY_PaymentMethod.Text = row.Cells["PaymentMethod"].Value?.ToString();
      tb_PY_PaymentDate.Text = row.Cells["PaymentDate"].Value?.ToString(); 
    }

    private void btn_PY_Add_Click(object sender, EventArgs e)
    {
      if (!ValidatePayment()) return;

      if (!DateTime.TryParse(tb_PY_PaymentDate.Text, out DateTime paymentDate))
      {
        MessageBox.Show("Invalid payment date format");
        return;
      }

      var payment = new Payment
      {
        SessionId = int.Parse(tb_PY_SessionID.Text),
        Amount = decimal.Parse(tb_PY_Amount.Text),
        PaymentMethod = tb_PY_PaymentMethod.Text,
        PaymentDate = paymentDate
      };

      _context.Payments.Add(payment);
      _context.SaveChanges();

      LoadPayments();
      ClearPaymentFields();
    }

    private void btn_PY_Edit_Click(object sender, EventArgs e)
    {
      if (dgv_Payments.CurrentRow == null) return;
      if (!ValidatePayment()) return;

      int id = Convert.ToInt32(dgv_Payments.CurrentRow.Cells["Id"].Value);

      var payment = _context.Payments.FirstOrDefault(p => p.Id == id);
      if (payment == null) return;

      if (!DateTime.TryParse(tb_PY_PaymentDate.Text, out DateTime paymentDate))
      {
        MessageBox.Show("Invalid payment date format");
        return;
      }

      payment.SessionId = int.Parse(tb_PY_SessionID.Text);
      payment.Amount = decimal.Parse(tb_PY_Amount.Text);
      payment.PaymentMethod = tb_PY_PaymentMethod.Text;
      payment.PaymentDate = paymentDate;

      _context.SaveChanges();

      LoadPayments();
    }

    private void btn_PY_Delete_Click(object sender, EventArgs e)
    {
      if (dgv_Payments.CurrentRow == null) return;

      int id = Convert.ToInt32(dgv_Payments.CurrentRow.Cells["Id"].Value);

      var payment = _context.Payments.FirstOrDefault(p => p.Id == id);
      if (payment == null) return;

      if (MessageBox.Show("Delete payment?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
      {
        _context.Payments.Remove(payment);
        _context.SaveChanges();
        LoadPayments();
      }
    }

    private void btn_PY_Search_Click(object sender, EventArgs e)
    {
      if (!int.TryParse(tb_PY_SessionID.Text, out int sessionId))
      {
        LoadPayments();
        return;
      }

      dgv_Payments.DataSource = _context.Payments
          .Where(p => p.SessionId == sessionId)
          .Select(p => new
          {
            p.Id,
            p.SessionId,
            p.Amount,
            p.PaymentMethod,
            p.PaymentDate
          })
          .ToList();
    }
    private bool ValidatePayment()
    {
      if (!int.TryParse(tb_PY_SessionID.Text, out int sessionId))
      {
        MessageBox.Show("Invalid Session ID");
        return false;
      }

      if (sessionId <= 0)
      {
        MessageBox.Show("Session ID must be greater than 0");
        return false;
      }

      var sessionExists = _context.Sessions.Any(s => s.Id == sessionId);
      if (!sessionExists)
      {
        MessageBox.Show("Session does not exist");
        return false;
      }

      if (!decimal.TryParse(tb_PY_Amount.Text, out decimal amount))
      {
        MessageBox.Show("Invalid amount");
        return false;
      }

      if (amount <= 0)
      {
        MessageBox.Show("Amount must be greater than 0");
        return false;
      }

      string method = tb_PY_PaymentMethod.Text.Trim().ToLower();
      if (method != "cash" && method != "card")
      {
        MessageBox.Show("Payment method must be Cash or Card");
        return false;
      }

      return true;
    }
    private void LoadPayments()
    {
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
    }

    private void ClearPaymentFields()
    {
      tb_PY_SessionID.Clear();
      tb_PY_Amount.Clear();
      tb_PY_PaymentMethod.Clear();
    }

    private void btn_PY_Clear_Fields_Click(object sender, EventArgs e)
    {
      ClearPaymentFields();
    }
    // EXTRA CODE


  }
}