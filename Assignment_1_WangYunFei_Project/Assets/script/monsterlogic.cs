using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum EnemyState
{
    Idle,
    Chase,
    Attack
}

public class monsterlogic : MonoBehaviour
{  
    const float AGGRO_RADIUS = 10.0f;
    const float ATTACK_RADIUS = 2.5f;

    GameObject m_player;
    playerlogic m_playerLogic;

    NavMeshAgent m_navMeshAgent;
    GameObject m_produce;
    produceenemylogic m_producelogic;
    [SerializeField]
    EnemyState m_enemyState = EnemyState.Idle;

    int m_health = 100;

    const float MAX_COOLDOWN = 0.5f;
    float m_cooldown = 0.0f;

    AudioSource m_audioSource;

    [SerializeField]
    AudioClip m_biteSound;

    [SerializeField]
    AudioClip m_woundSound;
    
    void Start()
    {
        m_player = GameObject.FindWithTag("Player");
        m_produce = GameObject.FindWithTag("produce");
        m_playerLogic = m_player.GetComponent<playerlogic>();
        m_producelogic = m_produce.GetComponent<produceenemylogic>();
        m_navMeshAgent = GetComponent<NavMeshAgent>();

        m_audioSource = GetComponent<AudioSource>();
        
    }

    void OnDrawGizmos()
    {
        Gizmos.color = new Color(255, 0, 0, 0.25f);
        Gizmos.DrawSphere(transform.position, AGGRO_RADIUS);

        Gizmos.color = new Color(0, 0, 255, 0.25f);
        Gizmos.DrawSphere(transform.position, ATTACK_RADIUS);
    }

    public void TakeDamage(int damage)
    {
        m_health -= damage;

        m_audioSource.PlayOneShot(m_woundSound);

        if (m_health <= 0)
        {
            m_producelogic.died_enemy_num++;
            m_producelogic.current_enemy_num--;
            Die();
        }
    }
    void Die()
    {
        Destroy(gameObject);
    }

    void Update()
    {
        if (m_player == null)
        {
            return;
        }

        float distance = Vector3.Distance(transform.position, m_player.transform.position);

        switch (m_enemyState)
        {
            case (EnemyState.Idle):
                m_navMeshAgent.isStopped = true;

                if (distance < AGGRO_RADIUS)
                {
                    m_enemyState = EnemyState.Chase;
                }
                break;

            case (EnemyState.Chase):
                m_navMeshAgent.isStopped = false;
                m_navMeshAgent.SetDestination(m_player.transform.position);

                if (distance < ATTACK_RADIUS)
                {
                    m_enemyState = EnemyState.Attack;
                }
                else if (distance > AGGRO_RADIUS)
                {
                    m_enemyState = EnemyState.Idle;
                }
                break;

            case (EnemyState.Attack):
                m_navMeshAgent.isStopped = true;

                if (m_cooldown <= 0.0f)
                {
                    m_playerLogic.TakeDamage(10);
                    m_audioSource.PlayOneShot(m_biteSound);
                    m_cooldown = MAX_COOLDOWN;
                }

                if (distance > ATTACK_RADIUS)
                {
                    m_enemyState = EnemyState.Chase;
                }
                break;
        }

        if (m_cooldown > 0.0f)
        {
            m_cooldown -= Time.deltaTime;
        }
    }
}
