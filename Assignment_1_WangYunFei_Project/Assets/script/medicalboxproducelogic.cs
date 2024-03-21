using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class medicalboxproducelogic : MonoBehaviour
{
    /*[SerializeField]
    GameObject m_medicalPrefab;
    [SerializeField]
    Transform m_medical;
    public int medicalbox = 5;
    public int totalnum = 0;*/
    public int current_medicalbox;
    // Start is called before the first frame update
    void Start()
    {
        current_medicalbox = 1;
        /*totalnum++;
        Instantiate(m_medicalPrefab, m_medical.position, m_medical.rotation);*/
    }

    // Update is called once per frame
    void Update()
    {
       /* if(current_medicalbox == 0 && totalnum < 5)
        {
            Instantiate(m_medicalPrefab, m_medical.position, m_medical.rotation);
            current_medicalbox = 1;
            totalnum++;
        }*/
    }
    void producemedical()
    {
       // Instantiate(m_medicalPrefab, m_medical.position, m_medical.rotation);

    }
    void die()
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            playerlogic m_playlogic = collider.GetComponent<playerlogic>();
            if (m_playlogic)
            {
                current_medicalbox = 0;
                m_playlogic.addhealth();
            }
            Destroy(gameObject);
        }
    }
}
