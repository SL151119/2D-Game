using UnityEngine;

public class RangeEnemy : MonoBehaviour
{
    [Header("Attack Parametrs")]
    [SerializeField] private float attackCooldown;
    [SerializeField] private int damage;
    [SerializeField] private float range;

    [Header("Collider Parametrs")]
    [SerializeField] private float colliderDistance;
    [SerializeField] private BoxCollider2D boxCollider;

    [Header("Range Attack")]
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] fireBalls;

    [Header("Player Layer")]
    [SerializeField] private LayerMask playerLayer;
    private float cooldownTimer = Mathf.Infinity;

    [Header("Fireball Sound")]
    [SerializeField] private AudioClip fireballsSound;

    private Animator _anim;
    private EnemyPatrol enemyPatrol;

    void Awake()
    {
        _anim = GetComponent<Animator>();
        enemyPatrol = GetComponentInParent<EnemyPatrol>();
    }

    void Update()
    {
        cooldownTimer += Time.deltaTime;
        if (PlayerInSight())
        {
            if (cooldownTimer >= attackCooldown)
            {
                cooldownTimer = 0;
                _anim.SetTrigger("rangedAttack");
            }
        }

        if (enemyPatrol != null)
            enemyPatrol.enabled = !PlayerInSight();
    }

    void RangeAttack()
    {
        SoundManager.instance.PlaySound(fireballsSound);
        cooldownTimer = 0;
        fireBalls[FindFireball()].transform.position = firePoint.position;
        fireBalls[FindFireball()].GetComponent<EnemyProjectile>().ActivateProjectile();
    }

    int FindFireball()
    {
        for (int i = 0; i < fireBalls.Length; i++)
        {
            if (fireBalls[i].activeInHierarchy)
                return i;
        }
        return 0;
    }

    bool PlayerInSight()
    {
        RaycastHit2D hit = Physics2D.BoxCast
            (boxCollider.bounds.center
            + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range,
            boxCollider.bounds.size.y, boxCollider.bounds.size.z)
           , 0, Vector2.left, 0, playerLayer);

        return hit.collider != null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center +
            transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range,
            boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }

}
