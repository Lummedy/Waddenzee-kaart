using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class CameraZoom : NetworkBehaviour
{

    public float Zaxis;
    public float moveSpeed;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isLocalPlayer)
        {
            //checks wether or not this is run by the client, makes it so you can only move your player
            return;
        }

        

        if (Input.GetKey("q"))
        {
            if (transform.position.y > 0)
            {
                Zaxis = -1;
                
            }
            else Zaxis = 0;

        }
        else if (Input.GetKey("e"))
        {
            if (transform.position.y < 3)
            {
                Zaxis = 1;

            }
            else Zaxis = 0;
        }
        else
        {
            Zaxis = 0;
        }

        transform.Translate(0f, moveSpeed * Zaxis * Time.deltaTime, 0f);
    }
}
