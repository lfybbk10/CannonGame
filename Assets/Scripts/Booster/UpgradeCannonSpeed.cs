
public class UpgradeCannonSpeed : Booster
{
    public override void Activate()
    {
        BoosterEvents.OnUpgradeCannonSpeed.Publish();
    }
}
