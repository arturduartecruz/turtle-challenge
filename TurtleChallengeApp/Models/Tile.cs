namespace TurtleChallengeApp.Models;

internal class Tile : ITile
{
    protected virtual string Message => "You reached a safe tile.";
    protected readonly ILogger _logger;

    public Tile(ILogger logger)
    {
        _logger = logger;
    }

    public void GetDescription()
    {
        _logger.Log(Message);
    }
}