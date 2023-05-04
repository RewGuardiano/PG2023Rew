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
    public float spawnDistance = 2.0f; // The distance from the player to spawn the object
    public float spawnHeight = 1.5f;
    public Transform MinionCloneTemplate;
    public GameObject YouWinMenu;


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
        
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void PlayAgain()
    {
        SceneManager.LoadScene(1);
    }


    public void SupriseButton()
    {
        Vector3 spawnPosition = PlayerPos.position + PlayerPos.forward * spawnDistance;
        spawnPosition.y = spawnHeight;


        Quaternion spawnRotation = Quaternion.LookRotation(PlayerPos.position - spawnPosition);

        Instantiate(MinionCloneTemplate, spawnPosition, spawnRotation);

        YouWinMenu.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

}
