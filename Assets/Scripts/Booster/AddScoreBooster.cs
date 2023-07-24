
using UnityEngine;

public class AddScoreBooster : Booster
{
    [SerializeField] private int _addValue;
    public override void Activate()
    {
        Events.OnScoreAdded.Publish(_addValue);
    }
}
