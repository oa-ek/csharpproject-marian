using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TeamManager.Core.Entities;

namespace TeamManager.Repository.RawgApiService
{
    public class RawgApiService : IRawgApiService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;

        public RawgApiService(HttpClient httpClient, string apiKey)
        {
            _httpClient = httpClient;
            _apiKey = apiKey;
        }

        public async Task<IEnumerable<Game>> GetGamesAsync()
        {
            var response = await _httpClient.GetAsync($"https://api.rawg.io/api/games?key={_apiKey}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var gamesResponse = JsonSerializer.Deserialize<RawgApiResponse<List<Game>>>(content);
            var games = gamesResponse.Results as IEnumerable<Game>;
            return games;
        }


        public async Task<Game> GetGameByIdAsync(string id)
        {
            var response = await _httpClient.GetAsync($"https://api.rawg.io/api/games/{id}?key={_apiKey}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var game = JsonSerializer.Deserialize<Game>(content);
            return game;
        }

        public async Task DeleteGameAsync(string id)
        {
            var response = await _httpClient.DeleteAsync($"https://api.rawg.io/api/games/{id}?key={_apiKey}");
            response.EnsureSuccessStatusCode();
        }

        public async Task<Game> CreateGameAsync(Game game)
        {
            var gameData = JsonSerializer.Serialize(game);

            var content = new StringContent(gameData, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("https://api.rawg.io/api/games?key=" + _apiKey, content);

            response.EnsureSuccessStatusCode();

            var responseData = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Game>(responseData);
        }

        public async Task<Game> UpdateGameAsync(string gameId, Game game)
        {
            var gameData = JsonSerializer.Serialize(game);

            var content = new StringContent(gameData, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"https://api.rawg.io/api/games/{gameId}?key=" + _apiKey, content);

            response.EnsureSuccessStatusCode();

            var responseData = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Game>(responseData);
        }

    }
}
