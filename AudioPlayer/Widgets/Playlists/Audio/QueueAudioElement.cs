using System.Windows.Controls;

namespace AudioPlayer.Widgets.Playlists.Audio
{
    public class QueueAudioElement : UserControl
    {
        public AudioInfo AudioInfo { get; set; }

        public QueueAudioElement(AudioInfo audioInfo)
        {
            AudioInfo = audioInfo;

            InitilizeComponent();
        }

        private void InitilizeComponent()
        {
            
        }
    }
}
