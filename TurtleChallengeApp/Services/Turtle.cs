using TurtleChallengeApp.Enums;
using TurtleChallengeApp.Models;

namespace TurtleChallengeApp.Services;

internal class Turtle : ITurtle
{
    private readonly ILogger _logger;

    public Position Position { get; set; }

    public Turtle(ILogger logger)
    {
        Position = new Position();
        _logger = logger;
    }

    public Direction Direction { get; set; }

    public void Initialize(Position position, Direction direction)
    {
        Position = position;
        Direction = direction;
    }

    public Position GetNextPosition()
    {
        var pos = Position;

        switch (Direction)
        {
            case Direction.north:
                pos.Y--;
                break;
            case Direction.east:
                pos.X++;
                break;
            case Direction.south:
                pos.Y++;
                break;
            case Direction.west:
                pos.X--;
                break;
            default:
                break;
        }

        return pos;
    }

    public void Rotate()
    {
        switch (Direction)
        {
            case Direction.north:
                Direction = Direction.east;
                break;
            case Direction.east:
                Direction = Direction.south;
                break;
            case Direction.south:
                Direction = Direction.west;
                break;
            case Direction.west:
                Direction = Direction.north;
                break;
            default:
                break;
        }

        _logger.Log($"Rotated to {Direction}");
    }

    public void Move()
    {   
        Position = GetNextPosition();
        _logger.Log($"Moved to {Position}");
    }
}
