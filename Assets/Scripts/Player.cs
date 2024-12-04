using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    private Vector2 _facingDir;
    float t = 0;

    [SerializeField] private GameObject normalProjectilePrefab;
    [SerializeField] private GameObject chargedProjectilePrefab;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            _facingDir = Vector2.left;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            _facingDir = Vector2.right;
        }

        if (Input.GetMouseButtonDown(0))
        {
            Shoot(false);
        }
        if (Input.GetMouseButtonUp(0))
        {
            if (t > 1)
            {
                Shoot(true);
            }
            t = 0;
            
        }

        if (Input.GetMouseButton(0))
        {
            t += Time.deltaTime;
        }
        
    }

    void Shoot(bool isCharged)
    {
        if (isCharged)
        {
            Projectile projectile = Instantiate(chargedProjectilePrefab, transform.position, Quaternion.identity)
                .GetComponent<Projectile>();
            projectile.SetDirection(_facingDir);
        }
        else
        {
            Projectile projectile = Instantiate(normalProjectilePrefab, transform.position, Quaternion.identity)
                .GetComponent<Projectile>();
            projectile.SetDirection(_facingDir);
        }
    }
}
