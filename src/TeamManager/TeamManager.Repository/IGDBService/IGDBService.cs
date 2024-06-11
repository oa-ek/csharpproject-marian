/*using Microsoft.Extensions.Configuration;
using System.Text;
using TeamManager.Core.Entities;

namespace TeamManager.Repository
{
    public class IGDBService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public IGDBService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task<Game> GetGameInfoAsync(string gameName)
        {
            string clientId = _configuration["IGDB:ClientId"];
            string clientSecret = _configuration["IGDB:ClientSecret"];
            string accessToken = await GetAccessToken(clientId, clientSecret);

            string apiUrl = "https://api.igdb.com/v4/games";
            string requestBody = $"search \"{gameName}\"; fields name, summary, release_dates.date, platforms.name, genres.name, developers.name; limit 1;";

            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);

            var request = new HttpRequestMessage(HttpMethod.Post, apiUrl)
            {
                Content = new StringContent(requestBody, Encoding.UTF8, "text/plain")
            };

            HttpResponseMessage response = await _httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                string jsonContent = await response.Content.ReadAsStringAsync();
*//*                var gameInfo = JsonConvert.DeserializeObject<Game>(jsonContent);
*//*
                return gameInfo;
            }
            else
            {
                throw new Exception($"Failed to fetch game info from IGDB API. Status code: {response.StatusCode}");
            }
        }

        private async Task<string> GetAccessToken(string clientId, string clientSecret)
        {
            string tokenUrl = "https://id.twitch.tv/oauth2/token";
            string requestBody = $"client_id={clientId}&client_secret={clientSecret}&grant_type=client_credentials";

            var response = await _httpClient.PostAsync(tokenUrl, new StringContent(requestBody, Encoding.UTF8, "application/x-www-form-urlencoded"));
            string content = await response.Content.ReadAsStringAsync();
*//*            dynamic data = JsonConvert.DeserializeObject(content);
*//*
            return data.access_token;
        }
    }
}
*/