using MoodSwings.Shared.Models;
using Cloudcrate.AspNetCore.Blazor.Browser.Storage;
using System;
using System.Text;
using Newtonsoft.Json;

namespace MoodSwings.Services
{

    public class AuthenticationService
    {
        public AuthenticationService(LocalStorage storage)
        {
            _storage = storage;
        }

        private readonly LocalStorage _storage;

        public LocalStorage StorageService => _storage;

        public AuthenticationToken Token
        {
            get
            {
                var item = _storage.GetItem("spotify_token_data");
                if (string.IsNullOrEmpty(item))
                {
                    //throw new Exception("No token found");
                    return null;
                }
                else
                {
                    return JsonConvert.DeserializeObject<AuthenticationToken>(item);

                }
            }
            set
            {
                _storage.SetItem("spotify_token_data", JsonConvert.SerializeObject(value));
            }

        }

        public bool IsAuthenticated
        {
            get
            {
                //return true;
                return User != null && (Token != null && !Token.HasExpired);
            }
        }
        public User User
        {
            get
            {
                var user = _storage.GetItem("spotify_user");
                if (string.IsNullOrEmpty(user))
                {
                    //throw new Exception("No user found");
                    return null;
                }
                else
                {
                    return JsonConvert.DeserializeObject<User>(user);
                }
            }
            set
            {
                _storage.SetItem("spotify_user", JsonConvert.SerializeObject(value));
            }
        }


    }
}