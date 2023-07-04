using Newtonsoft.Json;
using TurtleChallengeApp.Models;

namespace TurtleChallengeApp.Services;

internal class SettingsService : ISettingsService {
    private readonly string _settingsFilePath;

    public SettingsService(string settingsFilePath)
    {
        _settingsFilePath = settingsFilePath;
    }

    public Settings Load()
    {
        string settingsStringContent = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), $"{_settingsFilePath}.json"));
        return JsonConvert.DeserializeObject<Settings>(settingsStringContent) ?? new Settings();
    }
}
