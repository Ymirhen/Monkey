using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    public float spawnCounter = 5;
    private float _activeCounter;
    public GameObject cube;
    void Update()
    {
        _activeCounter -= Time.deltaTime;
        if ( _activeCounter < 0 )
        {
            _activeCounter = spawnCounter;
            ObjectPool.Spawn(cube, transform.position);
        }
    }
}
