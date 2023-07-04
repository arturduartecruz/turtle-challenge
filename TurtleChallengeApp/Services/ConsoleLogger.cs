namespace TurtleChallengeApp.Services;

internal class ConsoleLogger : ILogger
{
    public void Log(string message)
    {
        if (string.IsNullOrEmpty(message))
        {
            Console.WriteLine(string.Empty);
        }
        else 
        {
            Console.WriteLine($"{DateTime.Now} {message}");
        }
    }
}