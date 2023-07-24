
public static class ScoreEvents
{
    public static readonly GameEvent<int> OnScoreSaved = new();
    public static readonly GameEvent<int> OnScoreAdded = new();
    public static readonly GameEvent<int> OnScoreChanged = new();
}
