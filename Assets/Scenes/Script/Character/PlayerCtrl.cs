using Assets.Scenes.Script.Enemy;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCtrl : MonoBehaviour
{
    protected Rigidbody2D rb;
    protected Animator aniPlayer;
    protected BoxCollider2D coll;

    [SerializeField] protected float speed;
    protected float horizontalValue;
    protected bool facingRight = true;

    [SerializeField] protected float jumpStr = 3f;
    protected float jumpValue;
    protected bool isGround;
    protected int totalJump = 2;
    protected bool mutilJump = false;
    protected int availableJump;
    public Transform groundCheck;
    public LayerMask groundLayer;

    [SerializeField] protected Transform builet;
    private float coolDown;
    public bool canShoot;
    public float delayShoot;

    private bool isWallSliding;
    private bool isWallJumping;
    private float wallSlidingSpeed;
    private float wallJummpingDirection;
    private float wallJummpingTime = 0.2f;
    private float wallJummpingDuration = 1f;
    private float wallJumpingCounter;
    private Vector2 wallJumpingPower = new Vector2(6f, 3f);    
    public Transform wallCheck;

    public GameObject Smoke;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        aniPlayer = GetComponent<Animator>();
        canShoot = false;
        coll = GetComponent<BoxCollider2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        ////Respawn();
        availableJump = totalJump;
        coolDown = delayShoot;
        CheckShoot();
        Smoke.SetActive(false);
    }

    void Update()
    {
        horizontalValue = Input.GetAxisRaw("Horizontal");
        coolDown += Time.deltaTime;
        Jumping();
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
        Sliding();
        WallJump();
        if (coolDown >= delayShoot && canShoot)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Attack();
            }
        }
    }

    private void FixedUpdate()
    {
        //if(!IsWallSlide())
            move(horizontalValue);
    }
    
    private bool IsGround()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, groundLayer);
    }
    /*void GroundCheck()
    {
        isGround = false;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, 0.1f, groundLayer);
        if (colliders.Length > 0)
        {
            isGround = true;
            aniPlayer.SetBool("Jump", false);
            availableJump = totalJump;
            Jumping = false;
            aniPlayer.ResetTrigger("Jump2");
        }
    }*/
    private bool IsWallSlide()
    {
        return Physics2D.OverlapCircle(wallCheck.position , 0.05f , groundLayer);
    }

    private void Sliding()
    {
        if (IsWallSlide() && !IsGround())
        {
            isWallSliding = true;
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, -wallSlidingSpeed, float.MaxValue));
            aniPlayer.SetBool("Sliding",true);
            aniPlayer.SetFloat("VelocityX", 0);
            aniPlayer.SetBool("Jump", false);
        }
        else
        {
            isWallSliding = false; 
            aniPlayer.SetBool("Sliding",false);
        }
            
    }

    private void WallJump()
    {
        if (isWallSliding)
        {
            isWallJumping = false;
            wallJummpingDirection = -transform.localScale.x;
            wallJumpingCounter = wallJummpingTime;
            CancelInvoke(nameof(StopWallJump));
        }
        else
        {
            wallJumpingCounter = -Time.deltaTime;
        }

        if(Input.GetButtonDown("Jump") && wallJumpingCounter > 0)
        {
            isWallJumping = true;
            rb.velocity = new Vector2(wallJummpingDirection * wallJumpingPower.x, wallJumpingPower.y);
            wallJumpingCounter = 0;
            aniPlayer.SetBool("Sliding",false);
            if (transform.localScale.x != wallJummpingDirection)
            {
                facingRight = !facingRight;
                Vector3 localScale = transform.localScale;
                localScale.x = -1f;
                transform.localScale = localScale;
            }
            Invoke(nameof(StopWallJump), wallJummpingDuration);
        }
    }

    private void StopWallJump()
    {
        isWallJumping = false;
    }

    // Update is called once per frame

    void move(float dir)
    {
        float xVal = dir * speed * 50 * Time.deltaTime;
        Vector2 targetVelocity = new Vector2(xVal, rb.velocity.y);
        rb.velocity = targetVelocity;
        //flip  looking
        if ( dir < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            facingRight = false;
        }
        if ( dir > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
            facingRight = true;
        }
        //0 is idle, 1 is running
        if (IsGround())
        {
            if(horizontalValue == 0)
            {
                aniPlayer.SetFloat("VelocityX", 0);
                Smoke.SetActive(false);
            }
            else
            {
                aniPlayer.SetFloat("VelocityX", 1);
                Smoke.SetActive(true);
            }
        }
        else
            Smoke.SetActive(false);
    }
    void Jump()
    {
        if (IsGround())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpStr);
            aniPlayer.SetBool("Jump", true);
            AudioManager.Instance.PlayMusic("Jump");
        }
        else
        {
            if (availableJump > 1)
            {
                availableJump--;
                rb.velocity = new Vector2(rb.velocity.x, jumpStr);
                aniPlayer.SetTrigger("Jump2");
            }
        }
        
    }

    private void Jumping()
    {
        aniPlayer.SetInteger("YVelocity", (int)rb.velocity.y);
        if ((int)rb.velocity.y != 0 || !IsGround())
            return;
        else
        {
            aniPlayer.SetBool("Jump", false);
            aniPlayer.ResetTrigger("Jump2");
            availableJump = totalJump;
        }
    }

    public float GetScale()
    {
        return transform.localScale.x;
    }
    protected void Attack()
    {
        BuiletManager.instance.SpamBuilet("PlayerBuilet", builet.position, GetScale());
        coolDown = 0f;
    }
    protected void CheckShoot()
    {
        int x = SceneManager.GetActiveScene().buildIndex;
        canShoot= (x == 4) ? true : false;
    }
}
