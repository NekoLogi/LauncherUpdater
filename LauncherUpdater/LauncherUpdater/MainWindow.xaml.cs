using System;
using System.IO;
using System.Windows;

namespace LauncherUpdater
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            Updater updater = new Updater();
            if (!updater.Start())
                InitializeComponent();
        }

        private void Start_Launcher_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(Directory.GetCurrentDirectory() + "\\Launcher\\ModLauncher.exe") { CreateNoWindow = true });
            Close();
        }

        private void Update_Launcher_Click(object sender, RoutedEventArgs e)
        {
            Updater updater = new Updater();
            updater.UpdateClient();
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            SetVersions();
            
            if (!Server.IS_CONNECTED)
                Update_Launcher.IsEnabled = false;

            if (Updater.VERSION_CLIENT == null || Updater.VERSION_CLIENT == Updater.NO_VERSION)
                Start_Launcher.IsEnabled = false;
        }

        // Display client, server version and server status.
        private void SetVersions()
        {
            Client_Ver.Content = Updater.VERSION_CLIENT;
            Server_Ver.Content = Server.VERSION_SERVER;

            if (Server.IS_CONNECTED)
                Server_Status.Content = "Online";
            else
                Server_Status.Content = "Offline";
        }
    }
}
