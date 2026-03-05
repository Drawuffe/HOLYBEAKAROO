using UnityEngine;

public class DealDamage : MonoBehaviour
{
    public static void SendDamage(int damage)
    {
        //testing damage w a button
        PlayerMovement playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        playerStats.TakeDamage(damage);
    }
}
