using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(MeshFilter))]
public class RandomFieldPoint : MonoBehaviour
{
    private MeshFilter _meshFilter;

    public static RandomFieldPoint instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        _meshFilter = GetComponent<MeshFilter>();
    }

    public Vector3 Get(){

        Mesh planeMesh = _meshFilter.mesh;
        Bounds bounds = planeMesh.bounds;

        float minX = gameObject.transform.position.x - gameObject.transform.localScale.x * bounds.size.x * 0.5f;
        float minZ = gameObject.transform.position.z - gameObject.transform.localScale.z * bounds.size.z * 0.5f;

        Vector3 newVec = new Vector3(Random.Range (minX, -minX),
            gameObject.transform.position.y,
            Random.Range (minZ, -minZ));
        return newVec;
    }
}
