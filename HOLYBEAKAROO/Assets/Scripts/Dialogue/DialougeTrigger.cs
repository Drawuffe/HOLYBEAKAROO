using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using Yarn.Unity;

public class NPCDialogueTrigger : MonoBehaviour
{
    public UnityEvent dialogueTrigger;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            dialogueTrigger.Invoke();
        }
    }

}

