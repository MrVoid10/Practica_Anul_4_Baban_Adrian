namespace Management_Internet_Cafe.Forms
{
  partial class Simple_Data_Grid_View
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      components = new System.ComponentModel.Container();
      tabControl_Test_Tabels = new TabControl();
      tab_Client = new TabPage();
      dgv_Clients = new DataGridView();
      tab_Calculator = new TabPage();
      dgv_Computers = new DataGridView();
      tab_Game = new TabPage();
      dgv_Games = new DataGridView();
      tab_Session_Games = new TabPage();
      dgv_Session_Game = new DataGridView();
      tab_Payment = new TabPage();
      dgv_Payments = new DataGridView();
      appDbContextBindingSource = new BindingSource(components);
      appDbContextBindingSource1 = new BindingSource(components);
      tabControl_Test_Tabels.SuspendLayout();
      tab_Client.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)dgv_Clients).BeginInit();
      tab_Calculator.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)dgv_Computers).BeginInit();
      tab_Game.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)dgv_Games).BeginInit();
      tab_Session_Games.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)dgv_Session_Game).BeginInit();
      tab_Payment.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)dgv_Payments).BeginInit();
      ((System.ComponentModel.ISupportInitialize)appDbContextBindingSource).BeginInit();
      ((System.ComponentModel.ISupportInitialize)appDbContextBindingSource1).BeginInit();
      SuspendLayout();
      // 
      // tabControl_Test_Tabels
      // 
      tabControl_Test_Tabels.Controls.Add(tab_Client);
      tabControl_Test_Tabels.Controls.Add(tab_Calculator);
      tabControl_Test_Tabels.Controls.Add(tab_Game);
      tabControl_Test_Tabels.Controls.Add(tab_Session_Games);
      tabControl_Test_Tabels.Controls.Add(tab_Payment);
      tabControl_Test_Tabels.Location = new Point(0, 0);
      tabControl_Test_Tabels.Name = "tabControl_Test_Tabels";
      tabControl_Test_Tabels.SelectedIndex = 0;
      tabControl_Test_Tabels.Size = new Size(960, 540);
      tabControl_Test_Tabels.TabIndex = 0;
      // 
      // tab_Client
      // 
      tab_Client.Controls.Add(dgv_Clients);
      tab_Client.Location = new Point(4, 29);
      tab_Client.Name = "tab_Client";
      tab_Client.Padding = new Padding(3);
      tab_Client.Size = new Size(952, 507);
      tab_Client.TabIndex = 0;
      tab_Client.Text = "Clients";
      tab_Client.UseVisualStyleBackColor = true;
      // 
      // dgv_Clients
      // 
      dgv_Clients.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      dgv_Clients.Dock = DockStyle.Fill;
      dgv_Clients.Location = new Point(3, 3);
      dgv_Clients.Name = "dgv_Clients";
      dgv_Clients.RowHeadersWidth = 51;
      dgv_Clients.Size = new Size(946, 501);
      dgv_Clients.TabIndex = 0;
      // 
      // tab_Calculator
      // 
      tab_Calculator.Controls.Add(dgv_Computers);
      tab_Calculator.Location = new Point(4, 29);
      tab_Calculator.Name = "tab_Calculator";
      tab_Calculator.Padding = new Padding(3);
      tab_Calculator.Size = new Size(952, 507);
      tab_Calculator.TabIndex = 1;
      tab_Calculator.Text = "Computers";
      tab_Calculator.UseVisualStyleBackColor = true;
      // 
      // dgv_Computers
      // 
      dgv_Computers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      dgv_Computers.Dock = DockStyle.Fill;
      dgv_Computers.Location = new Point(3, 3);
      dgv_Computers.Name = "dgv_Computers";
      dgv_Computers.RowHeadersWidth = 51;
      dgv_Computers.Size = new Size(946, 501);
      dgv_Computers.TabIndex = 1;
      // 
      // tab_Game
      // 
      tab_Game.Controls.Add(dgv_Games);
      tab_Game.Location = new Point(4, 29);
      tab_Game.Name = "tab_Game";
      tab_Game.Padding = new Padding(3);
      tab_Game.Size = new Size(952, 507);
      tab_Game.TabIndex = 2;
      tab_Game.Text = "Games";
      tab_Game.UseVisualStyleBackColor = true;
      // 
      // dgv_Games
      // 
      dgv_Games.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      dgv_Games.Dock = DockStyle.Fill;
      dgv_Games.Location = new Point(3, 3);
      dgv_Games.Name = "dgv_Games";
      dgv_Games.RowHeadersWidth = 51;
      dgv_Games.Size = new Size(946, 501);
      dgv_Games.TabIndex = 2;
      // 
      // tab_Session_Games
      // 
      tab_Session_Games.Controls.Add(dgv_Session_Game);
      tab_Session_Games.Location = new Point(4, 29);
      tab_Session_Games.Name = "tab_Session_Games";
      tab_Session_Games.Padding = new Padding(3);
      tab_Session_Games.Size = new Size(952, 507);
      tab_Session_Games.TabIndex = 3;
      tab_Session_Games.Text = "Session Games";
      tab_Session_Games.UseVisualStyleBackColor = true;
      // 
      // dgv_Session_Game
      // 
      dgv_Session_Game.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      dgv_Session_Game.Dock = DockStyle.Fill;
      dgv_Session_Game.Location = new Point(3, 3);
      dgv_Session_Game.Name = "dgv_Session_Game";
      dgv_Session_Game.RowHeadersWidth = 51;
      dgv_Session_Game.Size = new Size(946, 501);
      dgv_Session_Game.TabIndex = 2;
      // 
      // tab_Payment
      // 
      tab_Payment.Controls.Add(dgv_Payments);
      tab_Payment.Location = new Point(4, 29);
      tab_Payment.Name = "tab_Payment";
      tab_Payment.Padding = new Padding(3);
      tab_Payment.Size = new Size(952, 507);
      tab_Payment.TabIndex = 4;
      tab_Payment.Text = "Payments";
      tab_Payment.UseVisualStyleBackColor = true;
      // 
      // dgv_Payments
      // 
      dgv_Payments.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      dgv_Payments.Dock = DockStyle.Fill;
      dgv_Payments.Location = new Point(3, 3);
      dgv_Payments.Name = "dgv_Payments";
      dgv_Payments.RowHeadersWidth = 51;
      dgv_Payments.Size = new Size(946, 501);
      dgv_Payments.TabIndex = 2;
      // 
      // appDbContextBindingSource
      // 
      appDbContextBindingSource.DataSource = typeof(Data.AppDbContext);
      // 
      // appDbContextBindingSource1
      // 
      appDbContextBindingSource1.DataSource = typeof(Data.AppDbContext);
      // 
      // Simple_Data_Grid_View
      // 
      AutoScaleDimensions = new SizeF(8F, 20F);
      AutoScaleMode = AutoScaleMode.Font;
      ClientSize = new Size(942, 533);
      Controls.Add(tabControl_Test_Tabels);
      Name = "Simple_Data_Grid_View";
      Text = "Simple_Data_Grid_View";
      Load += Simple_Data_Grid_View_Load;
      tabControl_Test_Tabels.ResumeLayout(false);
      tab_Client.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)dgv_Clients).EndInit();
      tab_Calculator.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)dgv_Computers).EndInit();
      tab_Game.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)dgv_Games).EndInit();
      tab_Session_Games.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)dgv_Session_Game).EndInit();
      tab_Payment.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)dgv_Payments).EndInit();
      ((System.ComponentModel.ISupportInitialize)appDbContextBindingSource).EndInit();
      ((System.ComponentModel.ISupportInitialize)appDbContextBindingSource1).EndInit();
      ResumeLayout(false);
    }

    #endregion

    private TabControl tabControl_Test_Tabels;
    private TabPage tab_Client;
    private TabPage tab_Calculator;
    private TabPage tab_Game;
    private TabPage tab_Session_Games;
    private TabPage tab_Payment;
    private DataGridView dgv_Clients;
    private DataGridView dgv_Computers;
    private DataGridView dgv_Games;
    private DataGridView dgv_Session_Game;
    private DataGridView dgv_Payments;
    private BindingSource appDbContextBindingSource;
    private BindingSource appDbContextBindingSource1;
  }
}