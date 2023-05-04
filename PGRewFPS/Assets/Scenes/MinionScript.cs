using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionScript : MonoBehaviour,Ihealth
{
    public int health = 150;
    private Rigidbody rb;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
    }
    public void TakeDamage(int amountDamage)
    {
        health -= amountDamage;
        if (health <= 0)
        {
            ObjDestroyed();
        }




        void ObjDestroyed()
        {
            Destroy(gameObject);


        }
        
   
    }
}
