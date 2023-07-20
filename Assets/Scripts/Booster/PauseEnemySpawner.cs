
public class PauseEnemySpawner : Booster
{
    private int _pauseTimeSec = 3;
    
    public override void Activate()
    {
        Events.OnPauseEnemySpawner.Publish(_pauseTimeSec);
    }
}
