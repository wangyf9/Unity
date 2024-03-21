using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deathlogic : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerlogic playerLogic = other.GetComponent<playerlogic>();
            if (playerLogic)
            {
                playerLogic.Die();
            }
        }
    }
}
