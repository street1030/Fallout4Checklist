using Fallout4Checklist.Repositories;
using System;
using System.IO;
using System.Windows;

namespace Fallout4Checklist
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            try
            {
                Repository.Initialize();
                base.OnStartup(e);
            }
            catch (Exception ex)
            {
                var logDirectory = $"{Environment.CurrentDirectory}\\Logs";
                if (!Directory.Exists(logDirectory)) Directory.CreateDirectory(logDirectory);

                var fileName = $"{logDirectory}\\{DateTime.Today.Day}-{DateTime.Today.Year}.txt";

                using (var writer = File.AppendText(fileName))
                {
                    writer.WriteLine(ex.Message);
                    writer.WriteLine(ex.InnerException);
                    writer.WriteLine(ex.StackTrace);
                }
            }
        }
    }
}
