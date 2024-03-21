using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moverightlogic : MonoBehaviour
{
    // Start is called before the first frame update
    public bool whetherright = true;
    public float speed = 0.6f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (whetherright)
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
            if (transform.position.x >= 37)
            {
                whetherright = false;
            }
        }
        else
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
            if (transform.position.x <= 33)
            {
                whetherright = true;
            }
        }
       
    }
}
