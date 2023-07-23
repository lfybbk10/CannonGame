
public class UpgradeCannonSpeed : Booster
{
    public override void Activate()
    {
        Events.OnUpgradeCannonSpeed.Publish();
    }
}
