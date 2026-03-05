using UnityEngine;
using UnityEngine.InputSystem;

public class BulletShoot : MonoBehaviour
{
    [Header("BulletInfo")]
    public GameObject bulletPrefab;
    public Transform bulletStart;
    public bool canFire = true;
    private float timer;
    public float timeBetwFiring;

    public GameObject reticleLocation;
    public Transform lastAimPos;

    private void Update()
    {
        //Vector3 lastRetLocation = reticleLocation.transform;
    }

    public void Fire(InputAction.CallbackContext context)
    {
        if (!Mouse.current.leftButton.IsPressed())
        {
            /*lastAimPos = reticleLocation.transform;
            Debug.Log($"lastAimPos = {lastAimPos}");*/
            GameObject firedBullet = Instantiate(bulletPrefab, bulletStart.position, Quaternion.identity);
            Debug.Log("fired");

            /*if(firedBullet.transform == lastAimPos.transform)
            {
                Destroy(firedBullet);
                Debug.Log("Destroyed at Site");
            }*/
        }
    }
}
