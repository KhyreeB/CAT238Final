using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void onCollisionEnter(Collision c)
    {
        if (c.gameObject.tag == "Player")
        {
            Destroy(c.gameObject);
        }
    }
}

