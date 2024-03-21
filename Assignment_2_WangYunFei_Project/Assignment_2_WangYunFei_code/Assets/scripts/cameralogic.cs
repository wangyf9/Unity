using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameralogic : MonoBehaviour
{
    GameObject m_player;
    Vector3 m_targetPos;

    // Start is called before the first frame update
    void Start()
    {
        m_player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        m_targetPos = transform.position;
        m_targetPos.x = m_player.transform.position.x;
        m_targetPos.y = m_player.transform.position.y + 4;
        transform.position = m_targetPos;
    }
}
