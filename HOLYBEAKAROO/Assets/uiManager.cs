using UnityEngine;

public class uiManager : MonoBehaviour
{
    public static uiManager Instance;

    private void Awake()
    {
        //checks if there is already a game managaer
        if (Instance == null)
        {
            //we are going to assign
            Instance = this;
            //keeps game manager alive when switching scenes
            DontDestroyOnLoad(this.gameObject);

            //SceneManager.sceneLoaded += OnSceneLoad;
        }
        else
        {
            //destroy duplicate game managers
            Destroy(gameObject);
        }
    }
}
