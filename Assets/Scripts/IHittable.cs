
using System;

public interface IHittable
{
    public Action OnGetHit { get; set; }
    void GetHit(float hitValue);
}
