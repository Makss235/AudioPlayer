using AudioPlayer.Core;
using AudioPlayer.Resources.Serialize;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace AudioPlayer.Resources.Data
{
    public static class Playlists
    {
        public static List<PlaylistObject> PlaylistObjects { get; set; }
        public static List<PlaylistInfo> PlaylistsInfo { get; set; }

        public static void Initialize()
        {
            var str = Encoding.Default.GetString(Properties.Resources.Playlists);
            PlaylistObjects = JsonSerializer.Deserialize<List<PlaylistObject>>(str);

            PlaylistsInfo = new List<PlaylistInfo>();
            foreach (var item in PlaylistObjects)
            {
                PlaylistsInfo.Add(new PlaylistInfo(item));
            }
        }
    }
}
