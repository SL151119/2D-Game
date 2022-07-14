using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] fireBalls;
    [SerializeField]private AudioClip fireballSound;

    private Animator _anim;
    private PlayerMovement _playerMovement;

    private float _cooldownTimer = Mathf.Infinity;


    void Awake()
    {
        _anim = GetComponent<Animator>();
        _playerMovement = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.F) && _cooldownTimer > attackCooldown
            && _playerMovement.canAttack())
            Attack();

        _cooldownTimer += Time.deltaTime;
    }

    void Attack()
    {
        SoundManager.instance.PlaySound(fireballSound);
        _anim.SetTrigger("attack");
        _cooldownTimer = 0;

        fireBalls[FindFireball()].transform.position = firePoint.position;
        fireBalls[FindFireball()].GetComponent<Projectile>().SetDirection
            (Mathf.Sign(transform.localScale.x));
    }

    private int FindFireball()
    {
        for (int i = 0; i < fireBalls.Length; i++)
        {
            if (!fireBalls[i].activeInHierarchy)
                return i;
        }
        return 0;
    }
}
