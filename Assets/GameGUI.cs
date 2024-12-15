using System.Collections;
using UnityEngine;

public class GameGUI : MonoBehaviour
{
    public GameObject bulletPrefab;
    public RectTransform ammoContainer;
    public int maxBullets = 6;
    public AudioClip shootSound;
    public AudioClip outOfAmmoSound;

    private GameObject[] bullets;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        InitializeBullets();
    }

    private void InitializeBullets()
    {
        bullets = new GameObject[maxBullets];
        float bulletSpacing = 10f;
        float bulletWidth = 150f;
        float bulletHeight = 180f;

        for (int i = 0; i < maxBullets; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab, ammoContainer);
            bullet.name = $"Bullet{i}";
            RectTransform bulletRect = bullet.GetComponent<RectTransform>();
            if (bulletRect != null)
            {
                bulletRect.sizeDelta = new Vector2(bulletWidth, bulletHeight);
                bulletRect.anchoredPosition = new Vector2(i * (bulletWidth + bulletSpacing), -10);
            }
            bullets[i] = bullet;
        }
    }

    public void UpdateAmmoUI(int bulletFiredIndex)
    {
        if (bulletFiredIndex >= 0 && bulletFiredIndex < bullets.Length)
        {
            bullets[bulletFiredIndex].SetActive(false);
            Debug.Log("GameGUI: Ammo UI updated, bullet fired index: " + bulletFiredIndex);
        }
        else if (bulletFiredIndex == -1)
        {
            for (int i = 0; i < bullets.Length; i++)
            {
                bullets[i].SetActive(true);
            }
            Debug.Log("GameGUI: Ammo UI reloaded, all bullets shown.");
        }
        else
        {
            Debug.LogWarning("GameGUI: Invalid bullet fired index: " + bulletFiredIndex);
        }
    }

    public void PlayShootSound()
    {
        if (audioSource != null && shootSound != null)
        {
            audioSource.PlayOneShot(shootSound);
        }
    }

    public void PlayOutOfAmmoSound()
    {
        if (audioSource != null && outOfAmmoSound != null)
        {
            audioSource.PlayOneShot(outOfAmmoSound);
        }
    }
}
