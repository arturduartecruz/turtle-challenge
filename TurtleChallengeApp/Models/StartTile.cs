namespace TurtleChallengeApp.Models;

internal class StartTile : Tile
{
    protected override string Message => "You're at the start! Good luck...";

    public StartTile(ILogger logger) : base(logger)
    {
    }

}
