using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Close : MonoBehaviour
{
    [SerializeField]
    private GameObject ThingToClose;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnMouseDown()
    {
        
            {
             ThingToClose.SetActive(false);
             }
    }
}
