using UnityEngine;
using TMPro;
using UnityEngine.Rendering;
public class ItemCollection : MonoBehaviour
{
    public GameObject player;
    public float collectedBeaks;




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<GameObject>();

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == ("Player"))
        {
            //Debug.Log("Hit by player");           
            collectedBeaks++;
            Debug.Log("beak #" +  collectedBeaks);
            Destroy(this.gameObject);
        }
    }


  
}
