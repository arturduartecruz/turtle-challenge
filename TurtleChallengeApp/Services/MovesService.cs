using Newtonsoft.Json;
using TurtleChallengeApp.Models;

namespace TurtleChallengeApp.Services;

internal class MovesService : IMovesService {
    private readonly string _movesFilePath;

    public MovesService(string movesFilePath)
    {
        _movesFilePath = movesFilePath;
    }

    public Moves Load()
    {
        string settingsStringContent = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), $"{_movesFilePath}.json"));
        return JsonConvert.DeserializeObject<Moves>(settingsStringContent) ?? new Moves();
    }
}
