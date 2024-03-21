using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movelogic : MonoBehaviour
{
    bool whetherup = true;
    float speed = 3.2f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (whetherup)
        {
            transform.Translate(Vector3.up * Time.deltaTime * speed);
            if (transform.position.y >= 5)
            {
                whetherup = false;
            }
        }
        else
        {
            transform.Translate(Vector3.down * Time.deltaTime * speed);
            if (transform.position.y <= -5)
            {
                whetherup = true;
            }
        }

    }
}
