using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class MenuActivation : NetworkBehaviour
{
    public GameObject gameObjectToEnable;
    // Start is called before the first frame update
    void Start()
    {
        gameObjectToEnable.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
