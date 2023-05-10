using System.Configuration;
using System.Windows;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private string connectionString = ConfigurationManager.AppSettings["sqliteConnPro"];

        protected override async void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            await AutoMigrationHelper.Migration(connectionString);
        }
    }
}