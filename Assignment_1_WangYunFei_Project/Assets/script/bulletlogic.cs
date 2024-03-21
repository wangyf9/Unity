using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletlogic : MonoBehaviour
{
    const float SPEED = 15.0f;
    Rigidbody m_rigidbody;
    const float MAX_COOLDOWN = 0.1f;
    float m_cooldown = 0.0f;
    void Start()
    {
        m_rigidbody = GetComponent<Rigidbody>();
        m_rigidbody.velocity = SPEED * transform.up;
        m_cooldown = MAX_COOLDOWN;
    }
    void Update()
    {
        if (m_cooldown > 0.0f)
        {
            m_cooldown -= Time.deltaTime;
        }
    }

    void OnCollisionEnter(Collision collision)
    {   

        if (collision.collider.tag == "monster")
        {
            monsterlogic zombieLogic = collision.collider.GetComponent<monsterlogic>();
                if (zombieLogic)
                {
                    if (m_cooldown <= 0.0f)
                    {
                        zombieLogic.TakeDamage(50);
                        m_cooldown = MAX_COOLDOWN;
                    }
                }
        }

        // Destroy the Bullet
        Destroy(gameObject);
    }
}
