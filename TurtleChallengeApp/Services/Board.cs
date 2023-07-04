using TurtleChallengeApp.Enums;
using TurtleChallengeApp.Models;

namespace TurtleChallengeApp.Services;

internal class Board : IBoard {

    private readonly ILogger _logger;
    private readonly ITurtle _turtle;
    private Tile[,] _board;

    public Board(ILogger logger, ITurtle turtle)
    {
        _logger = logger;
        _board = new Tile[,] { };
        _turtle = turtle;
    }

    public void Initialize(int n, int m, Position start, Position exit, Position[] mines)
    {
        if(m*n < 2)
            throw new InvalidOperationException($"A board of {n} rows by {m} columns is not big enough for the minimum playable area.");

        _board = new Tile[n, m];

        for (int i = 0; i < n; i++) 
        {
            for (int j = 0; j < m; j++) 
            {
                _board[i, j] = new Tile(_logger);
            }
        }
        
        if (IsPositionValid(start))
            _board[start.X, start.Y] = new StartTile(_logger);
        else
            throw new InvalidOperationException($"Values in the settings file for the start position {start} are not valid.");

        if (IsPositionValid(exit)) { 

            if(_board[exit.X, exit.Y] is StartTile)
                throw new InvalidOperationException($"Exit position {exit} is attempting to override the start position in the settings file.");
            
            _board[exit.X, exit.Y] = new ExitTile(_logger);
        }
        else
            throw new InvalidOperationException($"Values in the settings file for the exit position {exit} are not valid.");

        foreach (var mine in mines)
        {
            if (IsPositionValid(mine))
            {

                if (_board[mine.X, mine.Y] is StartTile)
                    throw new InvalidOperationException($"Mine position {mine} is attempting to override the start position in the settings file.");

                if (_board[mine.X, mine.Y] is ExitTile)
                    throw new InvalidOperationException($"Mine position {mine} is attempting to override the exit position in the settings file.");

                _board[mine.X, mine.Y] = new MineTile(_logger);
        }
        else 
                throw new InvalidOperationException($"Values in the settings file for the mines position {mine} are not valid.");
        }
    }

    public void InitializeTurtle(Position start, Direction direction)
    {
        if (IsPositionValid(start))
            _turtle.Initialize(start, direction);
        else
            throw new InvalidOperationException("Turtle start position is out of bounds.");
    }

    public void RotateTurtle()
    {
        _turtle.Rotate();
    }

    public void MoveTurtle()
    {
        var targetPosition = _turtle.GetNextPosition();
        if (IsPositionValid(targetPosition))
        {
            _turtle.Move();
        }
        else
        {
            _logger.Log("Turtle just hit the wall...");
        }
    }

    public bool IsTurtlePositionGameOver()
    {
        Tile tile = GetTile(_turtle.Position);
        tile.GetDescription();

        return tile switch
        {
            MineTile => true,
            ExitTile => true,
            _ => false,
        };
    }

    private bool IsPositionValid(Position targetPosition)
    {
        return (targetPosition.X >= 0 && targetPosition.X <= _board.GetLength(0) - 1) && (targetPosition.Y >= 0 && targetPosition.Y <= _board.GetLength(1) - 1);
    }

    private Tile GetTile(Position position)
    {
        if (IsPositionValid(position))
            return _board[position.X, position.Y];
        else
            throw new InvalidOperationException("Trying to get tile from out of bounds.");
    }
}
