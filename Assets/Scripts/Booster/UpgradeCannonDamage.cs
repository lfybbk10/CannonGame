
public class UpgradeCannonDamage : Booster
{
    public override void Activate()
    {
        Events.OnUpgradeCannonDamage.Publish();
    }
}
