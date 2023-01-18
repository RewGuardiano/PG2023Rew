using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacterScript : MonoBehaviour
{
    [SerializeField] Transform cameraTransform;
    Vector2 look;
    private float speed;
    private float MouseSensitivity = 3f;
    const float Walking_speed = 3, Running_speed = 8, Crouch_speed = 3;
  
    // Start is called before the first frame update
    void Start()
    {
        speed = Walking_speed;
        Cursor.lockState = CursorLockMode.Locked;
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
        var input = new Vector3();

        input = Vector3.ClampMagnitude(input, 1f);//so we won't move digonally faster than moving normally//

        UpdateLook();
       
       
    }
    void UpdateLook()
    {
        look.x += Input.GetAxisRaw("Mouse X") * MouseSensitivity;
        look.y += Input.GetAxisRaw("Mouse Y") * MouseSensitivity;

        look.y = Mathf.Clamp(look.y, -89f, 89);

        cameraTransform.localRotation = Quaternion.Euler(-look.y, 0, 0);
        transform.localRotation = Quaternion.Euler(0, look.x, 0);
       
    }
   
}
