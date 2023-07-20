using UnityEngine;

public static class Events
{
    public static readonly GameEvent OnEnemySpawned = new();
    public static readonly GameEvent OnEnemyDestroyed = new();
    public static readonly GameEvent<GameObject> OnEnemyReleased = new();
    public static readonly GameEvent OnLose = new();
    
    public static readonly GameEvent OnLeftMouseDown = new();
    
    public static readonly GameEvent<float> OnCannonBallHit = new();
    
    public static readonly GameEvent<int> OnScoreChanged = new();
    
    public static readonly GameEvent OnDifficultyIncreased = new();
    
    public static readonly GameEvent OnKillAllEnemies = new();
    
    public static readonly GameEvent<int> OnPauseEnemySpawner = new();
}