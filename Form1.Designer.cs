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
      label1 = new Label();
      btn_Load_Test_Tables = new Button();
      SuspendLayout();
      // 
      // label1
      // 
      label1.AutoSize = true;
      label1.Location = new Point(314, 47);
      label1.Name = "label1";
      label1.Size = new Size(141, 20);
      label1.TabIndex = 0;
      label1.Text = "Project Initialization";
      // 
      // btn_Load_Test_Tables
      // 
      btn_Load_Test_Tables.Font = new Font("Segoe UI", 16F);
      btn_Load_Test_Tables.Location = new Point(314, 91);
      btn_Load_Test_Tables.Name = "btn_Load_Test_Tables";
      btn_Load_Test_Tables.Size = new Size(152, 51);
      btn_Load_Test_Tables.TabIndex = 1;
      btn_Load_Test_Tables.Text = "Test Tables";
      btn_Load_Test_Tables.UseVisualStyleBackColor = true;
      btn_Load_Test_Tables.Click += btn_Load_Test_Tables_Click;
      // 
      // Form1
      // 
      AutoScaleDimensions = new SizeF(8F, 20F);
      AutoScaleMode = AutoScaleMode.Font;
      ClientSize = new Size(800, 450);
      Controls.Add(btn_Load_Test_Tables);
      Controls.Add(label1);
      Name = "Form1";
      Text = "Form1";
      Load += Form1_Load;
      ResumeLayout(false);
      PerformLayout();
    }

    #endregion

    private Label label1;
    private Button btn_Load_Test_Tables;
  }
}
