using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class savemanager : MonoBehaviour
{
    public static savemanager Instance;

    playerlogic m_playerLogic;

    coinlogic[] m_coinLogics;
    getfireballlogic[] m_getfireballlogics;
    dielogic[] m_dielogics;
    enemydielogic[] m_enemydielogics;
    [SerializeField]
    TextMeshProUGUI m_bingonumTMP;
    int bingonum;
    // Start is called before the first frame update
    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        m_playerLogic = FindObjectOfType<playerlogic>();
        m_coinLogics = FindObjectsOfType<coinlogic>();
        m_getfireballlogics = FindObjectsOfType<getfireballlogic>();
        m_dielogics = FindObjectsOfType<dielogic>();
        m_enemydielogics = FindObjectsOfType<enemydielogic>();
        bingonum = 0;
        SetBINGOText();
    }

    // Update is called once per frame
    void Update()
    {   
        if (Input.GetKeyDown(KeyCode.S)|| Input.GetButton("Fire3"))
        {
            Save();
        }

        if (Input.GetKeyDown(KeyCode.L)||Input.GetButton("Fire2"))
        {
            Load();
        }
        bingonum = 0;
        for (int index = 0; index < m_coinLogics.Length; ++index)
        {
            if(m_coinLogics[index].m_coinState == CoinState.Inactive)
            {
                bingonum++;
            }
        }
        SetBINGOText();
    }

    public void Save()
    {
        m_playerLogic.Save();

        for (int index = 0; index < m_coinLogics.Length; ++index)
        {
            m_coinLogics[index].Save(index);
        }
        for (int index = 0; index < m_getfireballlogics.Length; ++index)
        {
            m_getfireballlogics[index].Save(index);
        }
        for (int index = 0; index < m_dielogics.Length; ++index)
        {
            m_dielogics[index].Save(index);
        }
        for (int index = 0; index < m_enemydielogics.Length; ++index)
        {
            m_enemydielogics[index].Save(index);
        }
        PlayerPrefs.Save();
    }

    public void Load()
    {
        m_playerLogic.Load();

        for (int index = 0; index < m_coinLogics.Length; ++index)
        {
            m_coinLogics[index].Load(index);
        }
        for (int index = 0; index < m_getfireballlogics.Length; ++index)
        {
            m_getfireballlogics[index].Load(index);
        }
        for (int index = 0; index < m_dielogics.Length; ++index)
        {
            m_dielogics[index].Load(index);
        }
        for (int index = 0; index < m_enemydielogics.Length; ++index)
        {
            m_enemydielogics[index].Load(index);
        }
    }
    void SetBINGOText()
    {
        m_bingonumTMP.text = "Bingo_num: " + bingonum;
    }
    void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
        {
            playerlogic mplayer = other.GetComponent<playerlogic>();
            {
                if (mplayer)
                {
                    Save();
                    Destroy(gameObject);
                }
            }
            // msave.Save();
            //Destroy(gameObject);

        }
    }
}
