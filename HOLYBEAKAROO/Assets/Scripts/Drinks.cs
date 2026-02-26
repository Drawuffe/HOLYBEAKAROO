using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Drinks : MonoBehaviour
{
    public float drinkTotal;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<TextMeshProUGUI>().enabled = true;
        DrinkCounter();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DrinkCounter()
    {
        GetComponent<TextMeshProUGUI>().text = "Beaks:" + drinkTotal;
    }
}
