using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public string Type;
        public GameObject Prefab;
        public int Size;
    }
    public static ObjectPooler Instance;
    public List<Pool> Pools;
    public Dictionary<string, Queue<GameObject>> PoolDictionary;
    GameObject _objectToSpawn;


    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        PoolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach (Pool pool in Pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for (int i = 0; i < pool.Size; i++)
            {
                GameObject obj = Instantiate(pool.Prefab,transform);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }

            PoolDictionary.Add(pool.Type, objectPool);
        }
    }

    public GameObject SpawnFromPool(string type, Vector3 position, Quaternion rotation)
    {
        if (!PoolDictionary.ContainsKey(type))
        {
            Debug.LogWarning("Pool with type : " + type + " doesn't exist.");
            return null;
        }

        _objectToSpawn = PoolDictionary[type].Dequeue();
        _objectToSpawn.SetActive(true);
        _objectToSpawn.transform.position = position;
        _objectToSpawn.transform.rotation = rotation;

        PoolDictionary[type].Enqueue(_objectToSpawn);

        return _objectToSpawn;
    }
    
}
