using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    public float spawnCounter = 5;
    private float _activeCounter;
    public GameObject cube;
    private void Update()
    {
        _activeCounter -= Time.deltaTime;
        if (!(_activeCounter < 0)) return;
        
        _activeCounter = spawnCounter;
        ObjectPool.Spawn(cube, transform.position);
    }
}
