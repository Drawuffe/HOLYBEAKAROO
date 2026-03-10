using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.Cinemachine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager Instance;
    public GameObject cameraFollow;  
    public string sceneName;
    //public CinemachineCamera followCam;

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

    private void Start()
    {
        
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

        /*if(sceneName == "0_StartingScene")
        {
            followCam.enabled = false;
        }

        if (sceneName == "1_InteriorBar")
        {
            followCam.enabled = false;
        }

        if (sceneName == "2_StartLevel")
        {
            followCam.enabled = true;
            
        }*/
    }

    /*public void CameraCheck()
    {
        Debug.Log("Running");
        Scene currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
       if(sceneName == "0_StartScene")
       {
            
            cameraFollow.SetActive(false);
           
       }
       if (sceneName == "1_InteriorBar")
       {
            cameraFollow.SetActive(false);
       }
       if(sceneName == "2_StartLevel")
       {
            cameraFollow.SetActive(true);

       }
    
    }*/


}
