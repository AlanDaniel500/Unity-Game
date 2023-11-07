using System.Collections;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody2D rb;

    private HealthBarScript healthBar;

    private TakeDamage takeDamage;

    [Header("Player Stats")]

    [SerializeField] public float maxHealthPoints = 100.0f;

    [SerializeField] public float healthPoints = 100.0f;

    [SerializeField] public float healingPoints = 0.0f;

    [SerializeField] public int lives = 3;

    [Header("Movement")]

    private float horizontalMovement = 0f;

    [SerializeField] private float movementVelocity;

    [Range(0, 0.2f)] [SerializeField] private float motionSmoother;

    private Vector3 speed = Vector3.zero;

    private bool lookingRight = true;

    [Header("Jump")]

    [SerializeField] private float jumpForce;

    [SerializeField] private LayerMask isFloor;

    [SerializeField] private Transform floorController;

    [SerializeField] private Vector3 boxDimensions;

    public bool inFloor;

    private bool jump = false;

    public float JetpackForce;

    float fuel;

    [Header("Shooting")]

    public GameObject[] bullet;

    public bool isShooting;

    public float time;

    public GameObject point;

    float shootingDirection = 1;

    [Header("KnockBack")]

    public bool canMove = true;

    [SerializeField] private Vector2 bounceSpeed;

    [SerializeField] private float lossControlTime;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        healthBar = GetComponent<HealthBarScript>();

        takeDamage = GetComponent<TakeDamage>();
    }

    private void Start()
    {

    }

    private void Update()
    {
        if (canMove)
        {
            horizontalMovement = Input.GetAxisRaw("Horizontal") * movementVelocity;
        }

        if (Input.GetButtonDown("Jump") && inFloor)
        {
            jump = true;
        }
        Shoot();
    }

    private void FixedUpdate()
    {
        inFloor = Physics2D.OverlapBox(floorController.position, boxDimensions, 0f, isFloor);
        jump = false;

        if (canMove)
        {
            Move(horizontalMovement * Time.fixedDeltaTime, jump);
        }

        healthBar.UpdateHealthBar(healthPoints, maxHealthPoints);
    }

    private void Move(float move, bool jump)
    {
        Vector3 objectiveVelocity = new Vector2(move, rb.velocity.y);

        rb.velocity = Vector3.SmoothDamp(rb.velocity, objectiveVelocity, ref speed, motionSmoother);

        if (move > 0 && !lookingRight)
        {
            Turn();
        }
        else if (move < 0 && lookingRight)
        {
            Turn();    
        }
        if (jump && inFloor)
        {
            inFloor = false;
            rb.AddForce(new Vector2(0f, jumpForce));
        }
    }

    void Turn()
    {
        lookingRight = !lookingRight;
        Vector3 localScaleX = transform.localScale;
        localScaleX.x *= -1;
        transform.localScale = localScaleX;
        shootingDirection = localScaleX.x;
    }

    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.yellow;
    //    Gizmos.DrawWireCube(floorController.position, boxDimensions);
    //}
    void Shoot()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            GameObject obj = Instantiate(bullet[0], point.transform.position, transform.rotation) as GameObject;
            Bullet bulletScript = obj.GetComponent<Bullet>();
            bulletScript.SetDirection(shootingDirection);

            if (!isShooting)
            {
                isShooting = true;
            }
        }
    }
    public void GetDamageWithBounce(float damage, Vector2 position)
    {
        healthPoints -= damage;
        healthBar.UpdateHealthBar(healthPoints, maxHealthPoints);
        IsDead();
        StartCoroutine(LossControl());
        PlayerBounce(position);
    }
    private void IsDead()
    {
        if (healthPoints <= 0)
        {
            Lives.instance.DecreaseLives(1);
            healthPoints = maxHealthPoints;

            if (Lives.instance.currentLives <= 0)
            {
                gameObject.SetActive(false);
            }
        }
    }
    public void PlayerBounce(Vector2 hitPoint)
    {
        rb.velocity = new Vector2(-(bounceSpeed.x) * hitPoint.x, bounceSpeed.y);
    }
    private IEnumerator LossControl()
    {
        canMove = false;
        yield return new WaitForSeconds(lossControlTime);
        canMove = true;
    }
}