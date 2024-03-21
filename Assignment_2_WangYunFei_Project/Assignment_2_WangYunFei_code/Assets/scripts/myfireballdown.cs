using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class myfireballdown : MonoBehaviour
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
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "object")
        {
            dielogic enemy = other.GetComponent<dielogic>();
            if (enemy)
            {
                enemy.SetCoinState(objectstate.Inactive);

                Instantiate(m_explosionObject, transform.position, Quaternion.identity);

                Destroy(gameObject);
            }
        }
        else if (other.tag == "enemy")
        {
            enemydielogic enemy = other.GetComponent<enemydielogic>();
            if (enemy)
            {
                enemy.SetCoinState(enemystate.Inactive);

                Instantiate(m_explosionObject, transform.position, Quaternion.identity);

                Destroy(gameObject);
            }
        }
    }
}
