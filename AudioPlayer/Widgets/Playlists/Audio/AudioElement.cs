using System.Windows.Controls;

namespace AudioPlayer.Widgets.Playlists.Audio
{
    public class AudioElement : UserControl
    {
        public AudioInfo AudioInfo { get; set; }

        public AudioElement(AudioInfo audioInfo)
        {
            AudioInfo = audioInfo;

            InitializeComponent();
        }

        private void InitializeComponent()
        {
            
        }
    }
}
