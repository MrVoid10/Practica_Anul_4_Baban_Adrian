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
      
    }

    private void btn_Load_Test_Tables_Click(object sender, EventArgs e)
    {
      Simple_Data_Grid_View form = new Simple_Data_Grid_View();
      form.ShowDialog();
    }
  }
}