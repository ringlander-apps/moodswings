using System.Collections.Generic;

namespace MoodSwings.Shared.Models.SpotifyModels
{
    public class Playlist
    {
        public string Description { get; set; }
        public string HREF { get; set; }

        public List<Image> Images { get; set; }

        public string Name { get; set; }

        public Page<PlaylistTrack> Tracks { get; set; }

        public string Id { get; set; }







    }
}