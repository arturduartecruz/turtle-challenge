using TurtleChallengeApp.Enums;

namespace TurtleChallengeApp.Services;

internal class GameLogic : IGameLogic
{
    private readonly IBoard _board;
    private readonly IMovesService _movesService;
    private readonly ILogger _logger;
    private readonly ISettingsService _settingsService;

    public GameLogic(
        ILogger logger,
        ISettingsService settingsService, 
        IMovesService movesService, 
        IBoard board)
    {
        _movesService = movesService;
        _logger = logger;
        _settingsService = settingsService;
        _board = board;
    }

    public void SetupBoard() 
    {
        var settings = _settingsService.Load();
        _board.Initialize(
            settings.BoardSize.N,
            settings.BoardSize.M,
            settings.Start,
            settings.Exit,
            settings.Mines);
    }

    public void RunSequences()
    {
        var sequences = _movesService.Load();
        foreach (var sequence in sequences.StepsEnumList)
        {
            SetupPlayer();
            RunSteps(sequence);
        }
    }

    private void RunSteps(Step[] steps)
    {
        foreach (var step in steps)
        {
            switch (step)
            {
                case Step.move:
                    _board.MoveTurtle();
                    if (_board.IsTurtlePositionGameOver())
                    {
                        return;
                    }
                    break;
                case Step.rotate:
                    _board.RotateTurtle();
                    break;
                default:
                    break;
            }
        }

        _logger.Log("The turtle didn´t reach the exit.");
    }

    private void SetupPlayer()
    {
        var settings = _settingsService.Load();
        _board.InitializeTurtle(
            settings.Start,
            Enum.Parse<Direction>(settings.Direction));

        _logger.Log(string.Empty);
        _logger.Log("Placed the turtle at the start tile.");
    }


}