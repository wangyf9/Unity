using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checksavelogic : MonoBehaviour
{
    //savemanager msave;
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
        {
            playerlogic mplayer = other.GetComponent<playerlogic>();
            {
                if (mplayer)
                {
                    mplayer.Save();
                    Destroy(gameObject);
                }
            }
           // msave.Save();
            //Destroy(gameObject);

        }
    }
}
