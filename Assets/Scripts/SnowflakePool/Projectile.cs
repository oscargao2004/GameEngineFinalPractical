using System;
using Unity.VisualScripting;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Rigidbody2D _rb;
    private Vector2 _direction;
    [SerializeField] private float maxLifeTime;
    [SerializeField] private float speed;
    public bool usePool;
    private float _currentLifeTime;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        _rb.linearVelocity = _direction * speed;
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

    public void SetDirection(Vector2 direction)
    {
        _direction = direction;
    }
    public void SetTarget(Vector2 location)
    {
        _direction = -(transform.position - new Vector3(location.x, location.y, 0)).normalized;
    }
}
