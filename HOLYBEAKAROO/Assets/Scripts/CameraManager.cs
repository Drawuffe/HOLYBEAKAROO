using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.Cinemachine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager Instance;
    public GameObject cameraFollow;  
    public string sceneName;
    public int sceneIndex;
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

    }

    private void Update()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        //string sceneName = currentScene.name;
        sceneIndex = currentScene.buildIndex;

        CameraCheck();
    }

    public void CameraCheck()
    {
        Debug.Log("Running");
        //Scene currentScene = SceneManager.GetActiveScene();
        //sceneName = currentScene.name;
       if(sceneIndex == 1)
       {
            cameraFollow.SetActive(false);
       }

       if (sceneIndex == 2)
       {
            cameraFollow.SetActive(false);
       }

       if(sceneIndex == 3)
       {
            cameraFollow.SetActive(true);
       }
    }


}
