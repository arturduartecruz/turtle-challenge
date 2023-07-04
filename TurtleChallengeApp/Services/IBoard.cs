using TurtleChallengeApp.Enums;
using TurtleChallengeApp.Models;

internal interface IBoard
{
    void Initialize(int n, int m, Position start, Position exit, Position[] mines);
    void InitializeTurtle(Position start, Direction direction);
    void RotateTurtle();
    void MoveTurtle();
    bool IsTurtlePositionGameOver();
}