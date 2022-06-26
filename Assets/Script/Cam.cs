using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    public GameObject player;
    Vector3 offset = new Vector3(0, 5, -25);

    float xRange = 13f;
    public bool max = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (max == false)
        {
            transform.position = player.transform.position + offset;
        }

        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
            max = true;
        }

        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
            max = true;
        }

        if (transform.position.x > -xRange)
        {
            max = false;
        }

        if (transform.position.x < xRange)
        {
            max = false;
        }
    }
}
