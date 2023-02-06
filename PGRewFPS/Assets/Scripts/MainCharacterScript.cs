using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacterScript : MonoBehaviour
{
    FPSCameraScript Camera;
    float speed;
    const float Walking_speed = 3, Running_speed = 8, Crouch_speed = 3;
    public Rigidbody rb;
    public float horizontalSpeed = 1f;
    float v;
    

    // Start is called before the first frame update
    void Start()
    {
        speed = Walking_speed;
        Camera = FindObjectOfType<FPSCameraScript>();
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

        Camera.UpdatePosition(this, Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        float h = horizontalSpeed * Input.GetAxis("Mouse X");
        transform.Rotate(v, h, 0);
    }

  
}
