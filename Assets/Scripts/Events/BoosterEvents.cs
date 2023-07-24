
public static class BoosterEvents
{
    public static readonly GameEvent OnKillAllEnemies = new();
    
    public static readonly GameEvent<int> OnPauseEnemySpawner = new();
    
    public static readonly GameEvent OnUpgradeCannonSpeed = new();
    
    public static readonly GameEvent OnUpgradeCannonDamage = new();

    public static readonly GameEvent OnBoosterTaken = new();
}
