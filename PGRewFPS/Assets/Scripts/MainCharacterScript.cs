using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System;


public class MainCharacterScript : MonoBehaviour,Ihealth
{
    public TextMeshProUGUI playerHpText;
    FPSCameraScript Camera;
    float speed;
    const float Walking_speed =2f;
    public float horizontalSpeed = 1.5f;
    float v;
    public int CharacterHealth = 10000;
    public static bool isGameOver;
    



    // Start is called before the first frame update
    void Start()
    {
        isGameOver = false;

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
    public void TakeDamage(int amountdamage)
    {
        print("OUCH" + amountdamage.ToString());
       
        CharacterHealth -= amountdamage;
        playerHpText.text = "+" + CharacterHealth;
       

        if (CharacterHealth <= 0)
        {

            //Show GameOver Screen
            isGameOver = true;
            if (isGameOver)
            {
                SceneManager.LoadScene(2);
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None ;

            }
            

        }




    }
    

}
