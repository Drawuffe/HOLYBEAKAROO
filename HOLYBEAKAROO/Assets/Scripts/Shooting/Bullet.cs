using UnityEngine;
using UnityEngine.InputSystem;

public class Bullet : MonoBehaviour
{
    private Vector3 mousePos;
    private Camera mainCam;
    private Rigidbody2D bulletRB;
    public float force;
    public EnemyAI enemyAI;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        bulletRB = GetComponent<Rigidbody2D>();
        mousePos = mainCam.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        //direction of mouse cursor + rotates bullet towards the mouse
        Vector3 direction = mousePos - transform.position;
        Vector3 rotation = transform.position - mousePos;
        //keeps speed normal
        bulletRB.linearVelocity = new Vector2(direction.x, direction.y).normalized * force;
        //rotation
        float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 90);
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, 1.5f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
            Debug.Log("hit ground");
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            enemyAI.TakeDamage(1);
            Destroy(gameObject);
            Debug.Log("hit");
        }
    }
}
