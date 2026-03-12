using UnityEngine;
using TMPro;
using UnityEngine.Rendering;

public class Shop : MonoBehaviour
{

    public bool canBuyDrink = false;
    public float drinkCost = 3;
    public float beaks = 3;
    public Drinks drinks;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<TextMeshProUGUI>().enabled = true;
        BeakCounter();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BuyDrink()
    {
        if(beaks >= drinkCost)
        {
            Debug.Log("Drink bought");
            drinks.drinkTotal++;
            canBuyDrink=true;
            beaks = beaks - drinkCost;
            BeakCounter() ;
            //update beak count;

        }
        else
        {
            Debug.Log("Can't buy drink");
        }

    }

    public void BeakCounter()
    {
        GetComponent<TextMeshProUGUI>().text = "Beaks:" + beaks ;
    }
}
