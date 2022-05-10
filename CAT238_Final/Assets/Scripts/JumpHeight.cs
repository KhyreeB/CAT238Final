using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpHeight : MonoBehaviour

{
    private Rigidbody playerRb;
    public float buttonTime = 0.3f;
    public float jumpAmount = 20;
    float jumpTime;
    bool jumping; 

// Start is called before the first frame update
void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumping = true;
            jumpTime = 0;
        }
        if (jumping)
        {
            playerRb.velocity = new Vector3(playerRb.velocity.x, jumpAmount);
            jumpTime += Time.deltaTime;

        }
        if(Input.GetKeyUp(KeyCode.Space) && jumpTime > buttonTime)
        {
            jumping = false;
        }
    }
}
