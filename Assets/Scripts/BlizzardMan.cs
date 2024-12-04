using System;
using System.Diagnostics;
using UnityEngine;

public class BlizzardMan : MonoBehaviour
{
    private ProjectilePool _projectilePool;
    [SerializeField] private int maxHealth;
    private float _currentHealth;

    private void Awake()
    {
        _projectilePool = GetComponent<ProjectilePool>();
    }

    void Start()
    {
        _currentHealth = maxHealth;
    }

    void Update()
    {
        if (_currentHealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    void SpawnSnowflake(Vector2 location)
    {
        
            
    }

    void Attack()
    {
        
    }

    void DecreaseHealth(int amount)
    {
        _currentHealth -= amount;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PlayerProjectile"))
        {
            DecreaseHealth(1);
        }
    }
    
    
}
