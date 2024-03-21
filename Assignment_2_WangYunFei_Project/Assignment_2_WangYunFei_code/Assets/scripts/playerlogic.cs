using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class playerlogic : MonoBehaviour
{
    const float MOVEMENT_SPEED = 5.0f;
    const float GRAVITY = 0.981f;
    const float JUMP_HEIGHT = 0.25f;

    float m_horizontalInput;
    myfireballlogic m_getfirelogic;
    Vector3 m_movement;

    CharacterController m_characterController;
    Animator m_animator;
    public int m_level = 0;
    bool m_isDead = false;
    bool m_isJumping = false;

    public bool m_iswin = false;
    [SerializeField]
    TextMeshProUGUI m_winTMP;
    /* Rigidbody rb;
     left charleftscript;
     moveleft charmoveleftscript;
     moverightlogic charmoverightscript;*/
    // Start is called before the first frame update
    void Start()
    {
        m_getfirelogic = GetComponent<myfireballlogic>();
        m_characterController = GetComponent<CharacterController>();
        m_animator = GetComponent<Animator>();
        m_getfirelogic.enabled = false;

        //rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_isDead)
        {
            return;
        }
        m_horizontalInput = Input.GetAxis("Horizontal");
        m_animator.SetFloat("horizontalinput", Mathf.Abs(m_horizontalInput));

        if (Input.GetButtonDown("Jump") && m_characterController.isGrounded)
        {
            m_isJumping = true;
        }
        if (m_level > 0)
        {
            m_getfirelogic.enabled = true;
        }
        if(m_iswin == true)
        {

            SetAmmoText();
        }
        else if(m_iswin == false)
        {
            SetcontinueAmmoText();
        }
    }

    public void Save()
    {
        // Position
        PlayerPrefs.SetFloat("PlayerPosX", transform.position.x);
        PlayerPrefs.SetFloat("PlayerPosY", transform.position.y);
        PlayerPrefs.SetFloat("PlayerPosZ", transform.position.z);

        // Rotation
        PlayerPrefs.SetFloat("PlayerRotX", transform.rotation.eulerAngles.x);
        PlayerPrefs.SetFloat("PlayerRotY", transform.rotation.eulerAngles.y);
        PlayerPrefs.SetFloat("PlayerRotZ", transform.rotation.eulerAngles.z);
    }

    public void Load()
    {
        // Position
        float posX = PlayerPrefs.GetFloat("PlayerPosX");
        float posY = PlayerPrefs.GetFloat("PlayerPosY");
        float posZ = PlayerPrefs.GetFloat("PlayerPosZ");

        // Rotation
        float rotX = PlayerPrefs.GetFloat("PlayerRotX");
        float rotY = PlayerPrefs.GetFloat("PlayerRotY");
        float rotZ = PlayerPrefs.GetFloat("PlayerRotZ");

        // Set Position
        m_characterController.enabled = false;
        transform.position = new Vector3(posX, posY, posZ);
        m_characterController.enabled = true;

        // Set Rotation
        transform.rotation = Quaternion.Euler(rotX, rotY, rotZ);
    }

    void FixedUpdate()
    {
        m_movement.x = m_horizontalInput * MOVEMENT_SPEED * Time.deltaTime;

        ApplyGravity();

        HandleJump();

        UpdateLookDirection();

        m_characterController.Move(m_movement);

    }

    void ApplyGravity()
    {
        if (m_characterController.isGrounded)
        {
            m_movement.y = -GRAVITY * Time.deltaTime;
        }
        else
        {
            m_movement.y -= GRAVITY * Time.deltaTime;
        }
    }

    void HandleJump()
    {
        if (m_isJumping)
        {
            m_movement.y = JUMP_HEIGHT;
            m_isJumping = false;
        }
    }

    void UpdateLookDirection()
    {
        // Look to the right
        if (m_horizontalInput > 0)
        {
            transform.rotation = Quaternion.Euler(0, 90, 0);
        }
        // Look to the left
        else if (m_horizontalInput < 0)
        {
            transform.rotation = Quaternion.Euler(0, -90, 0);
        }
    }

    public void Die()
    {
        m_animator.SetTrigger("Die");
        m_isDead = true;
        StartCoroutine(Respawn());
    }

    IEnumerator Respawn()
    {

        yield return new WaitForSeconds(2.0f); 
        m_characterController.enabled = false;
        m_characterController.enabled = true;
        m_isDead = false;
        m_animator.SetTrigger("Respawn");
        savemanager.Instance.Load();

    }
    /* private void OnCollisionStay(Collision other)    
     {
         if(other.gameObject.CompareTag("moveleft"))
         {
             charmoveleftscript = other.gameObject.GetComponent<moveleft>();
         }
         else if (other.gameObject.CompareTag("left"))
         {
             charleftscript = other.gameObject.GetComponent<left>();
         }
         else if (other.gameObject.CompareTag("moveright"))
         {
             charmoverightscript = other.gameObject.GetComponent<moverightlogic>();
         }
     }
     private void OnCollisionExit(Collision other)   
     {
         charmoveleftscript = null;
         charmoverightscript = null;
         charleftscript = null;
     }*/
    void SetAmmoText()
    {
        m_winTMP.text = "You Win !!!";
    }
    void SetcontinueAmmoText()
    {
        m_winTMP.text = "Come on !!!";
    }
}
