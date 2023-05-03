using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour
{
    
    int MaxNumberOfDummys = 10;
    List<NPCSCript> currentDummies;
    public Transform DummyCloneTemplate;
    public Transform MinionCloneTemplate;
    // Start is called before the first frame update
    void Start()
    {
        currentDummies = new List<NPCSCript>();

        
    }

    // Update is called once per frame
    void Update()
    {
        


            if (currentDummies.Count < MaxNumberOfDummys)
                spawnDummy();


        
    }


    private int numberOfDummiesKilled = 0;

    private void spawnDummy()
    {
        if (numberOfDummiesKilled >=41)
        {
            return;
        }

        Vector3 RandomSpawnPosition = new Vector3(Random.Range(-20, 18), 0, Random.Range(2, 18));
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
        foreach(MinionScript minion in MinionCloneTemplate)
        {
            minion.gunshotHeard(personShooting);
        }
    }

    internal void ImDead(NPCSCript nPCSCript)
    {
        currentDummies.Remove(nPCSCript);
        numberOfDummiesKilled++;

        if (numberOfDummiesKilled >= 41)
        {
            // Stop spawning dummies
            return;
        }
    }
}
