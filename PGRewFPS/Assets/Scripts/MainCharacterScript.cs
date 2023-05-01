using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class MainCharacterScript : MonoBehaviour
{
    public TextMeshProUGUI playerHpText;
    FPSCameraScript Camera;
    float speed;
    const float Walking_speed =2f;
    public Rigidbody rb;
    public float horizontalSpeed = 1.5f;
    float v;
    public static int CharacterHealth = 1000;
    public static bool isGameOver;
    public GameObject BloodOverlay;

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

        playerHpText.text = "+" + CharacterHealth;
        if (isGameOver)
        {
            SceneManager.LoadScene(2);
        }
    }
    public IEnumerator TookDamage(int amountdamage)
    {
        print("OUCH" + amountdamage.ToString());
        BloodOverlay.SetActive(true);
        CharacterHealth -= amountdamage;

        if(CharacterHealth  <= 0)
        
            //Show GameOver Screen
            isGameOver = true;
     



        yield return new WaitForSeconds(5.5f);
        BloodOverlay.SetActive(false);
    }

}
