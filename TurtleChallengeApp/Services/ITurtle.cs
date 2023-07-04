using TurtleChallengeApp.Enums;
using TurtleChallengeApp.Models;

internal interface ITurtle
{
    Position Position { get; set; }
    Direction Direction { get; set; }

    void Initialize(Position position, Direction direction);
    Position GetNextPosition();
    void Rotate();
    void Move();
}
