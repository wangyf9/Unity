using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class misslogic : MonoBehaviour
{
    [SerializeField]
    float MAX_COOLDOWN;
    //const float MAX_COOLDOWN = 1.5f;
    float m_cooldown = 0.0f;
    float m_cooldown_another = 0.0f;
    MeshRenderer m_meshRenderer;
    Collider m_collider;
    // Start is called before the first frame update
    void Start()
    {
        m_cooldown = MAX_COOLDOWN;
        m_cooldown_another = MAX_COOLDOWN;
        m_meshRenderer = GetComponent<MeshRenderer>();
        m_collider = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_meshRenderer.enabled == true)
        {
            if (m_cooldown > 0.0f)
            {
                m_cooldown -= Time.deltaTime;
            }
            if (m_cooldown <= 0.0f)
            {
                m_cooldown = MAX_COOLDOWN;
                m_meshRenderer.enabled = false;
                m_collider.enabled = false;
            }
        }
        else if (m_meshRenderer.enabled == false)
        {
            if (m_cooldown_another > 0.0f)
            {
                m_cooldown_another -= Time.deltaTime;
            }
            if (m_cooldown_another <= 0.0f)
            {
                m_cooldown_another = MAX_COOLDOWN;
                m_meshRenderer.enabled = true;
                m_collider.enabled = true;
            }
        }


    }

}
