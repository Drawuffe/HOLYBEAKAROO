using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using System.IO;
using Unity.VisualScripting;

public class EnemyAI : MonoBehaviour
{
    //defines diff states and switches between them
    public enum EnemyState { Idle, Patrol, Chase, Attack, Death }
    public EnemyState currentState;

    public GameObject beakPrefab;
    public GameObject enemyBulletPrefab;

    //seth code
    GameObject target;
    Rigidbody2D rb;
    public Transform bulletStart;

    public float health, maxHealth = 15f;

    //patrol settings
    //public Transform[] patrolPoints;
    private int currentPatrolIndex;

    //AI settings
    [Header("AI Settings")]
    //public int health;
    public float moveInput;
    public float speed;
    public float attackCooldown;
    public bool canMove = false;

    float lastAttackTime;
    int collisionCount = 0;

    [Header("Projectile Settings")]
    //public Rigidbody projectile;
    public float projSpeed = 8f;

    // Start is called before the first frame update
    void Start()
    {
        //search for player in scene, make sure its name doesnt change
        target = GameObject.Find("Player");
        health = maxHealth;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (canMove)
        {
            Move();
        }
    }

    public void TakeDamage(float damage)
    {
        /*if (pos.x < transform.position.x)
        {
            rb.AddForce(Vector2.right * 10 * Time.deltaTime, ForceMode2D.Impulse);
        }
        else
        {
            rb.AddForce(Vector2.left * 10 * Time.deltaTime, ForceMode2D.Impulse);
        }*/

        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
            Instantiate(beakPrefab);
        }
    }

    public void AttackState()
    {
        //indicate attacking
        if (Time.time >= lastAttackTime + attackCooldown)
        {
            lastAttackTime = Time.time;
            StartCoroutine(SpawnBullets());
            Debug.Log("enemy attacked");
            //logic to alert the player about being found, staying in the radius for a certain amount of time will reset the player's game.
            //logic to damage player health on another script
            //DealDamage.SendDamage(1);
        }
    }

    IEnumerator SpawnBullets()
    {
        Debug.Log("shooting");
        yield return new WaitForSeconds(3f);

        GameObject projectile = Instantiate(enemyBulletPrefab, bulletStart.position, Quaternion.identity);
        //p.linearVelocity = transform.forward * speed;
        StartCoroutine(SpawnBullets());
        Destroy(projectile, 1.5f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //Look towards player direction
            //Vector3 dir = target.transform.position - transform.position;
            //float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            //transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            //Move();
            canMove = true;
            AttackState();
        }
    }
    void Move()
    {
        Vector3 rotation = (target.transform.position - transform.position).normalized;
        float angle = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        // move myself towards the player
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
    }

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Debug.Log("collided with enemy");
            collisionCount++;
            health -= 1;

            Debug.Log("bullet hit");

            if (health <= 0)
            {
                //agent.enabled = false;
                //ChangeState(EnemyState.Death)
                Destroy(gameObject);
                Instantiate(beakPrefab);
                //dead = true;
            }
        }
    }*/
}
