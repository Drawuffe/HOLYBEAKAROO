using UnityEngine;
using System.Collections;

public class CursorManager : MonoBehaviour
{
  
    public void CursorShow()
    {
        Cursor.visible = true;

    }

    public void CursorHide()
    {
        Cursor.visible = false;
    }
}
