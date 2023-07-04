namespace TurtleChallengeApp.Models;

internal class ExitTile : Tile
{
    protected override string Message => "You reached the exit! Congrats!";

    public ExitTile(ILogger logger) : base(logger)
    {
    }
}