using Microsoft.Extensions.DependencyInjection;
using TurtleChallengeApp.Services;

internal class Program
{

    private static void Main(string[] args)
    {
        if (args.Length >= 2)
        {
            string _settingsFile;
            string _movesFile;
            _settingsFile = args[0];
            _movesFile = args[1];

            ISettingsService settingsService = new SettingsService(_settingsFile);
            IMovesService movesService = new MovesService(_movesFile);

            var serviceProvider = new ServiceCollection()
                .AddTransient<ILogger, ConsoleLogger>()
                .AddSingleton(settingsService)
                .AddSingleton(movesService)
                .AddSingleton<IGameLogic, GameLogic>()
                .AddTransient<IBoard, Board>()
                .AddTransient<ITurtle, Turtle>()
                .BuildServiceProvider();

            var logger = serviceProvider.GetService<ILogger>();
            var game = serviceProvider.GetService<IGameLogic>();

            logger?.Log("Welcome to the turtle challenge!");

            try
            {
                game?.SetupBoard();
                game?.RunSequences();
            }
            catch (Exception ex)
            {
                logger?.Log(ex.Message);
                logger?.Log("Please review the settings and moves files for any inconsistency and try again.");
            }
        }
    }
}