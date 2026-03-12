using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using Yarn.Unity;

public class ShopNPC : MonoBehaviour
{
    public GameObject player;
    public bool canInteract = false;
    public UnityEvent OpenShop;
    public UnityEvent CloseShop;
    public bool shopOpen = false;
    public int pressedAmt = 0;
    public GameObject BarCanvas;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.Find("Player");

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
    [YarnCommand("DrinkStart")]
    public void DrinkOpen()
    {
        BarCanvas.SetActive(true);
        OpenShop.Invoke();
    }
}
public class BarEnd
{
    public static bool barDone;

    [YarnFunction("DrinkOver")]
    public static bool drinkClose()
    {
        return barDone;
    }

}
