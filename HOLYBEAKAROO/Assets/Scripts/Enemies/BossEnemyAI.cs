using System.Collections;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class BossEnemyAI : MonoBehaviour
{
    public float health, maxHealth = 15f;
    GameObject target;
    Rigidbody2D rb;

    public Transform[] bulletStart;
    public GameObject enemyBulletPrefab;
    public float attackCooldown = 3f;
    public bool isDead = false;

    float lastAttackTime;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //search for player in scene, make sure its name doesnt change
        target = GameObject.Find("Player");
        health = maxHealth;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead)
        {
            SceneManager.LoadScene(4);
            //change scene to end/restart scene
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
        }
    }

    IEnumerator SpawnBullets()
    {
        Debug.Log("shooting");
        yield return new WaitForSeconds(3f);

        GameObject projectile = Instantiate(enemyBulletPrefab, bulletStart[0].position, Quaternion.identity);
        GameObject proj2 = Instantiate(enemyBulletPrefab, bulletStart[1].position, Quaternion.identity);
        GameObject proj3 = Instantiate(enemyBulletPrefab, bulletStart[2].position, Quaternion.identity);
        GameObject proj4 = Instantiate(enemyBulletPrefab, bulletStart[3].position, Quaternion.identity);
        //p.linearVelocity = transform.forward * speed;
        //StartCoroutine(SpawnBullets());
        Destroy(projectile, 1.5f);
        Destroy(proj2, 1.5f);
        Destroy(proj3, 1.5f);
        Destroy(proj4, 1.5f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            AttackState();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            health -= 1;

            Debug.Log("bullet hit");

            if (health <= 0)
            {
                //agent.enabled = false;
                //ChangeState(EnemyState.Death)
                Destroy(gameObject);
                //Instantiate(beakPrefab, transform.position, Quaternion.identity);
                isDead = true;
            }
        }
    }
}
