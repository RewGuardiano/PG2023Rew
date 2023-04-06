using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCSCript : MonoBehaviour,Ihealth
{
    
    Animator NPCAnimator;
    public GameObject Dummy;
    public float health = 150f;
    public float range = 10f;
    GameManagerScript theManager;


    public void TakeDamage(float amountDamage)
    {
        health -= amountDamage;
        if (health <= 0f)
        {
            theManager.ImDead(this);
            ObjDestroyed();
        
            

        }
    }
    void ObjDestroyed()
    {
        Destroy(gameObject);
    }

    void Start()
    {
        NPCAnimator = GetComponent<Animator>();
       


     
    }
    void Update()

    {
 


      
    }

    internal void ImtheDaddy(GameManagerScript gameManagerScript)
    {
        theManager = gameManagerScript;
    }
}



