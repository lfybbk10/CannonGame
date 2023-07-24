
public class PauseEnemySpawner : Booster
{
    private int _pauseTimeSec = 3;
    
    public override void Activate()
    {
        BoosterEvents.OnPauseEnemySpawner.Publish(_pauseTimeSec);
    }
}
