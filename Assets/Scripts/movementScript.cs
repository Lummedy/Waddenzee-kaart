using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class movementScript : MonoBehaviour
{
    public Transform[] target;
    public float speed;

    public int current;
    

    void Start()
    {

       
    }


    void Update()
    {
        if (transform.position != target[current].position)
        {
            Vector3 pos = Vector3.MoveTowards(transform.position, target[current].position, speed);
            GetComponent<Rigidbody>().MovePosition(pos);
        }
        else current = (current + 1) % target.Length;

        
    }
}
