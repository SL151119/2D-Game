using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float speed;
    [SerializeField] private float jumpPower;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask wallLayer;

    private float horizontalInput;
    private BoxCollider2D _boxCollider;
    private Rigidbody2D _rbPlayer;
    private Animator _anim;

    [Header("SFX")]
    [SerializeField] private AudioClip jumpSound;
    void Awake()
    {
        _rbPlayer = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _boxCollider = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        _rbPlayer.velocity = new Vector2
            (horizontalInput * speed, _rbPlayer.velocity.y);

        //Rotate hero
        if (horizontalInput > 0.01f)
            transform.localScale = new Vector2(8,8);

        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector2(-8,8);

        if (Input.GetKey(KeyCode.Space))
        {
            Jump();

            if (Input.GetKeyDown(KeyCode.Space) && isGrounded())
                SoundManager.instance.PlaySound(jumpSound);
        }

        _anim.SetBool("run", horizontalInput != 0);
        _anim.SetBool("grounded", isGrounded());
    }

    void Jump()
    {
        if (isGrounded())
        {
            _anim.SetTrigger("jump");
            _rbPlayer.velocity = new Vector2(_rbPlayer.velocity.x, jumpPower);
        }
    }
    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast
            (_boxCollider.bounds.center, _boxCollider.bounds.size,
            0, Vector2.down, 0.1f, groundLayer);

        return raycastHit.collider != null;
    }

    private bool onWall()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast
            (_boxCollider.bounds.center, _boxCollider.bounds.size,
            0, new Vector2 (transform.localScale.x, 0), 
            0.1f, wallLayer);

        return raycastHit.collider != null;
    }

    public bool canAttack()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        return horizontalInput == 0 && isGrounded() && !onWall();
    }
}
