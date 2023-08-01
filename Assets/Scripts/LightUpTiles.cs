using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
public class LightUpTiles : MonoBehaviour
{
    public GameObject Hex;
    public Material Green;
    

    void OnMouseOver()
    {
        var hexRenderer = Hex.GetComponent<Renderer>();

        hexRenderer.material.SetColor("_Color", Color.green);
    }

    void OnMouseExit()
    {
        GetComponent<Renderer>().material = Green;
        
    }
}
