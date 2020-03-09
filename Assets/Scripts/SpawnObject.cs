using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    public float spawnCounter = 5;
    private float activeCounter;
    public GameObject cube;
    void Update()
    {
        activeCounter -= Time.deltaTime;
        if ( activeCounter < 0 )
        {
            activeCounter = spawnCounter;
            ObjectPool.Instance.Spawn(transform.position).GetComponent<Cube>().Initialize(1);
        }
    }
}
