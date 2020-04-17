using System;

namespace MoodSwings.Shared.Models.SpotifyModels
{
    public class PlaylistTrack
    {
        public DateTime AddedAt { get; set; }
        //public User AddedBy { get; set; }

        public Track Track { get; set; }
    }
}