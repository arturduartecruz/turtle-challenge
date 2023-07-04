namespace TurtleChallengeApp.Models;

internal class MineTile : Tile
{
    protected override string Message => "You stepped on a mine! Game Over.";

    public MineTile(ILogger logger) : base(logger)
    {
    }
}
