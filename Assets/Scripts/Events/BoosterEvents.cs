
public static class BoosterEvents
{
    public static readonly GameEvent OnKillAllEnemies = new GameEvent();
    
    public static readonly GameEvent<int> OnPauseEnemySpawner = new GameEvent<int>();
    
    public static readonly GameEvent OnUpgradeCannonSpeed = new GameEvent();
    
    public static readonly GameEvent OnUpgradeCannonDamage = new GameEvent();

    public static readonly GameEvent OnBoosterTaken = new GameEvent();
}
