
public class UpgradeCannonDamage : Booster
{
    public override void Activate()
    {
        BoosterEvents.OnUpgradeCannonDamage.Publish();
    }
}
