using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed;

    [SerializeField] private float _lifetimeProjectile;
    private float direction;
    private bool isHit;
    private BoxCollider2D _boxCollider;
    private Animator _anim;

    void Awake()
    {
        _anim = GetComponent<Animator>();
        _boxCollider = GetComponent<BoxCollider2D>();
        
    }

    void Update()
    {
        if (isHit) return;
        float movementSpeed = speed * Time.deltaTime * direction;
        transform.Translate(movementSpeed, 0, 0);

        _lifetimeProjectile += Time.deltaTime;
        if (_lifetimeProjectile > 2) gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.gameObject.tag == "Enemy") || (collision.gameObject.tag == "Wall") || (collision.gameObject.tag == "EnemyFireball"))
        {
            isHit = true;
            _boxCollider.enabled = false;
            _anim.SetTrigger("explode");
        }

        if (collision.tag == "Enemy")
            collision.GetComponent<Health>().TakeDamage(1);
    }

    public void SetDirection(float _direction)
    {
        _lifetimeProjectile = 0;
        direction = _direction; 
        gameObject.SetActive(true);
        isHit = false;
        _boxCollider.enabled = true;

        float localScaleX = transform.localScale.x;
        if (Mathf.Sign(localScaleX) != _direction)
            localScaleX = -localScaleX;

        transform.localScale = new Vector2(localScaleX, 
            transform.localScale.y);
    }
    
    void Deactive()
    {
        gameObject.SetActive(false);
    }
}
