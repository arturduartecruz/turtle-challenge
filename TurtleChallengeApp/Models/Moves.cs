using TurtleChallengeApp.Enums;

namespace TurtleChallengeApp.Models;

public class Moves
{
    public string[][] StepSequence { get; set; }

    public Step[][] StepsEnumList => ConvertStringStepsListToEnum();

    public Moves()
    {
        StepSequence = Array.Empty<string[]>();
    }

    private Step[][] ConvertStringStepsListToEnum()
    {
        return StepSequence.Select(m => m.Select(n => Enum.Parse<Step>(n)).ToArray()).ToArray();
    }
}
