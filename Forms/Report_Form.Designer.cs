namespace Management_Internet_Cafe.Forms
{
  partial class Report_Form
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
      lb_Report = new Label();
      SpCt_Report_Form = new SplitContainer();
      lb_Export_Formats = new Label();
      lb_Selected_Tables = new Label();
      btn_Generate_Report = new Button();
      CLB_Export_Formats = new CheckedListBox();
      GB_Detail_Level = new GroupBox();
      RB_Advanced = new RadioButton();
      RB_Detailed = new RadioButton();
      RB_Basic = new RadioButton();
      CLB_Selected_Tables = new CheckedListBox();
      tb_Report_Preview = new TextBox();
      folderBrowserDialog1 = new FolderBrowserDialog();
      ((System.ComponentModel.ISupportInitialize)SpCt_Report_Form).BeginInit();
      SpCt_Report_Form.Panel1.SuspendLayout();
      SpCt_Report_Form.Panel2.SuspendLayout();
      SpCt_Report_Form.SuspendLayout();
      GB_Detail_Level.SuspendLayout();
      SuspendLayout();
      // 
      // lb_Report
      // 
      lb_Report.AutoSize = true;
      lb_Report.Font = new Font("Segoe UI", 14F);
      lb_Report.Location = new Point(133, 6);
      lb_Report.Name = "lb_Report";
      lb_Report.Size = new Size(156, 32);
      lb_Report.TabIndex = 0;
      lb_Report.Text = "Report Tables";
      // 
      // SpCt_Report_Form
      // 
      SpCt_Report_Form.Dock = DockStyle.Fill;
      SpCt_Report_Form.Location = new Point(0, 0);
      SpCt_Report_Form.Name = "SpCt_Report_Form";
      SpCt_Report_Form.Orientation = Orientation.Horizontal;
      // 
      // SpCt_Report_Form.Panel1
      // 
      SpCt_Report_Form.Panel1.Controls.Add(lb_Export_Formats);
      SpCt_Report_Form.Panel1.Controls.Add(lb_Selected_Tables);
      SpCt_Report_Form.Panel1.Controls.Add(btn_Generate_Report);
      SpCt_Report_Form.Panel1.Controls.Add(CLB_Export_Formats);
      SpCt_Report_Form.Panel1.Controls.Add(GB_Detail_Level);
      SpCt_Report_Form.Panel1.Controls.Add(CLB_Selected_Tables);
      SpCt_Report_Form.Panel1.Controls.Add(lb_Report);
      // 
      // SpCt_Report_Form.Panel2
      // 
      SpCt_Report_Form.Panel2.Controls.Add(tb_Report_Preview);
      SpCt_Report_Form.Size = new Size(486, 403);
      SpCt_Report_Form.SplitterDistance = 289;
      SpCt_Report_Form.TabIndex = 1;
      // 
      // lb_Export_Formats
      // 
      lb_Export_Formats.AutoSize = true;
      lb_Export_Formats.Font = new Font("Segoe UI", 12F);
      lb_Export_Formats.Location = new Point(331, 29);
      lb_Export_Formats.Name = "lb_Export_Formats";
      lb_Export_Formats.Size = new Size(145, 28);
      lb_Export_Formats.TabIndex = 6;
      lb_Export_Formats.Text = "Export Formats";
      // 
      // lb_Selected_Tables
      // 
      lb_Selected_Tables.AutoSize = true;
      lb_Selected_Tables.Font = new Font("Segoe UI", 12F);
      lb_Selected_Tables.Location = new Point(62, 29);
      lb_Selected_Tables.Name = "lb_Selected_Tables";
      lb_Selected_Tables.Size = new Size(65, 28);
      lb_Selected_Tables.TabIndex = 5;
      lb_Selected_Tables.Text = "Tables";
      // 
      // btn_Generate_Report
      // 
      btn_Generate_Report.Dock = DockStyle.Bottom;
      btn_Generate_Report.Font = new Font("Segoe UI", 14F);
      btn_Generate_Report.Location = new Point(0, 242);
      btn_Generate_Report.Name = "btn_Generate_Report";
      btn_Generate_Report.Size = new Size(486, 47);
      btn_Generate_Report.TabIndex = 4;
      btn_Generate_Report.Text = "Generate Report";
      btn_Generate_Report.UseVisualStyleBackColor = true;
      btn_Generate_Report.Click += btn_Generate_Report_Click;
      // 
      // CLB_Export_Formats
      // 
      CLB_Export_Formats.Font = new Font("Segoe UI", 12F);
      CLB_Export_Formats.FormattingEnabled = true;
      CLB_Export_Formats.Items.AddRange(new object[] { "TXT", "PDF", "EXCELL" });
      CLB_Export_Formats.Location = new Point(331, 60);
      CLB_Export_Formats.Name = "CLB_Export_Formats";
      CLB_Export_Formats.Size = new Size(145, 91);
      CLB_Export_Formats.TabIndex = 3;
      // 
      // GB_Detail_Level
      // 
      GB_Detail_Level.Controls.Add(RB_Advanced);
      GB_Detail_Level.Controls.Add(RB_Detailed);
      GB_Detail_Level.Controls.Add(RB_Basic);
      GB_Detail_Level.Font = new Font("Segoe UI", 12F);
      GB_Detail_Level.Location = new Point(175, 60);
      GB_Detail_Level.Name = "GB_Detail_Level";
      GB_Detail_Level.Size = new Size(150, 172);
      GB_Detail_Level.TabIndex = 2;
      GB_Detail_Level.TabStop = false;
      GB_Detail_Level.Text = "Level of Detail";
      // 
      // RB_Advanced
      // 
      RB_Advanced.AutoSize = true;
      RB_Advanced.Location = new Point(6, 86);
      RB_Advanced.Name = "RB_Advanced";
      RB_Advanced.Size = new Size(125, 60);
      RB_Advanced.TabIndex = 2;
      RB_Advanced.TabStop = true;
      RB_Advanced.Text = "Advanced \r\nStatistics";
      RB_Advanced.UseVisualStyleBackColor = true;
      // 
      // RB_Detailed
      // 
      RB_Detailed.AutoSize = true;
      RB_Detailed.Location = new Point(6, 56);
      RB_Detailed.Name = "RB_Detailed";
      RB_Detailed.Size = new Size(106, 32);
      RB_Detailed.TabIndex = 1;
      RB_Detailed.TabStop = true;
      RB_Detailed.Text = "Detailed";
      RB_Detailed.UseVisualStyleBackColor = true;
      // 
      // RB_Basic
      // 
      RB_Basic.AutoSize = true;
      RB_Basic.Location = new Point(6, 26);
      RB_Basic.Name = "RB_Basic";
      RB_Basic.Size = new Size(76, 32);
      RB_Basic.TabIndex = 0;
      RB_Basic.TabStop = true;
      RB_Basic.Text = "Basic";
      RB_Basic.UseVisualStyleBackColor = true;
      // 
      // CLB_Selected_Tables
      // 
      CLB_Selected_Tables.Font = new Font("Segoe UI", 12F);
      CLB_Selected_Tables.FormattingEnabled = true;
      CLB_Selected_Tables.Items.AddRange(new object[] { "Clients", "Computers", "Games", "Sessions", "SessionGames", "Payments" });
      CLB_Selected_Tables.Location = new Point(12, 60);
      CLB_Selected_Tables.Name = "CLB_Selected_Tables";
      CLB_Selected_Tables.Size = new Size(157, 178);
      CLB_Selected_Tables.TabIndex = 1;
      // 
      // tb_Report_Preview
      // 
      tb_Report_Preview.Dock = DockStyle.Fill;
      tb_Report_Preview.Location = new Point(0, 0);
      tb_Report_Preview.Multiline = true;
      tb_Report_Preview.Name = "tb_Report_Preview";
      tb_Report_Preview.PlaceholderText = "Report Preview Text Placeholder";
      tb_Report_Preview.ReadOnly = true;
      tb_Report_Preview.ScrollBars = ScrollBars.Vertical;
      tb_Report_Preview.Size = new Size(486, 110);
      tb_Report_Preview.TabIndex = 0;
      // 
      // Report_Form
      // 
      AutoScaleDimensions = new SizeF(8F, 20F);
      AutoScaleMode = AutoScaleMode.Font;
      ClientSize = new Size(486, 403);
      Controls.Add(SpCt_Report_Form);
      Name = "Report_Form";
      Text = "Report_Form";
      SpCt_Report_Form.Panel1.ResumeLayout(false);
      SpCt_Report_Form.Panel1.PerformLayout();
      SpCt_Report_Form.Panel2.ResumeLayout(false);
      SpCt_Report_Form.Panel2.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)SpCt_Report_Form).EndInit();
      SpCt_Report_Form.ResumeLayout(false);
      GB_Detail_Level.ResumeLayout(false);
      GB_Detail_Level.PerformLayout();
      ResumeLayout(false);
    }

    #endregion

    private Label lb_Report;
    private SplitContainer SpCt_Report_Form;
    private FolderBrowserDialog folderBrowserDialog1;
    private CheckedListBox CLB_Selected_Tables;
    private Button btn_Generate_Report;
    private CheckedListBox CLB_Export_Formats;
    private GroupBox GB_Detail_Level;
    private RadioButton RB_Advanced;
    private RadioButton RB_Detailed;
    private RadioButton RB_Basic;
    private TextBox tb_Report_Preview;
    private Label lb_Export_Formats;
    private Label lb_Selected_Tables;
  }
}