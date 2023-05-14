using AudioPlayer.Resources.Data;
using AudioPlayer.Windows.MainWindow;
using System;
using System.Windows;

namespace AudioPlayer
{
    internal class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            PlaylistsData.Initialize();
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Application application = new Application();
            application.Run(mainWindow);
        }
    }
}
