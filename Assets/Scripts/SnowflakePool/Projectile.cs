using System;
using Unity.VisualScripting;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Rigidbody2D _rb;
    private Vector2 _direction;
    [SerializeField] private float maxLifeTime;
    [SerializeField] private bool usePool;
    private float _currentLifeTime;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        _rb.linearVelocity = _direction;
        _currentLifeTime += Time.deltaTime;
        if (_currentLifeTime >= maxLifeTime)
        {
            if (usePool)
            {
                ProjectilePool.ReturnToPool(this.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }
    }

    public void SetTarget(Vector3 location)
    {
        _direction = (transform.position - new Vector3(location.x, 0, location.y)).normalized;
    }
}
