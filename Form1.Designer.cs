namespace Management_Internet_Cafe
{
  partial class Form1
  {
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      lb_Tables = new Label();
      btn_Load_Test_Tables = new Button();
      btn_Repor_Form = new Button();
      lb_Report_Form = new Label();
      SuspendLayout();
      // 
      // lb_Tables
      // 
      lb_Tables.AutoSize = true;
      lb_Tables.Dock = DockStyle.Left;
      lb_Tables.Font = new Font("Segoe UI", 14F);
      lb_Tables.Location = new Point(0, 0);
      lb_Tables.Name = "lb_Tables";
      lb_Tables.Size = new Size(403, 32);
      lb_Tables.TabIndex = 0;
      lb_Tables.Text = "Administator Priviledges Table Editor";
      // 
      // btn_Load_Test_Tables
      // 
      btn_Load_Test_Tables.Font = new Font("Segoe UI", 16F);
      btn_Load_Test_Tables.Location = new Point(81, 35);
      btn_Load_Test_Tables.Name = "btn_Load_Test_Tables";
      btn_Load_Test_Tables.Size = new Size(152, 51);
      btn_Load_Test_Tables.TabIndex = 1;
      btn_Load_Test_Tables.Text = "ALL Tables";
      btn_Load_Test_Tables.UseVisualStyleBackColor = true;
      btn_Load_Test_Tables.Click += btn_Load_Test_Tables_Click;
      // 
      // btn_Repor_Form
      // 
      btn_Repor_Form.Font = new Font("Segoe UI", 16F);
      btn_Repor_Form.Location = new Point(535, 35);
      btn_Repor_Form.Name = "btn_Repor_Form";
      btn_Repor_Form.Size = new Size(181, 51);
      btn_Repor_Form.TabIndex = 2;
      btn_Repor_Form.Text = "Report Form";
      btn_Repor_Form.UseVisualStyleBackColor = true;
      btn_Repor_Form.Click += btn_Repor_Form_Click;
      // 
      // lb_Report_Form
      // 
      lb_Report_Form.AutoSize = true;
      lb_Report_Form.Dock = DockStyle.Right;
      lb_Report_Form.Font = new Font("Segoe UI", 14F);
      lb_Report_Form.Location = new Point(436, 0);
      lb_Report_Form.Name = "lb_Report_Form";
      lb_Report_Form.Size = new Size(364, 32);
      lb_Report_Form.TabIndex = 3;
      lb_Report_Form.Text = "Report Automation for DB Tables";
      // 
      // Form1
      // 
      AutoScaleDimensions = new SizeF(8F, 20F);
      AutoScaleMode = AutoScaleMode.Font;
      ClientSize = new Size(800, 450);
      Controls.Add(lb_Report_Form);
      Controls.Add(btn_Repor_Form);
      Controls.Add(btn_Load_Test_Tables);
      Controls.Add(lb_Tables);
      Name = "Form1";
      Text = "Form1";
      Load += Form1_Load;
      ResumeLayout(false);
      PerformLayout();
    }

    #endregion

    private Label lb_Tables;
    private Button btn_Load_Test_Tables;
    private Button btn_Repor_Form;
    private Label lb_Report_Form;
  }
}
