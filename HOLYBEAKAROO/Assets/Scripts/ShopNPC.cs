using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class ShopNPC : MonoBehaviour
{
    public ItemCollection itemCollection;
    public GameObject player;
    public bool canInteract = false;
    public bool canBuyDrink = false;
    public float drinkCost = 3;
    public float beaks;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<GameObject>();
        itemCollection = GameObject.FindGameObjectWithTag("Beak").GetComponent<ItemCollection>();

    }

    // Update is called once per frame
    void Update()
    {


        if (Keyboard.current.eKey.IsPressed() && canInteract)
        {
            Debug.Log("E pressed");
            if(canBuyDrink == true)
            {
                Debug.Log("can buy drink");
            }
            else
            {
                Debug.Log("can't buy drink");
            }

        }
        else
        {

        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        canInteract = true;
        Debug.Log("can open up shop");
        //need to freeze movement (stop player input)
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        canInteract = false;
        Debug.Log("Not near shop keeper");
    }


}
