using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyControl : MonoBehaviour, Ihealth
{
    enum AIStates { Patrol, GunshotHeard, Dummyhit }


   // public Transform[] patrolPoints;
    public float waitTime = 1f;
    private int currentPointIndex = 0;
    private Rigidbody rb;
  

    AIStates dummy_states = AIStates.Patrol;
 
    Animator dummy_animator;
    private float rotation_speed = 180;
    void Start()
    {
        dummy_animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
      
        
        
    }


    void Update()
    {
    

        switch (dummy_states)
        {

            case AIStates.Patrol:

                dummy_animator.SetBool("isWalking", true);

                break;

        }

      /*  if (transform.position == patrolPoints[currentPointIndex].position)
        {
            currentPointIndex = (currentPointIndex + 1) % patrolPoints.Length;
            StartCoroutine(WaitAtPoint());
        }

        MoveToNextPoint();

        void MoveToNextPoint()
        {
            Vector3 direction = (patrolPoints[currentPointIndex].position - transform.position).normalized;
            rb.MovePosition(transform.position + direction * Time.deltaTime);


        }

        IEnumerator WaitAtPoint()
        {
            yield return new WaitForSeconds(waitTime);
        }

        */























       
    }
    public void TakeDamage(float amountDamage)
    {
        throw new KeyNotFoundException();
    }
}
