using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSCameraScript : MonoBehaviour
{
    // Start is called before the first frame update
    float sensXY, sensZ;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    internal void UpdatePosition(MainCharacterScript myCharacter, float horizontal, float vertical)
    {
        transform.position = myCharacter.transform.position;
       

            sensXY += horizontal;
            sensZ -= vertical;
            sensZ = Mathf.Clamp(sensZ, -45, 45);

          
        

        transform.rotation = Quaternion.AngleAxis(sensXY, Vector3.up) * Quaternion.AngleAxis(sensZ, Vector3.right);
        // transform.LookAt(transform.position + transform.forward, Vector3.up);
    }

 
}
