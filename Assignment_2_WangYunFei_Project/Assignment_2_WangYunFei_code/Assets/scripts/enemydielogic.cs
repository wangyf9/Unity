using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum enemystate
{
    Inactive,
    Active
}
public class enemydielogic : MonoBehaviour
{
    // [SerializeField]
    // GameObject m_explosionObject;
    // Start is called before the first frame update
    const float ROTATION_SPEED = 100.0f;

    public enemystate m_obState = enemystate.Active;

    MeshRenderer m_meshRenderer;
    Collider m_collider;
    layserlogic m_la;
    void Start()
    {
        m_meshRenderer = GetComponent<MeshRenderer>();
        m_collider = GetComponent<Collider>();
        m_la = GetComponent<layserlogic>();
    }
    public void die()
    {
        // Instantiate(m_explosionObject, transform.position, Quaternion.identity);
        Destroy(gameObject);

    }
    public void SetCoinState(enemystate obState)
    {
        m_obState = obState;

        m_meshRenderer.enabled = m_obState == enemystate.Active;
        m_collider.enabled = m_obState == enemystate.Active;
        m_la.enabled = m_obState == enemystate.Active;
    }

    public void Save(int index)
    {
        PlayerPrefs.SetInt("eObState" + index, (int)m_obState);
    }

    public void Load(int index)
    {
        enemystate obState = (enemystate)PlayerPrefs.GetInt("eObState" + index);

        // Debug.Log("Coin Number: " + index + " has state: " + coinState);
        SetCoinState(obState);
    }
}
