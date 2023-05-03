using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ReTryGame : MonoBehaviour
{
    
    public void LoadGame()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1); 
    }

    
}

