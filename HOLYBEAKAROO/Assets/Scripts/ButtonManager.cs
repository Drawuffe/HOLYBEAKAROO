using Unity.VisualScripting;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public GameObject BarCanva;
  public void OnButtonClick()
    {
        BarCanva.SetActive(false);
    }
}
