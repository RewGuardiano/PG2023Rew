using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCSCript : MonoBehaviour,Ihealth
{

    Animator NPCAnimator;
    public GameObject Dummy;
    public float health = 100f;
    public float range = 10f;


    public void TakeDamage(float amountDamage)
    {
        health -= amountDamage;
        if (health <= 0f)
        {
            ObjDestroyed();
            Vector3 RandomSpawnPosition = new Vector3(Random.Range(-20, 18), 0, Random.Range(2, 18));
            Dummy = Instantiate(Dummy, RandomSpawnPosition, Quaternion.identity);

        }
    }
    void Start()
    {
        NPCAnimator = GetComponent<Animator>();
     
    }
    void Update()

    {
       


        if (Input.GetKeyDown(KeyCode.Space))
        {


            NPCAnimator.SetBool("isWalking", true);
        }
        //else if(Input.GetKeyDown)
        {

        }

        if (Input.GetKeyDown(KeyCode.Return))
            NPCAnimator.SetBool("StartStrafe", true);


      
    }

    void ObjDestroyed()
    {
        Destroy(gameObject);
    }


}



