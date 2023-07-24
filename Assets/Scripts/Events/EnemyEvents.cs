
using UnityEngine;

public static class EnemyEvents
{
    public static readonly GameEvent OnEnemySpawned = new();
    public static readonly GameEvent OnEnemyDestroyed = new();
    public static readonly GameEvent<GameObject> OnEnemyReleased = new();
    public static readonly GameEvent<int> OnChangeEnemiesCount = new();
    public static readonly GameEvent OnEnemyDamaged = new();
}
