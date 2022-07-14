using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [Header ("Patrol Points")]
    [SerializeField] private Transform leftEdge;
    [SerializeField] private Transform rightEdge;

    [Header("Enemy")]
    [SerializeField] private Transform enemy;

    [Header("Movement parametrs")]
    [SerializeField] private float speed;
    private Vector3 initScale;
    private bool movingLeft;

    [Header("Idle Behaviour")]
    [SerializeField] private float idleDuration;
    private float idleTimer;

    [Header("Enemy Animator")]
    [SerializeField] private Animator _anim;

    void Awake()
    {
        initScale = enemy.localScale;    
    }

    void OnDisable()
    {
        _anim.SetBool("moving", false); 
    }


    void Update()
    {
        if (movingLeft)
        {
            if(enemy.position.x >= leftEdge.position.x)
            MoveInDirection(-1);
            else
                DirectionChange();
        }
        else
        {
            if (enemy.position.x <= rightEdge.position.x)
                MoveInDirection(1);
            else
                DirectionChange();
        }
    }

    void DirectionChange()
    {
        _anim.SetBool("moving", false);
        idleTimer += Time.deltaTime;

        if(idleTimer > idleDuration)
        movingLeft = !movingLeft;
    }

    void MoveInDirection(int _direction)
    {
        idleTimer = 0;
        _anim.SetBool("moving", true);

        enemy.localScale = new Vector3(Mathf.Abs(initScale.x) * _direction,
            initScale.y, initScale.z);

        enemy.position = new Vector3
        (enemy.position.x + Time.deltaTime * _direction * speed,
        enemy.position.y, enemy.position.z);
    }
}
