
public static class ScoreEvents
{
    public static readonly GameEvent<int> OnScoreSaved = new GameEvent<int>();
    public static readonly GameEvent<int> OnScoreAdded = new GameEvent<int>();
    public static readonly GameEvent<int> OnScoreChanged = new GameEvent<int>();
}
