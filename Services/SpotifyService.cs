using MoodSwings.Shared.Models;
using MoodSwings.Shared.Models.SpotifyModels;
using MoodSwings.Shared.Models.DTO;

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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<Page<Playlist>> GetUserPlaylists(RequestDTO request)
        {
            try
            {
                var uri = "https://wt-820975869a3e549eb65406598aa10b11-0.sandbox.auth0-extend.com/get-playlists";
                var json = JsonConvert.SerializeObject(request);

                var response = await _client.PostAsync(uri, new StringContent(json, Encoding.UTF8, "application/json"));

                var data = await response.Content.ReadAsStringAsync();

                var playlists = JsonConvert.DeserializeObject<Page<Playlist>>(data, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

                System.Console.WriteLine(playlists);

                return playlists;

            }
            catch (System.Exception)
            {

                throw;
                return null;
            }




        }

    }

}