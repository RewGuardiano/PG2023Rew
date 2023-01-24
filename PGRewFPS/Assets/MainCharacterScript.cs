using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacterScript : MonoBehaviour
{
    FPSCameraScript camera;
    float speed;
    const float Walking_speed = 3, Running_speed = 8, Crouch_speed = 3;

    // Start is called before the first frame update
    void Start()
    {
        speed = Walking_speed;
        camera = FindObjectOfType<FPSCameraScript>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += speed * transform.forward * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= speed * transform.right * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += speed * transform.right * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= speed * transform.forward * Time.deltaTime;
        }

        camera.UpdatePosition(this, Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

    }

  
}
