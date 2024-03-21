using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum fireballstate
{
    Inactive,
    Active
}

public class getfireballlogic : MonoBehaviour
{

    public fireballstate m_fireballstate = fireballstate.Active;

    MeshRenderer m_meshRenderer;
    Collider m_collider;
    [SerializeField]
    AudioClip m_eatding;
    AudioSource m_audioSource;
    void Start()
    {
        m_meshRenderer = GetComponent<MeshRenderer>();
        m_collider = GetComponent<Collider>();
        m_audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerlogic playerLogic = other.GetComponent<playerlogic>();
            setfireballstate(fireballstate.Inactive);
            m_audioSource.PlayOneShot(m_eatding);
            if (playerLogic)
            {
                playerLogic.m_level++;
            }

        }
    }

    void setfireballstate(fireballstate fireState)
    {
        m_fireballstate = fireState;

        m_meshRenderer.enabled = m_fireballstate == fireballstate.Active;
        m_collider.enabled = m_fireballstate == fireballstate.Active;
    }

    public void Save(int index)
    {
        PlayerPrefs.SetInt("FireState" + index, (int)m_fireballstate);
    }

    public void Load(int index)
    {
        fireballstate fireState = (fireballstate)PlayerPrefs.GetInt("FireState" + index);

        // Debug.Log("Coin Number: " + index + " has state: " + coinState);
        setfireballstate(fireState);
    }
}
