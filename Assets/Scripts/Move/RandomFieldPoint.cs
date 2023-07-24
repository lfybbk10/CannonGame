using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(BoxCollider))]
public class RandomFieldPoint : MonoBehaviour
{
    private BoxCollider _collider;

    public static RandomFieldPoint instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        _collider = GetComponent<BoxCollider>();
    }

    public Vector3 Get(){

        Bounds bounds = _collider.bounds;
        float offsetX = Random.Range(-bounds.extents.x, bounds.extents.x);
        float offsetZ = Random.Range(-bounds.extents.z, bounds.extents.z);

        Vector3 res = bounds.center + new Vector3(offsetX, 0, offsetZ);
        res.y = 1;
        return res;
    }
}
