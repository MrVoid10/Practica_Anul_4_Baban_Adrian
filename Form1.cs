using Management_Internet_Cafe.Data;

namespace Management_Internet_Cafe
{
  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();
    }

    private void Form1_Load(object sender, EventArgs e)
    {
      try
      {
        using (var db = new AppDbContext())
        {
          bool canConnect = db.Database.CanConnect();
          MessageBox.Show(canConnect ? "Database connected!" : "Connection failed!");
        }
      }
      catch (Exception ex)
      {
        MessageBox.Show("Error: " + ex.Message);
      }
    }
  }
}
