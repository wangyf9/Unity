using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireballlogic : MonoBehaviour
{
    const float MAX_COOLDOWN = 2.4f;
    float m_cooldown = 0.0f;
    [SerializeField]
    AudioClip fireballsound;
    AudioSource m_audioSource;
    [SerializeField]
    Transform m_fireballSpawn;
    Animator m_animator;
    [SerializeField]
    GameObject m_fireballObject;
    // Start is called before the first frame update
    void Start()
    {
        m_audioSource = GetComponent<AudioSource>();
        m_animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        m_animator.SetTrigger("fire");
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
            m_audioSource.PlayOneShot(fireballsound);
            m_cooldown = MAX_COOLDOWN;
        }
    }
    public void Die()
    {
        Destroy(gameObject);
    }

}
