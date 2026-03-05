using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AmmoCount : MonoBehaviour
{
    //public int currentAmmo;
    public PlayerMovement playerMovement;
    public Image[] bulletCount;
    int bullets;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<TextMeshProUGUI>().enabled = true;
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        //AmmoCounter();
    }

    private void LateUpdate()
    {
        AmmoCounter();
    }

    // Update is called once per frame
    void Update()
    {
        bullets = playerMovement.currentAmmo;

        switch (bullets)
        {
            case 7:
                foreach (Image img in bulletCount)
                {
                    //when your ammo is max, all the images will be enabled 
                    img.gameObject.SetActive(true);
                }
                break;

            case 6:
                bulletCount[0].gameObject.SetActive(true);
                bulletCount[1].gameObject.SetActive(true);
                bulletCount[2].gameObject.SetActive(true);
                bulletCount[3].gameObject.SetActive(true);
                bulletCount[4].gameObject.SetActive(true);
                bulletCount[5].gameObject.SetActive(true);
                bulletCount[6].gameObject.SetActive(false);
                break;

            case 5:
                bulletCount[0].gameObject.SetActive(true);
                bulletCount[1].gameObject.SetActive(true);
                bulletCount[2].gameObject.SetActive(true);
                bulletCount[3].gameObject.SetActive(true);
                bulletCount[4].gameObject.SetActive(true);
                bulletCount[5].gameObject.SetActive(false);
                bulletCount[6].gameObject.SetActive(false);
                break;

            case 4:
                bulletCount[0].gameObject.SetActive(true);
                bulletCount[1].gameObject.SetActive(true);
                bulletCount[2].gameObject.SetActive(true);
                bulletCount[3].gameObject.SetActive(true);
                bulletCount[4].gameObject.SetActive(false);
                bulletCount[5].gameObject.SetActive(false);
                bulletCount[6].gameObject.SetActive(false);
                break;

            case 3:
                bulletCount[0].gameObject.SetActive(true);
                bulletCount[1].gameObject.SetActive(true);
                bulletCount[2].gameObject.SetActive(true);
                bulletCount[3].gameObject.SetActive(false);
                bulletCount[4].gameObject.SetActive(false);
                bulletCount[5].gameObject.SetActive(false);
                bulletCount[6].gameObject.SetActive(false);
                break;

            case 2:
                bulletCount[0].gameObject.SetActive(true);
                bulletCount[1].gameObject.SetActive(true);
                bulletCount[2].gameObject.SetActive(false);
                bulletCount[3].gameObject.SetActive(false);
                bulletCount[4].gameObject.SetActive(false);
                bulletCount[5].gameObject.SetActive(false);
                bulletCount[6].gameObject.SetActive(false);
                break;

            case 1:
                bulletCount[0].gameObject.SetActive(true);
                bulletCount[1].gameObject.SetActive(false);
                bulletCount[2].gameObject.SetActive(false);
                bulletCount[3].gameObject.SetActive(false);
                bulletCount[4].gameObject.SetActive(false);
                bulletCount[5].gameObject.SetActive(false);
                bulletCount[6].gameObject.SetActive(false);
                break;

            case 0:
                bulletCount[0].gameObject.SetActive(false);
                bulletCount[1].gameObject.SetActive(false);
                bulletCount[2].gameObject.SetActive(false);
                bulletCount[3].gameObject.SetActive(false);
                bulletCount[4].gameObject.SetActive(false);
                bulletCount[5].gameObject.SetActive(false);
                bulletCount[6].gameObject.SetActive(false);

                Debug.Log("Out of Bullets");
                break;
        }
    }

    public void AmmoCounter()
    {
        GetComponent<TextMeshProUGUI>().text = playerMovement.currentAmmo + "/" + playerMovement.maxAmmo;
    }
}
