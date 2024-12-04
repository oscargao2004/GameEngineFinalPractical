using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Snowflake : MonoBehaviour
{
    [SerializeField] private float shootRateSeconds;
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private bool usePool = true;
    [SerializeField] private float maxLifeTime;
    private float _currentLifeTime;
    private GameObject _target;
    
    void Start()
    {
        _target = GameObject.Find("Player");
        if (_target)
        {
            StartCoroutine(Shoot(usePool));
        }
    }

    void Update()
    {
        _currentLifeTime += Time.deltaTime;
        if (_currentLifeTime >= maxLifeTime)
        {
            Destroy(this.gameObject);
        }
    }

    IEnumerator Shoot(bool fromPool)
    {
        if (fromPool)
        {
            //spawn projectiles from pool
            Projectile projectile = ProjectilePool.GetFromPool().GetComponent<Projectile>();
            projectile.transform.position = transform.position;
            projectile.SetTarget(_target.transform.position);

        }
        else
        {
            //instantiate projectiles at runtime
            Projectile projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity).GetComponent<Projectile>();
            projectile.SetTarget(_target.transform.position);
        }
        
        yield return new WaitForSeconds(shootRateSeconds);
    }
    
    
}
