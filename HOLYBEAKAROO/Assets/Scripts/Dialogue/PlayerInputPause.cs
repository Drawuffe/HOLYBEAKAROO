using UnityEngine;

public class PlayerInputPause : MonoBehaviour
{
    public PlayerMovement pInput;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pInput = GetComponent<PlayerMovement>();
        
    }

    public void OnTalk()
    {
        pInput.enabled = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        

    }

    public void NotTalk()
    {
        pInput.enabled = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

}
