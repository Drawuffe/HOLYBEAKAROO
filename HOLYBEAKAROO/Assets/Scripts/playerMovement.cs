using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header ("Stats")]
    public float moveSpeed;
    public float jumpHeight;

    [Header ("Gravity")]
    public float currentGravity;
    public float gravity;

    [Header("Dash")]
    public float maxDashDuration = .2f;
    public float dashDistance = 5f;
    public float dashCooldown;
    public bool canDash = true;
    public bool isDashing = false;

    [Header("Grounding")]
    public LayerMask groundLayer;
    public Transform groundCheck;

    public PlayerInput playerInput;

    private Rigidbody2D rb;
    public float moveInput;
    public bool isGrounded;
    public bool isFacingRight = true;
    public int facingDir = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        currentGravity = rb.gravityScale;
    }

    void Update()
    {
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);
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
        }
    }

    public void Aim(InputAction.CallbackContext context)
    {
        if (Mouse.current.leftButton.IsPressed() && !isGrounded)
        {
            rb.gravityScale = gravity;
            rb.linearDamping = 10;
        }
        if (!Mouse.current.leftButton.IsPressed())
        {
            rb.gravityScale = currentGravity;
            rb.linearDamping = 0;
        }
    }

    public void Dash(InputAction.CallbackContext context)
    {
        if (context.performed)
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
        canDash = true;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == ("Ground"))
        {
            isGrounded = true;
            Debug.Log("isGrounded");
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
