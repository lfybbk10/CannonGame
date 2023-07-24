
using System.Collections.Generic;
using UnityEngine;

public static class Extensions
{

    public static bool Contains(this LayerMask mask, int layer)
    {
        return mask == (mask | (1 << layer));
    }
    
    public static T GetRandomElem<T>(this IList<T> list)  
    {  
        var random = new System.Random();
        int index = random.Next(list.Count);
        return list[index];
    }
}
