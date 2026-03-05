using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement Instance;

    [Header ("Stats")]
    public float moveSpeed;
    public float currentSpeed;
    public float floatSpeed;
    public float jumpHeight;
    private bool canDbJump;
    //health stats:
    public int maxHealth;
    public int currentHealth;

    public HealthBar healthBar;

    [Header ("Gravity")]
    public float currentGravity;
    public float gravity;

    [Header("Dash")]
    public float maxDashDuration = .2f;
    public float dashDistance = 5f;
    public float dashCooldown;
    public bool canDash = true;
    public bool isDashing = false;

    [Header("Shoot/Aim")]
    public GameObject reticle;
    private Camera mainCam;
    private Vector3 mousePos;
    public float mouseRetSpeed;

    public GameObject bulletPrefab;
    public Transform bulletStart;
    public GameObject bulletDestroyPrefab;

    public bool canShoot;

    public int currentAmmo, maxAmmo = 7;
    public AmmoCount ammoCount;

    [Header("Grounding")]
    public LayerMask groundLayer;
    public Transform groundCheck;

    [Header("Settings")]
    public PlayerInput playerInput;
    private Rigidbody2D rb;
    public float moveInput;
    public bool isGrounded;
    public bool isFacingRight = true;
    public int facingDir = 0;

    [Header("Collection")]
    public GameObject beakObj;
    public Shop shop;

    private void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        currentGravity = rb.gravityScale;
        currentSpeed = moveSpeed;
        //finding the main camera for the reticle to follow the mouse pos
        Cursor.visible = false;
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        reticle.SetActive(false);
        beakObj = GameObject.FindGameObjectWithTag("Beak").GetComponent<GameObject>();

        currentAmmo = maxAmmo;

        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);

        //moves the reticle along with the mousepos on every frame of update.
        mousePos = mainCam.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        reticle.transform.position = Vector2.Lerp(transform.position, mousePos, mouseRetSpeed);
    }

    public void TakeDamage(int _damage)
    {
        currentHealth -= _damage;
        healthBar.SetHealth(currentHealth);
        Debug.Log("Health = " + currentHealth.ToString());
        //animator.SetBool("isHit", true);
        StartCoroutine(HitWait());
    }

    IEnumerator HitWait()
    {
        yield return new WaitForSeconds(1);
        //animator.SetBool("isHit", false);
    }

    public void Move(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>().x;

        if (moveInput > 0.1f)
        {
            facingDir = 0;
        }
        else if (moveInput < -0.1f)
        {
            facingDir = -180;
        }

        //transform.localScale = new Vector3(facingDir, 1, 1);
        Vector3 rotator = new Vector3(transform.rotation.x, facingDir, transform.rotation.z);
        transform.rotation = Quaternion.Euler(rotator);
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if(context.performed && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpHeight);
            canShoot = true;
        }
    }

    public void DoubleJump(InputAction.CallbackContext context)
    {
        if (context.performed && !isGrounded && canDbJump)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpHeight);
            canDbJump = false;
        }
    }

    public void Aim(InputAction.CallbackContext context)
    {
        if (Mouse.current.leftButton.IsPressed() && !isGrounded && canShoot)
        {
            rb.gravityScale = gravity;
            rb.linearDamping = 10;
            moveSpeed = floatSpeed;
            reticle.SetActive(true);
        }
        else if (!Mouse.current.leftButton.IsPressed())
        {
            //bulletShoot.Fire();
            rb.gravityScale = currentGravity;
            rb.linearDamping = 0;
            moveSpeed = currentSpeed;
            reticle.SetActive(false);
            Debug.Log("turned off");
        }
    }

    public void Shoot(InputAction.CallbackContext context)
    {
        if (!Mouse.current.leftButton.IsPressed() && !isGrounded && canShoot && currentAmmo > 0)
        {
            GameObject firedBullet = Instantiate(bulletPrefab, bulletStart.position, Quaternion.identity);
            Debug.Log("fired");
            //creates a gameobject with a collider that will destry the bullet at the location of the aim instead of allowing it to keep flying.
            GameObject destroyTrigger = Instantiate(bulletDestroyPrefab, mousePos, Quaternion.identity);
            Destroy(destroyTrigger, 3);
            currentAmmo--;
            ammoCount.AmmoCounter();
            canShoot = false;
        }
    }

    public void Reload(InputAction.CallbackContext context)
    {
        int reloadAmt = maxAmmo - currentAmmo;
        currentAmmo += reloadAmt;
    }

    public void Dash(InputAction.CallbackContext context)
    {
        if (context.performed && canDash)
        {
            StartCoroutine(DashTime());
        }
    }

    private IEnumerator DashTime()
    {
        isDashing = true;
        canDash = false;

        //float dashDirection = facingDir;
        float dashSpeed = dashDistance / maxDashDuration;

        float startTime = Time.time;

        while(Time.time < startTime + maxDashDuration)
        {
            //add dash trail vfx
            //moves the player towards the right arrow/red arrow
            rb.linearVelocity = new Vector2(dashSpeed, rb.linearVelocity.y) * transform.right;
            yield return null;
        }
        
        isDashing = false;
        Debug.Log("dash ended, starting cooldown");

        yield return new WaitForSeconds(dashCooldown);

        canDash = true;
        Debug.Log("dash cooldown is over");
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == ("Ground"))
        {
            isGrounded = true;
            canShoot = true;
            canDbJump = true;
            Debug.Log("isGrounded");
        }

        if (collision.gameObject.tag == ("Beak"))
        {
            //Debug.Log("Hit by player");           
            shop.beaks++;
            Debug.Log("#" + shop.beaks);
            shop.BeakCounter();
            Destroy(collision.gameObject);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == ("Ground"))
        {
            isGrounded = false;
        }
    }

}
