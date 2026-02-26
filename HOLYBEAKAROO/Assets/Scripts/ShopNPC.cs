using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class ShopNPC : MonoBehaviour
{
    public GameObject player;
    public bool canInteract = false;
    public UnityEvent OpenShop;
    public UnityEvent CloseShop;
    public bool shopOpen = false;
    public int pressedAmt = 0;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<GameObject>();

    }

    // Update is called once per frame
    void Update()
    {


    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        canInteract = true;
        OpenShop.Invoke();
        shopOpen = true;
        Debug.Log("can open up shop");
        //need to freeze movement (stop player input)
    }

    public void OnTriggerExit2D(Collider2D collision)
    {

        canInteract = false;
        if(shopOpen)
        {
            CloseShop.Invoke();
        }
        
        Debug.Log("Not near shop keeper");
    }


}
