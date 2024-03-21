using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generatelogic : MonoBehaviour
{
    const float MAX_COOLDOWN = 2.0f;
    float m_cooldown = 0.0f;
    [SerializeField]
    AudioClip fireballsound;
    AudioSource m_audioSource;
    [SerializeField]
    Transform m_fireballSpawn;
    [SerializeField]
    Transform m_fireballSpawntwo;
    [SerializeField]
    Transform m_fireballSpawnthree;
    [SerializeField]
    Transform m_fireballSpawnfour;
    [SerializeField]
    Transform m_fireballSpawnfive;
    [SerializeField]
    Transform m_fireballSpawnsix;
    [SerializeField]
    Transform m_fireballSpawnseven;
    [SerializeField]
    GameObject m_fireballObject;
    // Start is called before the first frame update
    void Start()
    {
        m_audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        Shoot();
        if (m_cooldown > 0.0f)
        {
            m_cooldown -= Time.deltaTime;
        }
    }
    void Shoot()
    {
        if (m_cooldown <= 0.0f)
        {
            Instantiate(m_fireballObject, m_fireballSpawn.position, m_fireballSpawn.rotation);
            Instantiate(m_fireballObject, m_fireballSpawntwo.position, m_fireballSpawntwo.rotation);
            Instantiate(m_fireballObject, m_fireballSpawnthree.position, m_fireballSpawnthree.rotation);
            Instantiate(m_fireballObject, m_fireballSpawnfour.position, m_fireballSpawnfour.rotation);
            Instantiate(m_fireballObject, m_fireballSpawnfive.position, m_fireballSpawnfive.rotation);
            Instantiate(m_fireballObject, m_fireballSpawnsix.position, m_fireballSpawnsix.rotation);
            Instantiate(m_fireballObject, m_fireballSpawnseven.position, m_fireballSpawnseven.rotation);
            m_audioSource.PlayOneShot(fireballsound);
            m_cooldown = MAX_COOLDOWN;
        }
    }
    public void Die()
    {
        Destroy(gameObject);
    }

}
