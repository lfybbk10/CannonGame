public static class Events
{
    public static readonly GameEvent OnEnemySpawned = new();
    public static readonly GameEvent OnEnemyDestroyed = new();
    public static readonly GameEvent OnLose = new();
    
    public static readonly GameEvent OnLeftMouseDown = new();
    
    public static readonly GameEvent<float> OnCannonBallHit = new();
}