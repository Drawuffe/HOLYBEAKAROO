using TMPro;
using UnityEngine;

public class AmmoCount : MonoBehaviour
{
    //public int currentAmmo;
    public PlayerMovement playerMovement;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<TextMeshProUGUI>().enabled = true;
        //AmmoCounter();
    }

    private void LateUpdate()
    {
        AmmoCounter();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AmmoCounter()
    {
        GetComponent<TextMeshProUGUI>().text = playerMovement.currentAmmo + "/" + playerMovement.maxAmmo;
    }
}
