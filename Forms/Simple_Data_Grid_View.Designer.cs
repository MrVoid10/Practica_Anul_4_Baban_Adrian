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
      splitC_Clients = new SplitContainer();
      dgv_Clients = new DataGridView();
      btn_Search = new Button();
      btn_Delete = new Button();
      btn_Edit = new Button();
      btn_ADD = new Button();
      tb_Email = new TextBox();
      tb_Phone = new TextBox();
      tb_LastName = new TextBox();
      tb_FirstName = new TextBox();
      tab_Calculator = new TabPage();
      splitContainer1 = new SplitContainer();
      dgv_Computers = new DataGridView();
      button1 = new Button();
      button2 = new Button();
      button3 = new Button();
      button4 = new Button();
      tb_Specifications = new TextBox();
      tb_Status = new TextBox();
      tb_PcNumber = new TextBox();
      tab_Game = new TabPage();
      splitContainer2 = new SplitContainer();
      dgv_Games = new DataGridView();
      button5 = new Button();
      button6 = new Button();
      button7 = new Button();
      button8 = new Button();
      tb_Game_Genre = new TextBox();
      tb_Game_Name = new TextBox();
      tab_Session_Games = new TabPage();
      splitContainer3 = new SplitContainer();
      dgv_Session_Game = new DataGridView();
      button9 = new Button();
      button10 = new Button();
      button11 = new Button();
      button12 = new Button();
      textBox1 = new TextBox();
      textBox2 = new TextBox();
      textBox3 = new TextBox();
      textBox4 = new TextBox();
      tab_Payment = new TabPage();
      splitContainer4 = new SplitContainer();
      dgv_Payments = new DataGridView();
      appDbContextBindingSource = new BindingSource(components);
      appDbContextBindingSource1 = new BindingSource(components);
      button13 = new Button();
      button14 = new Button();
      button15 = new Button();
      button16 = new Button();
      textBox5 = new TextBox();
      textBox6 = new TextBox();
      textBox7 = new TextBox();
      textBox8 = new TextBox();
      textBox9 = new TextBox();
      tabControl_Test_Tabels.SuspendLayout();
      tab_Client.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)splitC_Clients).BeginInit();
      splitC_Clients.Panel1.SuspendLayout();
      splitC_Clients.Panel2.SuspendLayout();
      splitC_Clients.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)dgv_Clients).BeginInit();
      tab_Calculator.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
      splitContainer1.Panel1.SuspendLayout();
      splitContainer1.Panel2.SuspendLayout();
      splitContainer1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)dgv_Computers).BeginInit();
      tab_Game.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
      splitContainer2.Panel1.SuspendLayout();
      splitContainer2.Panel2.SuspendLayout();
      splitContainer2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)dgv_Games).BeginInit();
      tab_Session_Games.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)splitContainer3).BeginInit();
      splitContainer3.Panel1.SuspendLayout();
      splitContainer3.Panel2.SuspendLayout();
      splitContainer3.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)dgv_Session_Game).BeginInit();
      tab_Payment.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)splitContainer4).BeginInit();
      splitContainer4.Panel1.SuspendLayout();
      splitContainer4.Panel2.SuspendLayout();
      splitContainer4.SuspendLayout();
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
      tabControl_Test_Tabels.Dock = DockStyle.Fill;
      tabControl_Test_Tabels.Location = new Point(0, 0);
      tabControl_Test_Tabels.Name = "tabControl_Test_Tabels";
      tabControl_Test_Tabels.SelectedIndex = 0;
      tabControl_Test_Tabels.Size = new Size(942, 533);
      tabControl_Test_Tabels.TabIndex = 0;
      // 
      // tab_Client
      // 
      tab_Client.Controls.Add(splitC_Clients);
      tab_Client.Location = new Point(4, 29);
      tab_Client.Name = "tab_Client";
      tab_Client.Padding = new Padding(3);
      tab_Client.Size = new Size(934, 500);
      tab_Client.TabIndex = 0;
      tab_Client.Text = "Clients";
      tab_Client.UseVisualStyleBackColor = true;
      // 
      // splitC_Clients
      // 
      splitC_Clients.Dock = DockStyle.Fill;
      splitC_Clients.Location = new Point(3, 3);
      splitC_Clients.Name = "splitC_Clients";
      // 
      // splitC_Clients.Panel1
      // 
      splitC_Clients.Panel1.Controls.Add(dgv_Clients);
      // 
      // splitC_Clients.Panel2
      // 
      splitC_Clients.Panel2.Controls.Add(btn_Search);
      splitC_Clients.Panel2.Controls.Add(btn_Delete);
      splitC_Clients.Panel2.Controls.Add(btn_Edit);
      splitC_Clients.Panel2.Controls.Add(btn_ADD);
      splitC_Clients.Panel2.Controls.Add(tb_Email);
      splitC_Clients.Panel2.Controls.Add(tb_Phone);
      splitC_Clients.Panel2.Controls.Add(tb_LastName);
      splitC_Clients.Panel2.Controls.Add(tb_FirstName);
      splitC_Clients.Size = new Size(928, 494);
      splitC_Clients.SplitterDistance = 621;
      splitC_Clients.TabIndex = 1;
      // 
      // dgv_Clients
      // 
      dgv_Clients.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      dgv_Clients.Dock = DockStyle.Fill;
      dgv_Clients.Location = new Point(0, 0);
      dgv_Clients.Name = "dgv_Clients";
      dgv_Clients.RowHeadersWidth = 51;
      dgv_Clients.Size = new Size(621, 494);
      dgv_Clients.TabIndex = 0;
      // 
      // btn_Search
      // 
      btn_Search.Location = new Point(120, 148);
      btn_Search.Name = "btn_Search";
      btn_Search.Size = new Size(94, 29);
      btn_Search.TabIndex = 7;
      btn_Search.Text = "Search";
      btn_Search.UseVisualStyleBackColor = true;
      // 
      // btn_Delete
      // 
      btn_Delete.Location = new Point(20, 148);
      btn_Delete.Name = "btn_Delete";
      btn_Delete.Size = new Size(94, 29);
      btn_Delete.TabIndex = 6;
      btn_Delete.Text = "Delete";
      btn_Delete.UseVisualStyleBackColor = true;
      // 
      // btn_Edit
      // 
      btn_Edit.Location = new Point(120, 113);
      btn_Edit.Name = "btn_Edit";
      btn_Edit.Size = new Size(94, 29);
      btn_Edit.TabIndex = 5;
      btn_Edit.Text = "Edit";
      btn_Edit.UseVisualStyleBackColor = true;
      // 
      // btn_ADD
      // 
      btn_ADD.Location = new Point(20, 113);
      btn_ADD.Name = "btn_ADD";
      btn_ADD.Size = new Size(94, 29);
      btn_ADD.TabIndex = 4;
      btn_ADD.Text = "Add";
      btn_ADD.UseVisualStyleBackColor = true;
      // 
      // tb_Email
      // 
      tb_Email.Location = new Point(151, 51);
      tb_Email.Name = "tb_Email";
      tb_Email.PlaceholderText = "Email";
      tb_Email.Size = new Size(125, 27);
      tb_Email.TabIndex = 3;
      // 
      // tb_Phone
      // 
      tb_Phone.Location = new Point(20, 51);
      tb_Phone.Name = "tb_Phone";
      tb_Phone.PlaceholderText = "Phone Number";
      tb_Phone.Size = new Size(125, 27);
      tb_Phone.TabIndex = 2;
      // 
      // tb_LastName
      // 
      tb_LastName.Location = new Point(151, 18);
      tb_LastName.Name = "tb_LastName";
      tb_LastName.PlaceholderText = "Last Name";
      tb_LastName.Size = new Size(125, 27);
      tb_LastName.TabIndex = 1;
      // 
      // tb_FirstName
      // 
      tb_FirstName.Location = new Point(20, 18);
      tb_FirstName.Name = "tb_FirstName";
      tb_FirstName.PlaceholderText = "First Name";
      tb_FirstName.Size = new Size(125, 27);
      tb_FirstName.TabIndex = 0;
      // 
      // tab_Calculator
      // 
      tab_Calculator.Controls.Add(splitContainer1);
      tab_Calculator.Location = new Point(4, 29);
      tab_Calculator.Name = "tab_Calculator";
      tab_Calculator.Padding = new Padding(3);
      tab_Calculator.Size = new Size(934, 500);
      tab_Calculator.TabIndex = 1;
      tab_Calculator.Text = "Computers";
      tab_Calculator.UseVisualStyleBackColor = true;
      // 
      // splitContainer1
      // 
      splitContainer1.Dock = DockStyle.Fill;
      splitContainer1.Location = new Point(3, 3);
      splitContainer1.Name = "splitContainer1";
      // 
      // splitContainer1.Panel1
      // 
      splitContainer1.Panel1.Controls.Add(dgv_Computers);
      // 
      // splitContainer1.Panel2
      // 
      splitContainer1.Panel2.Controls.Add(button1);
      splitContainer1.Panel2.Controls.Add(button2);
      splitContainer1.Panel2.Controls.Add(button3);
      splitContainer1.Panel2.Controls.Add(button4);
      splitContainer1.Panel2.Controls.Add(tb_Specifications);
      splitContainer1.Panel2.Controls.Add(tb_Status);
      splitContainer1.Panel2.Controls.Add(tb_PcNumber);
      splitContainer1.Size = new Size(928, 494);
      splitContainer1.SplitterDistance = 621;
      splitContainer1.TabIndex = 2;
      // 
      // dgv_Computers
      // 
      dgv_Computers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      dgv_Computers.Dock = DockStyle.Fill;
      dgv_Computers.Location = new Point(0, 0);
      dgv_Computers.Name = "dgv_Computers";
      dgv_Computers.RowHeadersWidth = 51;
      dgv_Computers.Size = new Size(621, 494);
      dgv_Computers.TabIndex = 1;
      // 
      // button1
      // 
      button1.Location = new Point(118, 151);
      button1.Name = "button1";
      button1.Size = new Size(94, 29);
      button1.TabIndex = 15;
      button1.Text = "Search";
      button1.UseVisualStyleBackColor = true;
      // 
      // button2
      // 
      button2.Location = new Point(18, 151);
      button2.Name = "button2";
      button2.Size = new Size(94, 29);
      button2.TabIndex = 14;
      button2.Text = "Delete";
      button2.UseVisualStyleBackColor = true;
      // 
      // button3
      // 
      button3.Location = new Point(118, 116);
      button3.Name = "button3";
      button3.Size = new Size(94, 29);
      button3.TabIndex = 13;
      button3.Text = "Edit";
      button3.UseVisualStyleBackColor = true;
      // 
      // button4
      // 
      button4.Location = new Point(18, 116);
      button4.Name = "button4";
      button4.Size = new Size(94, 29);
      button4.TabIndex = 12;
      button4.Text = "Add";
      button4.UseVisualStyleBackColor = true;
      // 
      // tb_Specifications
      // 
      tb_Specifications.Location = new Point(18, 54);
      tb_Specifications.Multiline = true;
      tb_Specifications.Name = "tb_Specifications";
      tb_Specifications.PlaceholderText = "Specifications";
      tb_Specifications.Size = new Size(256, 56);
      tb_Specifications.TabIndex = 10;
      // 
      // tb_Status
      // 
      tb_Status.Location = new Point(149, 21);
      tb_Status.Name = "tb_Status";
      tb_Status.PlaceholderText = "Status";
      tb_Status.Size = new Size(125, 27);
      tb_Status.TabIndex = 9;
      // 
      // tb_PcNumber
      // 
      tb_PcNumber.Location = new Point(18, 21);
      tb_PcNumber.Name = "tb_PcNumber";
      tb_PcNumber.PlaceholderText = "PC Number";
      tb_PcNumber.Size = new Size(125, 27);
      tb_PcNumber.TabIndex = 8;
      // 
      // tab_Game
      // 
      tab_Game.Controls.Add(splitContainer2);
      tab_Game.Location = new Point(4, 29);
      tab_Game.Name = "tab_Game";
      tab_Game.Padding = new Padding(3);
      tab_Game.Size = new Size(934, 500);
      tab_Game.TabIndex = 2;
      tab_Game.Text = "Games";
      tab_Game.UseVisualStyleBackColor = true;
      // 
      // splitContainer2
      // 
      splitContainer2.Dock = DockStyle.Fill;
      splitContainer2.Location = new Point(3, 3);
      splitContainer2.Name = "splitContainer2";
      // 
      // splitContainer2.Panel1
      // 
      splitContainer2.Panel1.Controls.Add(dgv_Games);
      // 
      // splitContainer2.Panel2
      // 
      splitContainer2.Panel2.Controls.Add(button5);
      splitContainer2.Panel2.Controls.Add(button6);
      splitContainer2.Panel2.Controls.Add(button7);
      splitContainer2.Panel2.Controls.Add(button8);
      splitContainer2.Panel2.Controls.Add(tb_Game_Genre);
      splitContainer2.Panel2.Controls.Add(tb_Game_Name);
      splitContainer2.Size = new Size(928, 494);
      splitContainer2.SplitterDistance = 619;
      splitContainer2.TabIndex = 3;
      // 
      // dgv_Games
      // 
      dgv_Games.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      dgv_Games.Dock = DockStyle.Fill;
      dgv_Games.Location = new Point(0, 0);
      dgv_Games.Name = "dgv_Games";
      dgv_Games.RowHeadersWidth = 51;
      dgv_Games.Size = new Size(619, 494);
      dgv_Games.TabIndex = 2;
      // 
      // button5
      // 
      button5.Location = new Point(118, 149);
      button5.Name = "button5";
      button5.Size = new Size(94, 29);
      button5.TabIndex = 22;
      button5.Text = "Search";
      button5.UseVisualStyleBackColor = true;
      // 
      // button6
      // 
      button6.Location = new Point(18, 149);
      button6.Name = "button6";
      button6.Size = new Size(94, 29);
      button6.TabIndex = 21;
      button6.Text = "Delete";
      button6.UseVisualStyleBackColor = true;
      // 
      // button7
      // 
      button7.Location = new Point(118, 114);
      button7.Name = "button7";
      button7.Size = new Size(94, 29);
      button7.TabIndex = 20;
      button7.Text = "Edit";
      button7.UseVisualStyleBackColor = true;
      // 
      // button8
      // 
      button8.Location = new Point(18, 114);
      button8.Name = "button8";
      button8.Size = new Size(94, 29);
      button8.TabIndex = 19;
      button8.Text = "Add";
      button8.UseVisualStyleBackColor = true;
      // 
      // tb_Game_Genre
      // 
      tb_Game_Genre.Location = new Point(149, 19);
      tb_Game_Genre.Name = "tb_Game_Genre";
      tb_Game_Genre.PlaceholderText = "Genre";
      tb_Game_Genre.Size = new Size(125, 27);
      tb_Game_Genre.TabIndex = 17;
      // 
      // tb_Game_Name
      // 
      tb_Game_Name.Location = new Point(18, 19);
      tb_Game_Name.Name = "tb_Game_Name";
      tb_Game_Name.PlaceholderText = "Name";
      tb_Game_Name.Size = new Size(125, 27);
      tb_Game_Name.TabIndex = 16;
      // 
      // tab_Session_Games
      // 
      tab_Session_Games.Controls.Add(splitContainer3);
      tab_Session_Games.Location = new Point(4, 29);
      tab_Session_Games.Name = "tab_Session_Games";
      tab_Session_Games.Padding = new Padding(3);
      tab_Session_Games.Size = new Size(934, 500);
      tab_Session_Games.TabIndex = 3;
      tab_Session_Games.Text = "Session Games";
      tab_Session_Games.UseVisualStyleBackColor = true;
      // 
      // splitContainer3
      // 
      splitContainer3.Dock = DockStyle.Fill;
      splitContainer3.Location = new Point(3, 3);
      splitContainer3.Name = "splitContainer3";
      // 
      // splitContainer3.Panel1
      // 
      splitContainer3.Panel1.Controls.Add(dgv_Session_Game);
      // 
      // splitContainer3.Panel2
      // 
      splitContainer3.Panel2.Controls.Add(button9);
      splitContainer3.Panel2.Controls.Add(button10);
      splitContainer3.Panel2.Controls.Add(button11);
      splitContainer3.Panel2.Controls.Add(button12);
      splitContainer3.Panel2.Controls.Add(textBox1);
      splitContainer3.Panel2.Controls.Add(textBox2);
      splitContainer3.Panel2.Controls.Add(textBox3);
      splitContainer3.Panel2.Controls.Add(textBox4);
      splitContainer3.Size = new Size(928, 494);
      splitContainer3.SplitterDistance = 619;
      splitContainer3.TabIndex = 3;
      // 
      // dgv_Session_Game
      // 
      dgv_Session_Game.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      dgv_Session_Game.Dock = DockStyle.Fill;
      dgv_Session_Game.Location = new Point(0, 0);
      dgv_Session_Game.Name = "dgv_Session_Game";
      dgv_Session_Game.RowHeadersWidth = 51;
      dgv_Session_Game.Size = new Size(619, 494);
      dgv_Session_Game.TabIndex = 2;
      // 
      // button9
      // 
      button9.Location = new Point(124, 147);
      button9.Name = "button9";
      button9.Size = new Size(94, 29);
      button9.TabIndex = 15;
      button9.Text = "Search";
      button9.UseVisualStyleBackColor = true;
      // 
      // button10
      // 
      button10.Location = new Point(24, 147);
      button10.Name = "button10";
      button10.Size = new Size(94, 29);
      button10.TabIndex = 14;
      button10.Text = "Delete";
      button10.UseVisualStyleBackColor = true;
      // 
      // button11
      // 
      button11.Location = new Point(124, 112);
      button11.Name = "button11";
      button11.Size = new Size(94, 29);
      button11.TabIndex = 13;
      button11.Text = "Edit";
      button11.UseVisualStyleBackColor = true;
      // 
      // button12
      // 
      button12.Location = new Point(24, 112);
      button12.Name = "button12";
      button12.Size = new Size(94, 29);
      button12.TabIndex = 12;
      button12.Text = "Add";
      button12.UseVisualStyleBackColor = true;
      // 
      // textBox1
      // 
      textBox1.Location = new Point(155, 50);
      textBox1.Name = "textBox1";
      textBox1.PlaceholderText = "Game";
      textBox1.Size = new Size(125, 27);
      textBox1.TabIndex = 11;
      // 
      // textBox2
      // 
      textBox2.Location = new Point(24, 50);
      textBox2.Name = "textBox2";
      textBox2.PlaceholderText = "Session";
      textBox2.Size = new Size(125, 27);
      textBox2.TabIndex = 10;
      // 
      // textBox3
      // 
      textBox3.Location = new Point(155, 17);
      textBox3.Name = "textBox3";
      textBox3.PlaceholderText = "GameId";
      textBox3.Size = new Size(125, 27);
      textBox3.TabIndex = 9;
      // 
      // textBox4
      // 
      textBox4.Location = new Point(24, 17);
      textBox4.Name = "textBox4";
      textBox4.PlaceholderText = "SessionId";
      textBox4.Size = new Size(125, 27);
      textBox4.TabIndex = 8;
      // 
      // tab_Payment
      // 
      tab_Payment.Controls.Add(splitContainer4);
      tab_Payment.Location = new Point(4, 29);
      tab_Payment.Name = "tab_Payment";
      tab_Payment.Padding = new Padding(3);
      tab_Payment.Size = new Size(934, 500);
      tab_Payment.TabIndex = 4;
      tab_Payment.Text = "Payments";
      tab_Payment.UseVisualStyleBackColor = true;
      // 
      // splitContainer4
      // 
      splitContainer4.Dock = DockStyle.Fill;
      splitContainer4.Location = new Point(3, 3);
      splitContainer4.Name = "splitContainer4";
      // 
      // splitContainer4.Panel1
      // 
      splitContainer4.Panel1.Controls.Add(dgv_Payments);
      // 
      // splitContainer4.Panel2
      // 
      splitContainer4.Panel2.Controls.Add(textBox9);
      splitContainer4.Panel2.Controls.Add(button13);
      splitContainer4.Panel2.Controls.Add(button14);
      splitContainer4.Panel2.Controls.Add(button15);
      splitContainer4.Panel2.Controls.Add(button16);
      splitContainer4.Panel2.Controls.Add(textBox5);
      splitContainer4.Panel2.Controls.Add(textBox6);
      splitContainer4.Panel2.Controls.Add(textBox7);
      splitContainer4.Panel2.Controls.Add(textBox8);
      splitContainer4.Size = new Size(928, 494);
      splitContainer4.SplitterDistance = 619;
      splitContainer4.TabIndex = 3;
      // 
      // dgv_Payments
      // 
      dgv_Payments.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      dgv_Payments.Dock = DockStyle.Fill;
      dgv_Payments.Location = new Point(0, 0);
      dgv_Payments.Name = "dgv_Payments";
      dgv_Payments.RowHeadersWidth = 51;
      dgv_Payments.Size = new Size(619, 494);
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
      // button13
      // 
      button13.Location = new Point(123, 198);
      button13.Name = "button13";
      button13.Size = new Size(94, 29);
      button13.TabIndex = 15;
      button13.Text = "Search";
      button13.UseVisualStyleBackColor = true;
      // 
      // button14
      // 
      button14.Location = new Point(23, 198);
      button14.Name = "button14";
      button14.Size = new Size(94, 29);
      button14.TabIndex = 14;
      button14.Text = "Delete";
      button14.UseVisualStyleBackColor = true;
      // 
      // button15
      // 
      button15.Location = new Point(123, 163);
      button15.Name = "button15";
      button15.Size = new Size(94, 29);
      button15.TabIndex = 13;
      button15.Text = "Edit";
      button15.UseVisualStyleBackColor = true;
      // 
      // button16
      // 
      button16.Location = new Point(23, 163);
      button16.Name = "button16";
      button16.Size = new Size(94, 29);
      button16.TabIndex = 12;
      button16.Text = "Add";
      button16.UseVisualStyleBackColor = true;
      // 
      // textBox5
      // 
      textBox5.Location = new Point(154, 64);
      textBox5.Name = "textBox5";
      textBox5.PlaceholderText = "PaymentDate";
      textBox5.Size = new Size(125, 27);
      textBox5.TabIndex = 11;
      // 
      // textBox6
      // 
      textBox6.Location = new Point(23, 64);
      textBox6.Name = "textBox6";
      textBox6.PlaceholderText = "PaymentMethod";
      textBox6.Size = new Size(125, 27);
      textBox6.TabIndex = 10;
      // 
      // textBox7
      // 
      textBox7.Location = new Point(154, 31);
      textBox7.Name = "textBox7";
      textBox7.PlaceholderText = "Amount";
      textBox7.Size = new Size(125, 27);
      textBox7.TabIndex = 9;
      // 
      // textBox8
      // 
      textBox8.Location = new Point(23, 31);
      textBox8.Name = "textBox8";
      textBox8.PlaceholderText = "SessionId";
      textBox8.Size = new Size(125, 27);
      textBox8.TabIndex = 8;
      // 
      // textBox9
      // 
      textBox9.Location = new Point(23, 97);
      textBox9.Name = "textBox9";
      textBox9.PlaceholderText = "Session";
      textBox9.Size = new Size(125, 27);
      textBox9.TabIndex = 16;
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
      splitC_Clients.Panel1.ResumeLayout(false);
      splitC_Clients.Panel2.ResumeLayout(false);
      splitC_Clients.Panel2.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)splitC_Clients).EndInit();
      splitC_Clients.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)dgv_Clients).EndInit();
      tab_Calculator.ResumeLayout(false);
      splitContainer1.Panel1.ResumeLayout(false);
      splitContainer1.Panel2.ResumeLayout(false);
      splitContainer1.Panel2.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
      splitContainer1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)dgv_Computers).EndInit();
      tab_Game.ResumeLayout(false);
      splitContainer2.Panel1.ResumeLayout(false);
      splitContainer2.Panel2.ResumeLayout(false);
      splitContainer2.Panel2.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
      splitContainer2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)dgv_Games).EndInit();
      tab_Session_Games.ResumeLayout(false);
      splitContainer3.Panel1.ResumeLayout(false);
      splitContainer3.Panel2.ResumeLayout(false);
      splitContainer3.Panel2.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)splitContainer3).EndInit();
      splitContainer3.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)dgv_Session_Game).EndInit();
      tab_Payment.ResumeLayout(false);
      splitContainer4.Panel1.ResumeLayout(false);
      splitContainer4.Panel2.ResumeLayout(false);
      splitContainer4.Panel2.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)splitContainer4).EndInit();
      splitContainer4.ResumeLayout(false);
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
    private SplitContainer splitC_Clients;
    private SplitContainer splitContainer1;
    private SplitContainer splitContainer2;
    private SplitContainer splitContainer3;
    private SplitContainer splitContainer4;
    private TextBox tb_FirstName;
    private TextBox tb_LastName;
    private TextBox tb_Phone;
    private TextBox tb_Email;
    private Button btn_Search;
    private Button btn_Delete;
    private Button btn_Edit;
    private Button btn_ADD;
    private Button button1;
    private Button button2;
    private Button button3;
    private Button button4;
    private TextBox tb_Specifications;
    private TextBox tb_Status;
    private TextBox tb_PcNumber;
    private Button button5;
    private Button button6;
    private Button button7;
    private Button button8;
    private TextBox tb_Game_Genre;
    private TextBox tb_Game_Name;
    private Button button9;
    private Button button10;
    private Button button11;
    private Button button12;
    private TextBox textBox1;
    private TextBox textBox2;
    private TextBox textBox3;
    private TextBox textBox4;
    private TextBox textBox9;
    private Button button13;
    private Button button14;
    private Button button15;
    private Button button16;
    private TextBox textBox5;
    private TextBox textBox6;
    private TextBox textBox7;
    private TextBox textBox8;
  }
}