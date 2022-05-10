using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BallPlayer : MonoBehaviour
{
    private Rigidbody playerRb;
    private GameObject focalPoint;
   
    private float speed = 300.0f;
    private float verticalInput;
    private float turnSpeed = 300.0f;
    private float horizontalInput;
    
    public float buttonTime = 0.3f;
    public float jumpHeight = 5;
    public float gravityScale = 10;
    public float cancelRate = 100;
    
    float jumpTime;

    bool jumping;
    bool jumpCancelled;
    bool isGrounded;




    // Start is called before the first frame update



    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");

        isGrounded = true;

    }

    // Update is called once per frame
    private void Update()
    {
        //Jumping
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            float jumpForce = Mathf.Sqrt(jumpHeight * -2 * (Physics.gravity.y));
            playerRb.AddForce(new Vector3(0, jumpForce), ForceMode.Impulse);
            jumping = true;
            jumpCancelled = false;
            jumpTime = 0;
            isGrounded = false;
        }
        if (jumping)
        {

            jumpTime += Time.deltaTime;


        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            jumpCancelled = true;
        }
        if (jumpTime > buttonTime)
        {
            jumping = false;
        }

        //Movement
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");
            playerRb.AddForce(Vector3.forward * Time.deltaTime * speed * verticalInput);

            transform.Rotate(Vector3.up, turnSpeed * verticalInput * Time.deltaTime);


            playerRb.AddForce(Vector3.right * Time.deltaTime * turnSpeed * horizontalInput);

            transform.position = playerRb.transform.position;
        }
    }
    private void FixedUpdate()
    {
        if (jumpCancelled && jumping && playerRb.velocity.y > 0)
        {
            playerRb.AddForce(Vector3.down * cancelRate);
        }
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Floor" && isGrounded == false)
        {
            isGrounded = true;
        }
        if (other.gameObject.CompareTag("Ground"))
        {
            Destroy(playerRb);
            SceneManager.LoadScene("Level One");
        }
        if (other.gameObject.CompareTag("Wall"))
        {
            Destroy(playerRb);
            SceneManager.LoadScene("Level One");
        }
        if (other.gameObject.CompareTag("Win"))
        {
  
            SceneManager.LoadScene("Level One");
        }
    }
     
}