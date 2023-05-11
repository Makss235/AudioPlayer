using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows.Media;

namespace AudioPlayer.Core
{
    public static class APCore
    {
        public static ObservableCollection<AudioInfo> QueueAudio { get; private set; }

        private static AudioInfo _CurrentAudio;
        public static AudioInfo CurrentAudio
        {
            get => _CurrentAudio;
            set
            {
                _CurrentAudio = value;
                CurrentAudioChanged?.Invoke(_CurrentAudio);
            }
        }

        public static event Action<AudioInfo> CurrentAudioChanged;

        private static MediaPlayer mediaPlayer;

        static APCore()
        {
            CurrentAudioChanged += AudioPlayerCore_CurrentAudioChanged;

            InitMediaPlayer();
            InitQueueAudio();
        }

        public static void Initialize() { }

        public static void Play(AudioInfo audioInfo)
        {
            CurrentAudio = audioInfo;
        }

        public static void Play()
        {
            CurrentAudio = QueueAudio[0];
            QueueAudio.RemoveAt(0);
        }

        public static void Pause()
        {
            mediaPlayer?.Pause();
        }

        private static void InitMediaPlayer()
        {
            mediaPlayer = new MediaPlayer();
            mediaPlayer.MediaEnded += (s, e) => Play();
        }

        private static void InitQueueAudio()
        {
            QueueAudio = new ObservableCollection<AudioInfo>();
            QueueAudio.CollectionChanged += QueueAudio_CollectionChanged;

            var d = Directory.GetFiles(@"D:\Sounds\Русские популярные");
            foreach (var item in d)
            {
                if (Path.GetExtension(item) == ".mp3")
                    QueueAudio.Add(new AudioInfo(item));
            }
        }

        private static void AudioPlayerCore_CurrentAudioChanged(AudioInfo obj)
        {
            mediaPlayer.Open(new Uri(obj.FilePath, UriKind.Absolute));
            mediaPlayer.Play();
        }

        private static void QueueAudio_CollectionChanged(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (QueueAudio.Count == 0)
                InitQueueAudio();
        }
    }
}
