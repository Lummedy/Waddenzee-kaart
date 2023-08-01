using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerMovement : NetworkBehaviour
{
    public float Xaxis, Yaxis;

    public Camera playerCamera;
    //dit dupliceren voor meer ui dingen
    public GameObject UIPopUp;

    //hoofd body van de prefab
    public GameObject PlayerMain;

    public float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        Xaxis = 0;
        Yaxis = 0;

        if (!isLocalPlayer)
        {
            playerCamera.gameObject.SetActive(false);
        }

        UIPopUp.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
        if (!isLocalPlayer)
        {
            //checks wether or not this is run by the client, makes it so you can only move your player
            return;
        }

        if (UIPopUp.activeSelf == false)
        {

            if (Input.GetKey("a"))
            {
                Xaxis = -2;
            }
            else if (Input.GetKey("d"))
            {
                Xaxis = 2;
            }
            else
            {
                Xaxis = 0;
            }

            if (Input.GetKey("w"))
            {
                Yaxis = 2;
            }
            else if (Input.GetKey("s"))
            {
                Yaxis = -2;
            }
            else
            {
                Yaxis = 0;
            }

            //part that moves the object
            transform.Translate(moveSpeed * Xaxis * Time.deltaTime, 0f, moveSpeed * Yaxis * Time.deltaTime);
        }
        if (Input.GetMouseButtonUp(0))
        {
            HandleInput();
            HandleInput2();
        }
        
        {
           
        }




    }
    void HandleInput()
    {
        Ray inputRay = playerCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(inputRay, out hit))
        {
            TouchCell(hit.point);
            if (isLocalPlayer)
            
                {
                    UIPopUp.SetActive(true);
                }
                
            
        }
    }

    void HandleInput2()
    {
        Ray inputRay = playerCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(inputRay, out hit))
        {
            Touch(hit.colliderInstanceID);
            if (isLocalPlayer)
            {
                UIPopUp.SetActive(true);

            }
        }
    }

    void TouchCell(Vector3 position)
    {
        position = transform.InverseTransformVector(position);
        Debug.Log("touched at " + position);
        if (isLocalPlayer)
        {
            PlayerMain.transform.position = position + Vector3.up * 3 + Vector3.back * 3;

        }

    }
    void Touch(int ID)
    {
        Debug.Log("touched " + ID);
    }

    public void Close()
    {
        
          UIPopUp.SetActive(false);
            Debug.Log("close"); 
    }

    public void TransportLauwersoog()
    {
        PlayerMain.transform.position = new Vector3(5.5f,1.6f,15.5f);
    }

    public void TransportGroningen()
    {
        PlayerMain.transform.position = new Vector3(26f, 2.4f, -1.9f);
    }

    public void TransportLeeuwarden()
    {
        PlayerMain.transform.position = new Vector3(-13.5f, 2.4f, -3.7f);
    }
}
