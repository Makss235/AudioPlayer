using AudioPlayer.Core;
using AudioPlayer.Widgets.Playlists.Audio;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace AudioPlayer.Windows.MainWindow
{
    public partial class MainWindow
    {
        private Grid audioStateGrid;

        private Grid ICAudioStateRow()
        {
            AudioPlayerCore.Initialize();
            AudioPlayerCore.Play();
            audioStateGrid = new Grid();
            return audioStateGrid;
        }
    }
}
