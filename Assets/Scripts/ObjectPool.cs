using System;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    #region Singleton

    private static ObjectPool _instance;
 
    public static ObjectPool Instance
    {
        get
        {
            if (_instance != null) return _instance;
            _instance = (ObjectPool)FindObjectOfType(typeof(ObjectPool));

            if (_instance != null) return _instance;
            var singletonObject = new GameObject();
            _instance = singletonObject.AddComponent<ObjectPool>();

            return _instance;
        }
    }

    #endregion

    public List<GameObject> pooledObjects;
    public GameObject objectPrefab;
    public int poolCount;

    private void Start()
    {
        pooledObjects = new List<GameObject>();
        for (int index = 0; index < poolCount; index++)
        {
            var obj = Instantiate(objectPrefab);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
    }

    public GameObject Spawn(Vector3 position)
    {
        if (pooledObjects.Count == 0)
        {
            var obj = Instantiate(objectPrefab);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
        var toSpawn = pooledObjects[0];
        pooledObjects.RemoveAt(0);

        toSpawn.transform.position = position;
        toSpawn.SetActive(true);

        return toSpawn;
    }

    public void Recycle(GameObject obj)
    {
        obj.SetActive(false);
        pooledObjects.Add(obj);
    }
}