using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ProjectilePool : Singleton<ProjectilePool>
{
    [SerializeField] private GameObject projectilePrefab;
    private static Queue<GameObject> _pool = new Queue<GameObject>();
    
    void Start()
    {
        GameObject obj = Instantiate(projectilePrefab, transform.position, Quaternion.identity,transform.parent);
        _pool.Enqueue(obj);
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
