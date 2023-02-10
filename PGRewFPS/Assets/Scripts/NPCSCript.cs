using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSCript : MonoBehaviour,Ihealth
{
    Animator NPCAnimator;
    public float currentspeed;
    
    public float health = 100f;
    public GameObject Dummy;
    public void TakeDamage(float amountDamage)
    {
        health -= amountDamage;
        if(health <= 0f)
        {
            ObjDestroyed();
            Vector3 RandomSpawnPosition = new Vector3(Random.Range(-20, 18), 0, Random.Range(2, 18));
            Dummy = (GameObject)Instantiate(Dummy, RandomSpawnPosition, Quaternion.identity);

        }
    }

    

    void ObjDestroyed()
    {
        Destroy(gameObject);
    }


    



}
