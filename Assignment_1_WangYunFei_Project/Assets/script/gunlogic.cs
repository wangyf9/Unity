using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class gunlogic : MonoBehaviour
{
    [SerializeField]
    GameObject m_bulletPrefab;

    [SerializeField]
    Transform m_spawnPoint;

    const int MAX_AMMO = 10;
    int m_ammo = MAX_AMMO;

    [SerializeField]
    TextMeshProUGUI m_ammoTMP;

    const float MAX_COOLDOWN = 0.5f;
    float m_cooldown = 0.0f;

    AudioSource m_audioSource;

    [SerializeField]
    AudioClip m_gunShotSound;

    [SerializeField]
    AudioClip m_gunReloadSound;

    [SerializeField]
    AudioClip m_gunEmptySound;

    void Start()
    {
        m_audioSource = GetComponent<AudioSource>();

        SetAmmoText();
    }
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            Shoot();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }

        if (m_cooldown > 0.0f)
        {
            m_cooldown -= Time.deltaTime;
        }
    }

    void Shoot()
    {
        if (m_cooldown <= 0.0f)
        {
            if (m_ammo > 0)
            {
                Instantiate(m_bulletPrefab, m_spawnPoint.position, m_spawnPoint.rotation);
                --m_ammo;
                SetAmmoText();

                m_audioSource.PlayOneShot(m_gunShotSound);
            }
            else
            {
                m_audioSource.PlayOneShot(m_gunEmptySound);
            }

            m_cooldown = MAX_COOLDOWN;
        }
    }

    void Reload()
    {
        m_ammo = MAX_AMMO;
        m_cooldown = MAX_COOLDOWN;

        SetAmmoText();

        m_audioSource.PlayOneShot(m_gunReloadSound);
    }

    void SetAmmoText()
    {
        m_ammoTMP.text = "AMMO: " + m_ammo;
    }
}
