using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float speed = 10f;
    private Rigidbody playerRb;
    public float horizontalInput;
    float xRange = 23.7f;

    public float jumpForce = 16;
    public float gravityModifier;
    public bool isOnTheGround = true;
    public bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        ConstrainPlayerPosition();
    }

    void MovePlayer()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        //move left right
        if (!gameOver)
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);
            // playerAnim.SetTrigger("Jump_trig");
            // splash.Stop();
            // playerAudio.PlayOneShot(jump, 1.0f);
        }

        //jump
        if (Input.GetKeyDown(KeyCode.Space) && isOnTheGround && !gameOver)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnTheGround = false;
            // playerAnim.SetTrigger("Jump_trig");
            // splash.Stop();
            // playerAudio.PlayOneShot(jump, 1.0f);
        }
    }

    void ConstrainPlayerPosition()
    {
        //max screen
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }

        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
    }
    

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnTheGround = true;
            //splash.Play();
        }

        if (collision.gameObject.CompareTag("Obstacle"))
        {
            transform.position = new Vector3(-20, 0, 0);
            gameOver = true;
            Debug.Log("LOL Noob!");
            // playerAnim.SetBool("Death_b", true);
            // playerAnim.SetInteger("DeathType_int", 1);
            // explosion.Play();
            // splash.Stop();
            // playerAudio.PlayOneShot(death, 1.0f);
        }
    }
}
