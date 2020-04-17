using System;

namespace MoodSwings.Shared.Models
{
    public class AuthenticationToken
    {
        public string AccessToken { get; set; }

        public string RefreshToken { get; set; }

        public DateTime ExpiresOn { get; set; }

        public double ExpiresIn { get; set; }

        public bool HasExpired
        {
            get
            {
                return DateTime.Now > ExpiresOn;

            }
        }
    }
    ///
    public class User
    {
        public string DisplayName { get; set; }
        public string Id { get; set; }

        public string Email { get; set; }


    }
}