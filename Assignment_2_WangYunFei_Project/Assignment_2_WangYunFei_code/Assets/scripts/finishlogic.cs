using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finishlogic : MonoBehaviour
{
    [SerializeField]
    AudioClip fireballsound;
    AudioSource m_audioSource;
    const float MAX_COOLDOWN = 0.1f;
    float m_cooldown = 0.0f;
    MeshRenderer m_meshRenderer;
    Collider m_collider;
    void Start()
    {
        m_cooldown = MAX_COOLDOWN;
        m_audioSource = GetComponent<AudioSource>();
        m_meshRenderer = GetComponent<MeshRenderer>();
        m_collider = GetComponent<Collider>();
    }
    void Update()
    {
        if (m_cooldown > 0.0f)
        {
            m_cooldown -= Time.deltaTime;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerlogic playerLogic = other.GetComponent<playerlogic>();
            if (playerLogic)
            {
                if (m_cooldown <= 0.0f)
                {
                    playerLogic.m_iswin = true;
                    m_cooldown = MAX_COOLDOWN;
                    m_audioSource.PlayOneShot(fireballsound);

                }

                m_meshRenderer.enabled = false;
                m_collider.enabled = false;
            }

        }
    }
}
