using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacter : MonoBehaviour
{
    float speed;
    const float Walking_speed =3, Running_speed = 8, Crouch_speed = 3; 
    // Start is called before the first frame update
    void Start()
    {
        speed = Walking_speed;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.W))
        {
            transform.position += speed * transform.forward * Time.deltaTime;
        }
    }
}
