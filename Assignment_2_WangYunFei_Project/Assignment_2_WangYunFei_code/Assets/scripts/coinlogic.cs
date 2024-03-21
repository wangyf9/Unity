using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum CoinState
{
    Inactive,
    Active
}

public class coinlogic : MonoBehaviour
{
    const float ROTATION_SPEED = 100.0f;

    public CoinState m_coinState = CoinState.Active;

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

    void FixedUpdate()
    {
        transform.Rotate(Vector3.right, Time.deltaTime * ROTATION_SPEED);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            SetCoinState(CoinState.Inactive);
            m_audioSource.PlayOneShot(m_eatding);
        }
    }

    void SetCoinState(CoinState coinState)
    {
        m_coinState = coinState;

        m_meshRenderer.enabled = m_coinState == CoinState.Active;
        m_collider.enabled = m_coinState == CoinState.Active;
    }

    public void Save(int index)
    {
        PlayerPrefs.SetInt("CoinState" + index, (int)m_coinState);
    }

    public void Load(int index)
    {
        CoinState coinState = (CoinState)PlayerPrefs.GetInt("CoinState" + index);

       // Debug.Log("Coin Number: " + index + " has state: " + coinState);
        SetCoinState(coinState);
    }
}
