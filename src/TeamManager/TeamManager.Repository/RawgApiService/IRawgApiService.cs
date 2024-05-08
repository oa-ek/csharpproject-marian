using TeamManager.Core.Entities;

namespace TeamManager.Repository.RawgApiService
{
    public interface IRawgApiService
    {
        Task<IEnumerable<Game>> GetGamesAsync();
        Task<Game> GetGameByIdAsync(string gameId);
        Task<Game> CreateGameAsync(Game game);
        Task<Game> UpdateGameAsync(string gameId, Game game);
        Task DeleteGameAsync(string gameId);
    }
}

