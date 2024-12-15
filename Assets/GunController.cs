using UnityEngine;
using System.Collections;

public class GunController : MonoBehaviour
{
    public Camera mainCamera;
    public GameObject bulletPrefab;
    public Transform gunBarrel;
    public int maxAmmo = 6;

    private int currentAmmo;
    public GameGUI gameGUI;

    void Start()
    {
        currentAmmo = maxAmmo;
        UpdateAmmoUI();
    }

    void Update()
    {
        MoveGunToMouse();

        if (Input.GetMouseButtonDown(0))
        {
            if (currentAmmo > 0)
            {
                Shoot();
            }
            else
            {
                gameGUI.PlayOutOfAmmoSound();
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(Reload());
        }
    }

    private void MoveGunToMouse()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 10f;
        transform.position = mainCamera.ScreenToWorldPoint(mousePos);
    }

    private void Shoot()
    {
        int bulletFiredIndex = currentAmmo - 1;
        currentAmmo--;
        gameGUI.UpdateAmmoUI(bulletFiredIndex);
        gameGUI.PlayShootSound();

        Debug.Log("GunController: Bullet shot, current ammo: " + currentAmmo);

        if (currentAmmo == 0)
        {
            StartCoroutine(Reload());
        }
    }

    private IEnumerator Reload()
    {
        Debug.Log("Reloading...");
        yield return new WaitForSeconds(2f);

        currentAmmo = maxAmmo;
        UpdateAmmoUI();
        Debug.Log("Reloaded");
    }

    private void UpdateAmmoUI()
    {
        gameGUI.UpdateAmmoUI(-1);
    }
}
