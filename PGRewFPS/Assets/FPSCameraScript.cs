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
        if (mouseNotActive(horizontal, vertical))
        {
            sensXY = Mathf.Lerp(sensXY, 0, 0.001f);
            sensZ = Mathf.Lerp(sensZ, 0, 0.001f);
        }
        else
        {

            sensXY += horizontal;
            sensZ -= vertical;
            sensZ = Mathf.Clamp(sensZ, -45, 45);

           
        }

        transform.rotation = Quaternion.AngleAxis(sensXY, Vector3.up) * Quaternion.AngleAxis(sensZ, Vector3.right);
        // transform.LookAt(transform.position + transform.forward, Vector3.up);
    }

    private bool mouseNotActive(float horizontal, float vertical)
    {
        return (Mathf.Abs(horizontal) + Mathf.Abs(vertical)) < 0.001f;
    }
  
}
