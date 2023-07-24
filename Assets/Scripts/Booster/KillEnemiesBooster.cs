
public class KillEnemiesBooster : Booster
{
    public override void Activate()
    {
        BoosterEvents.OnKillAllEnemies.Publish();
    }
}
