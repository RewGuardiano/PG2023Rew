using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSCameraScript : MonoBehaviour
{
    // Start is called before the first frame update

    float xyAngle, zAngle; 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    internal void UpdatePosition(MainCharacterScript myMan, float horizontal, float vertical)
    {
        transform.position = myMan.transform.position;
        //transform.rotation = myMan.transform.rotation;
        xyAngle += horizontal;
        zAngle += vertical;

        zAngle = Mathf.Clamp(zAngle, -89f, 89);

        transform.localRotation = Quaternion.Euler(zAngle, 0, 0);
        transform.localRotation = Quaternion.Euler(0, xyAngle, 0);
    }
}
