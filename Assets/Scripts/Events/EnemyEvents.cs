
using UnityEngine;

public static class EnemyEvents
{
    public static readonly GameEvent OnEnemySpawned = new GameEvent();
    public static readonly GameEvent OnEnemyDestroyed = new GameEvent();
    public static readonly GameEvent<GameObject> OnEnemyReleased = new GameEvent<GameObject>();
    public static readonly GameEvent<int> OnChangeEnemiesCount = new GameEvent<int>();
    public static readonly GameEvent OnEnemyDamaged = new GameEvent();
}
