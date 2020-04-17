using System.Collections.Generic;

namespace MoodSwings.Shared.Models.SpotifyModels
{
    ///<summary>
    /// Spotify Track
    ///</summary> 
    public class Track
    {
        /// <summary>
        /// The album on which the track appears. The album object includes a link in href to full information about the album.
        /// </summary>
        public Album Album { get; set; }

        /// <summary>
        /// The artists who performed the track. Each artist object includes a link in href to more detailed information about the artist.
        /// </summary>
        public List<Artist> Artists { get; set; }

        public List<string> AvailableMarkets { get; set; }

        public int DiscNumber { get; set; }

        public int Duration { get; set; }

        public bool Explicit { get; set; }

        public string HREF { get; set; }

        public ExternalId ExternalId { get; set; }

        public ExternalUrl ExternalUrl { get; set; }

        public string Id { get; set; }

        public string Name { get; set; }

        public int Popularity { get; set; }

        public string Tempo { get; set; }





    }

    /*

  is_playable 	boolean 	Part of the response when Track Relinking is applied. If true , the track is playable in the given market. Otherwise false.
  linked_from 	a linked track object 	Part of the response when Track Relinking is applied, and the requested track has been replaced with different track. The track in the linked_from object contains information about the originally requested track.
  restrictions 	a restrictions object 	Part of the response when Track Relinking is applied, the original track is not available in the given market, and Spotify did not have any tracks to relink it with. The track response will still contain metadata for the original track, and a restrictions object containing the reason why the track is not available: "restrictions" : {"reason" : "market"}
  name 	string 	The name of the track.
  popularity 	integer 	The popularity of the track. The value will be between 0 and 100, with 100 being the most popular.
  The popularity of a track is a value between 0 and 100, with 100 being the most popular. The popularity is calculated by algorithm and is based, in the most part, on the total number of plays the track has had and how recent those plays are.
  Generally speaking, songs that are being played a lot now will have a higher popularity than songs that were played a lot in the past. Duplicate tracks (e.g. the same track from a single and an album) are rated independently. Artist and album popularity is derived mathematically from track popularity. Note that the popularity value may lag actual popularity by a few days: the value is not updated in real time.
  preview_url 	string 	A link to a 30 second preview (MP3 format) of the track. Can be null
  track_number 	integer 	The number of the track. If an album has several discs, the track number is the number on the specified disc.
  type 	string 	The object type: “track”.
  uri 	string 	The Spotify URI for the track.
  is_local 	boolean 	Whether or not the track is from a local file.


     */
}