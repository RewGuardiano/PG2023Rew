using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{

    public static UIManager instance;
    [SerializeField]
    TextMeshProUGUI killCounterTMP;
    [HideInInspector]
    public int KillCount;
    public Transform PlayerPos;
    public Transform MinionCloneTemplate;
    public float spawnHeight = 6f;
    public float spawnDistance = 2.0f;
    public GameObject YouWinMenu;
    public GameObject popupObject;
    public float delayTime = 1000f;
    public RawImage Crosshair;
    public Button Suprise;

    public void EnableYouWinMenu()
    {
        YouWinMenu.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

    }

    private void OnEnable()
    {
        GameManagerScript.KillCountReached += EnableYouWinMenu;
       
        
        
    }
    private void OnDisable()
    {
        GameManagerScript.KillCountReached -= EnableYouWinMenu;


    }
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void UpdateKillCounterUI()
    {
        killCounterTMP.text = KillCount.ToString();

       
    }
    void Start()
    {
        DontDestroyOnLoad(YouWinMenu);
    }

    // Update is called once per frame
    void Update()
    {
        if (MinionCloneTemplate == null)
        {
            YouWinMenu.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Crosshair.enabled = false;
            Suprise.enabled = false;
          
        }
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void PlayAgain()
    {
        SceneManager.LoadScene("GameFinished");
    }


    public void SupriseButton()
    {
        Vector3 spawnPosition = PlayerPos.position + PlayerPos.forward * spawnDistance;
        spawnPosition.y = spawnHeight; // Set the spawn height

        // Calculate the rotation to face the player
        Quaternion spawnRotation = Quaternion.LookRotation(PlayerPos.position - spawnPosition);

        
       
          
        MinionCloneTemplate = Instantiate(MinionCloneTemplate, spawnPosition,spawnRotation) ;
        MinionCloneTemplate.transform.LookAt(PlayerPos.transform.position);

        YouWinMenu.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Crosshair.enabled = true;
        

    }

   
    }



