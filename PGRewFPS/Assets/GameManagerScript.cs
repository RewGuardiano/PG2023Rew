using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GameManagerScript : MonoBehaviour
{

    public static event Action KillCountReached;
    public Transform PlayerPos;
    int MaxNumberOfDummys = 10;
    List<NPCSCript> currentDummies;
    public Transform DummyCloneTemplate;
    
 
    
    

    // Start is called before the first frame update
    void Start()
    {
        currentDummies = new List<NPCSCript>();


    }

    // Update is called once per frame
    void Update()
    {




        if (currentDummies.Count < MaxNumberOfDummys && numberOfDummiesKilled < 50)
        {
            spawnDummy();
        }

       
    }
   

    private int numberOfDummiesKilled = 0;

    private void spawnDummy()
    {
        if (numberOfDummiesKilled >= 11)
        {
            
            return;
        }

        Vector3 RandomSpawnPosition = new Vector3(UnityEngine.Random.Range(-20, 18), 0, UnityEngine.Random.Range(2, 18));
        Transform Clone = Instantiate(DummyCloneTemplate, RandomSpawnPosition, Quaternion.identity);
        Clone.transform.LookAt(transform.forward);

        NPCSCript newClone = Clone.GetComponent<NPCSCript>();
        newClone.ImtheDaddy(this);
        currentDummies.Add(newClone);



    }
   

    internal void ImShooting(MainCharacterScript personShooting)
    {
        foreach (NPCSCript npc in currentDummies)
        {
            npc.gunshotHeard(personShooting);
        }
        
    }

    internal void ImDead(NPCSCript nPCSCript)
    {
        currentDummies.Remove(nPCSCript);
        numberOfDummiesKilled++;

        if (numberOfDummiesKilled  >= 20)
        {
            // Stop spawning dummies
            KillCountReached?.Invoke();
            return;
        }
      

        
    }

  
}