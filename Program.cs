using Management_Internet_Cafe.Data;

namespace Management_Internet_Cafe
{
  internal static class Program
  {
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
      // To customize application configuration such as set high DPI settings or default font,
      // see https://aka.ms/applicationconfiguration.
      ApplicationConfiguration.Initialize();

      try
      {
        // DATABASE STARTUP CHECK + INIT
        DatabaseInitializer.Initialize();
      }
      catch (Exception ex)
      {
        MessageBox.Show(
          "Application failed to start:\n" + ex.Message,
          "Startup Error",
          MessageBoxButtons.OK,
          MessageBoxIcon.Error
        );

        return;
      }
      Application.Run(new Form1());
    }
  }
}