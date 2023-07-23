
using System;

public interface IHP
{
    public Action<float> OnValueChanged { get; set; }
    float GetMaxValue();
    
    float GetValue();
}
