using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class playerlogic : MonoBehaviour
{
    const float MOVEMENT_SPEED = 5.0f;
    const float GRAVITY = -0.981f;
    CharacterController m_characterController;

    float m_horizontalInput;
    float m_verticalInput;

    Vector3 m_movement;

    int m_health = 100;

    [SerializeField]
    TextMeshProUGUI m_healthTMP;

    void Start()
    {
        m_characterController = GetComponent<CharacterController>();
        SetHealthText();
    }

    void Update()
    {
        m_horizontalInput = Input.GetAxis("Horizontal");
        m_verticalInput = Input.GetAxis("Vertical");

        RotateCharacterTowardsMouseCursor();
    }

    void FixedUpdate()
    {
        m_movement.x = m_horizontalInput * MOVEMENT_SPEED * Time.deltaTime;
        m_movement.z = m_verticalInput * MOVEMENT_SPEED * Time.deltaTime;

        if (m_characterController.isGrounded)
        {
            m_movement.y = GRAVITY * Time.deltaTime;
        }
        else
        {
            m_movement.y += GRAVITY * Time.deltaTime;
        }

        m_characterController.Move(m_movement);
    }

    void RotateCharacterTowardsMouseCursor()
    {
        Vector3 mousePosInScreenSpace = Input.mousePosition;
        Vector3 playerPosInScreenSpace = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 directionInScreenSpace = mousePosInScreenSpace - playerPosInScreenSpace;

        float angle = Mathf.Atan2(directionInScreenSpace.y, directionInScreenSpace.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(-angle , Vector3.up);
    }

    public void TakeDamage(int damage)
    {
        m_health -= damage;
        SetHealthText();

        if (m_health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }

    void SetHealthText()
    {
        m_healthTMP.text = "HEALTH: " + m_health;
    }
    public void addhealth()
    {
        if (m_health <= 50)
        {
            m_health += 50;
        }
        else if (m_health > 50 && m_health < 100)
        {
           m_health = 100;
        }
        SetHealthText();
    }
}
