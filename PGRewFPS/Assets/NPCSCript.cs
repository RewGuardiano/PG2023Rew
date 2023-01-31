using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSCript : MonoBehaviour,Ihealth
{
    public float health = 100f;
    public void TakeDamage(float amountDamage)
    {
        health -= amountDamage;
        if(health <= 0f)
        {
            ObjDestroyed();
        }
    }

    

    void ObjDestroyed()
    {
        Destroy(gameObject);
    }
}
