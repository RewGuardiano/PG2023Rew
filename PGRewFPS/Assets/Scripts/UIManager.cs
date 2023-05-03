using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; 

public class UIManager : MonoBehaviour
{

    public static UIManager instance;
    [SerializeField]
    TextMeshProUGUI killCounterTMP;
    [HideInInspector]
    public int KillCount;
   
  


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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    

}
