using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour {
    public Camera freeCam;
    public Camera playerCam;
    private bool playerActive = true;
    void Update()
    {
        if (Input.GetKeyDown("e"))
        {
            
            if (playerActive)
            {
                playerActive = false;
                playerCam.enabled = false;
                freeCam.transform.position = playerCam.transform.position;
                freeCam.transform.rotation = playerCam.transform.rotation;
                freeCam.enabled = true;
                freeCam.GetComponent<Freecame>().activate = true;
            }
            else
            {
                playerActive = true;
                freeCam.enabled = false;
                freeCam.GetComponent<Freecame>(). activate = false;
                playerCam.enabled = true;
            }
        }

    }
}
