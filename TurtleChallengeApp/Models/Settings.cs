using System.Text.Json.Serialization;

namespace TurtleChallengeApp.Models;

public class Settings
{
    public Boardsize BoardSize { get; set; }

    [JsonPropertyName("Start")]
    public Position Start { get; set; }

    public string Direction { get; set; }

    [JsonPropertyName("Exit")]
    public Position Exit { get; set; }

    [JsonPropertyName("Mines")]
    public Position[] Mines { get; set; }

    public Settings()
    {
        Direction = "north";
        BoardSize = new Boardsize();
        Mines = Array.Empty<Position>();
        Start = new Position();
        Exit = new Position();
    }
}
