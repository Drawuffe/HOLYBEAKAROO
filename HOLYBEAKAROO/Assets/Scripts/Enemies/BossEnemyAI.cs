using UnityEngine;

public class BossEnemyAI : MonoBehaviour
{
    public float health, maxHealth = 15f;
    GameObject target;
    Rigidbody2D rb;

    public Transform[] bulletStart;

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
        
    }
}
