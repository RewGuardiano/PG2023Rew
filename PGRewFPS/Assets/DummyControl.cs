using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyControl : MonoBehaviour,Ihealth
{
    enum AIStates {Patrol,GunshotHeard,Dummyhit}

    AIStates dummy_states = AIStates.Patrol;
    private float walking_speed;
    private float running_speed = 5;
    public Vector3 targetPosition;

    Animator dummy_animator;
    private float rotation_speed = 180;
    void Start()
    {
        dummy_animator = GetComponent<Animator>();
        
    }


    void Update()
    {
        walking_speed = 3f;

        switch (dummy_states)
        {

            case AIStates.Patrol:

                dummy_animator.SetBool("isWalking", true);

                break;

        }

        

    }
 

    























    public void TakeDamage(float amountDamage)
    {
        throw new KeyNotFoundException();
    }
}
