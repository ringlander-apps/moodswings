using System.Collections.Generic;

namespace MoodSwings.Shared.Models.SpotifyModels
{
    public class Artist
    {
        public string HREF { get; set; }

        /// <summary>
        /// The Spotify ID for the artist. 
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Images of the artist in various sizes, widest first.
        /// </summary>
        public List<Image> Images { get; set; }

        /// <summary>
        /// The name of the artist 
        /// </summary>
        public string Name { get; set; }

    }
}