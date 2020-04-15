using MoodSwings.Shared.Models;
using System;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace MoodSwings.Services
{
    public class SpotifyService
    {
        private readonly HttpClient _client;
        public SpotifyService(HttpClient client)
        {
            _client = client;

        }
        public async Task<User> GetCurrentUserProfile(AuthenticationToken token)
        {

            try
            {
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.AccessToken);
                var response = await _client.GetAsync("https://api.spotify.com/v1/me");

                System.Console.WriteLine(response);
                //var user = JsonSerializer.Deserialize<User>(await response.Content.ReadAsStringAsync());
                var user = JsonConvert.DeserializeObject<User>(await response.Content.ReadAsStringAsync());

                System.Console.WriteLine(user);


                return user;
            }
            catch (System.Exception)
            {

                throw;
                return null;
            }

        }

    }

}