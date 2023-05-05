using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ReTryGame : MonoBehaviour
{
    
    public void LoadGame()
    {

        SceneManager.LoadScene("GameFinished"); 
    }
    public void ReturnMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    
}

