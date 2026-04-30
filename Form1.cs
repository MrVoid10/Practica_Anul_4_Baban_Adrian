using Management_Internet_Cafe.Data;
using Management_Internet_Cafe.Forms;

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
          if (db.Database.CanConnect())
          {
            MessageBox.Show("Database connected!");
            DatabaseInitializer.Initialize(); // initialize db
          }
          else
          {
            MessageBox.Show("Connection failed!.");
          }
        }
      }
      catch (Exception ex)
      {
        MessageBox.Show("Database error: " + ex.Message);
      }
      //try
      //{
      //  using (var db = new AppDbContext())
      //  {
      //    bool canConnect = db.Database.CanConnect();
      //    MessageBox.Show(canConnect ? "Database connected!" : "Connection failed!");
      //  }
      //}
      //catch (Exception ex)
      //{
      //  MessageBox.Show("Error: " + ex.Message);
      //}
    }

    private void btn_Load_Test_Tables_Click(object sender, EventArgs e)
    {
      Simple_Data_Grid_View form = new Simple_Data_Grid_View();
      form.ShowDialog();
    }
  }
}