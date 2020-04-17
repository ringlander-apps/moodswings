
using System.Collections.Generic;

namespace MoodSwings.Shared.Models.SpotifyModels
{
    public class Page<T>
    {
        public Page()
        {
            this.HREF = null;
            this.Limit = 20;
            this.Items = new List<T>();
            this.Next = null;
            this.Previous = null;
            this.Offset = 0;
            this.Total = 0;
        }
        public string HREF { get; set; }

        public List<T> Items { get; set; }

        public int Limit { get; set; }

        public string Next { get; set; }

        public int Offset { get; set; }

        public string Previous { get; set; }

        public int Total { get; set; }

        public bool HasNextPage
        {
            get
            {
                if (Next == null)
                    return false;
                if (string.IsNullOrEmpty(Next) || string.IsNullOrWhiteSpace(Next))
                    return false;
                return true;
            }
        }

        public bool HasPreviousPage
        {
            get
            {
                if (Previous == null)
                    return false;
                if (string.IsNullOrEmpty(Previous) || string.IsNullOrWhiteSpace(Previous))
                    return false;
                return true;

            }
        }
    }
}