using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireballdownlogic : MonoBehaviour
{
    const float SPEED = 15.0f;
    Rigidbody m_rigidBody;

    [SerializeField]
    GameObject m_explosionObject;

    // Start is called before the first frame update
    void Start()
    {
        m_rigidBody = GetComponent<Rigidbody>();
        m_rigidBody.velocity = transform.forward * SPEED;
        Destroy(gameObject, 0.75f);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerlogic playerLogic = other.GetComponent<playerlogic>();
            if (playerLogic)
            {
                playerLogic.Die();

                Instantiate(m_explosionObject, transform.position, Quaternion.identity);

                Destroy(gameObject);
            }
        }
    }
}
