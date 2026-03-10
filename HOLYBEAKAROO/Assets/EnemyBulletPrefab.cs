using UnityEngine;
using UnityEngine.InputSystem;

public class EnemyBulletPrefab : MonoBehaviour
{
    private Vector3 mousePos;
    private Camera mainCam;
    Transform target;
    private Rigidbody2D bulletRB;
    public float force;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        target = GameObject.Find("Player").transform;
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        bulletRB = GetComponent<Rigidbody2D>();
        mousePos = mainCam.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        //direction of mouse cursor + rotates bullet towards the mouse
        Vector3 direction = target.position - transform.position;
        Vector3 rotation = transform.position - target.position;
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
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            DealDamage.SendDamage(1);
            Debug.Log("enemy bullet hit");
        }
        
        //Destroy(gameObject);
    }
}
