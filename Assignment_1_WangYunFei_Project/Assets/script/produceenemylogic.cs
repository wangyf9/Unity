using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class produceenemylogic : MonoBehaviour
{
    [SerializeField]
    GameObject m_enemyPrefab;
    [SerializeField]
    Transform m_enemyproducingPoint;
    public int enemy_num = 4;
    public int current_enemy_num;
    public int died_enemy_num;
    public int remaingingnum;
    [SerializeField]
    TextMeshProUGUI m_numTMP;
    [SerializeField]
    TextMeshProUGUI successTMP;

    AudioSource m_audioSource;

    [SerializeField]
    AudioClip successSound;
    // Start is called before the first frame update
    void Start()
    {
        m_audioSource = GetComponent<AudioSource>();
        produceenemy();
        current_enemy_num = 1;
        died_enemy_num = 0;
        remaingingnum = enemy_num;
        enemynummenber();
    }

    // Update is called once per frame
    void Update()
    {
        enemynummenber();
        if (current_enemy_num < 1 && died_enemy_num < 4)
        {
            produceenemy();
            current_enemy_num++;
        }
        if(died_enemy_num >= 4)
        {
            successTMP.text = "You win!";
            m_audioSource.PlayOneShot(successSound);
            //die();
        }
        else
        {
            successTMP.text = "Continuing!";
        }

    }
    void produceenemy()
    {
        Instantiate(m_enemyPrefab, m_enemyproducingPoint.position, m_enemyproducingPoint.rotation);
    }
    void enemynummenber() {
        remaingingnum = enemy_num - died_enemy_num;
        m_numTMP.text = "Monsters: "+ remaingingnum;

    }

    void die()
    {
        Destroy(gameObject);
    }
}

