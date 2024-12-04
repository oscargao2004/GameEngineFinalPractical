using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ProjectilePool : Singleton<ProjectilePool>
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private int poolSize;
    private static Queue<GameObject> _pool = new Queue<GameObject>();
    
    
    void Awake()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(projectilePrefab, transform.position, Quaternion.identity, transform);
            _pool.Enqueue(obj);
            obj.SetActive(false);
        }
    }

    void Update()
    {
        
    }

    public static GameObject GetFromPool()
    {
        if (_pool.Count > 0)
        {
            GameObject obj = _pool.Dequeue();
            obj.SetActive(true);
            return obj;
        }
        else
        {
            Debug.LogError("Pool is empty");
            return null;
        }
        
    }

    public static void ReturnToPool(GameObject obj)
    {
        _pool.Enqueue(obj);
        obj.SetActive(false);
    }
}
