using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private Rigidbody enemyRb;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -1 || transform.position.y > 40) { 
            Destroy(gameObject); 
        }

        if (transform.position.x < -26 || transform.position.x > 26) { 
            Destroy(gameObject); 
        }

        if (transform.position.z < -26) { 
            Destroy(gameObject); 
        }
    }
}
