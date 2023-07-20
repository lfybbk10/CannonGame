
public class KillEnemiesBooster : Booster
{
    public override void Activate()
    {
        Events.OnKillAllEnemies.Publish();
    }
}
