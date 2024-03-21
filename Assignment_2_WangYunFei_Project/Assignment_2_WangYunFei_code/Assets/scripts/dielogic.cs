using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum objectstate
{
    Inactive,
    Active
}
public class dielogic : MonoBehaviour
{
    // [SerializeField]
    // GameObject m_explosionObject;
    // Start is called before the first frame update
    const float ROTATION_SPEED = 100.0f;

    public objectstate m_obState = objectstate.Active;

    MeshRenderer m_meshRenderer;
    Collider m_collider;
    void Start()
    {
        m_meshRenderer = GetComponent<MeshRenderer>();
        m_collider = GetComponent<Collider>();
    }
    public void die()
    {
       // Instantiate(m_explosionObject, transform.position, Quaternion.identity);
        Destroy(gameObject);

    }
    public void SetCoinState(objectstate obState)
    {
        m_obState = obState;

        m_meshRenderer.enabled = m_obState == objectstate.Active;
        m_collider.enabled = m_obState == objectstate.Active;
    }

    public void Save(int index)
    {
        PlayerPrefs.SetInt("ObState" + index, (int)m_obState);
    }

    public void Load(int index)
    {
        objectstate obState = (objectstate)PlayerPrefs.GetInt("ObState" + index);

        // Debug.Log("Coin Number: " + index + " has state: " + coinState);
        SetCoinState(obState);
    }
}
