using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject obstacle;
    private Player PlayerScript;
    private float startDelay = 2;
    private float repeatRate = 10;
    private float spawnPos = 9;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
        PlayerScript = GameObject.Find("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void SpawnObstacle()
    {
        if (PlayerScript.gameOver == false)
        {
            Instantiate(obstacle, GenerateSpawnPosition(), obstacle.transform.rotation);
        }
    }

    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnPos, spawnPos);
        Vector3 randomPos = new Vector3(spawnPosX, 3, 0);

        return randomPos;
    }
}
