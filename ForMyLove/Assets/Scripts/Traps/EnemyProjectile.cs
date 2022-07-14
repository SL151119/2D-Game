using UnityEngine;

public class EnemyProjectile : EnemyDamage
{
    [SerializeField] private float speed;
    [SerializeField] private float lifetime;
    private Animator _anim;
    private BoxCollider2D coll;

    private bool hit;

    void Awake()
    {
        _anim = GetComponent<Animator>();
        coll = GetComponent<BoxCollider2D>();
    }

    public void ActivateProjectile()
    {
        hit = false;
        lifetime = 0;
        gameObject.SetActive(true);
        coll.enabled = true;
    }

    void Update()
    {
        if (hit) return;
        float movementSpeed = speed * Time.deltaTime;
        transform.Translate(movementSpeed, 0, 0);

        lifetime += Time.deltaTime;
        if (lifetime > 2)
            gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.gameObject.tag == "Player") || (collision.gameObject.tag == "Wall") || (collision.gameObject.tag == "Fireball"))
        {
            hit = true;
            base.OnTriggerEnter2D(collision);
            coll.enabled = false;

            if (_anim != null)
                _anim.SetTrigger("explode");
            else
                gameObject.SetActive(false);
        }
    }

    void Deactive()
    {
        gameObject.SetActive(false);
    }
}
