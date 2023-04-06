using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyControl : MonoBehaviour, Ihealth
{
    enum AIStates { Patrol, GunshotHeard, Dummyhit }

    public float Health { get; private set; } = 100f;
    Transform[] patrolPoints;
    public float waitTime = 1f;
    private int currentPointIndex = 0;
    private Rigidbody rb;
    int number_of_patrol_points;

    AIStates dummy_states = AIStates.Patrol;
 
    Animator dummy_animator;
    private float thresholdDistance = 0.05f;

   

    void Start()
    {
        dummy_animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;

        patrolPointScript[] allPoints = FindObjectsOfType<patrolPointScript>();

        number_of_patrol_points = Random.Range(2, allPoints.Length-1);

        patrolPoints = new Transform[number_of_patrol_points];

        for (int i =0; i<number_of_patrol_points; i++)
        {
            patrolPoints[i] = allPoints[Random.Range(0, allPoints.Length - 1)].transform;
        }

        
        
    }


    void Update()
    {
    

        switch (dummy_states)
        {

            case AIStates.Patrol:

                dummy_animator.SetBool("isWalking", true);
                transform.LookAt(patrolPoints[currentPointIndex]);
             
                if (haveReachedWayPoint(transform.position, patrolPoints[currentPointIndex].position))
                {
                    currentPointIndex = (currentPointIndex + 1) % patrolPoints.Length;
                    StartCoroutine(WaitAtPoint());
                }

                break;

            case AIStates.GunshotHeard:

                if (Input.GetButtonDown("Fire1"))
                {

                    dummy_animator.SetBool("isWalking", false);
                    dummy_animator.SetBool("isRunning", true);

                }
                break;
            
            case AIStates.Dummyhit:
 
                    dummy_animator.SetBool("Jumping", true);

                break;






        }


































    }


    private bool haveReachedWayPoint(Vector3 npc_pos, Vector3 way_point_pos)
    {
        Vector3 ignore_y_waypoint_position = new Vector3(way_point_pos.x, npc_pos.y, way_point_pos.z);
        return Vector3.Distance(npc_pos, ignore_y_waypoint_position) < thresholdDistance;
    }

    IEnumerator WaitAtPoint()
    {
        yield return new WaitForSeconds(waitTime);
    }
    void MoveToNextPoint()
    {
        Vector3 direction = (patrolPoints[currentPointIndex].position - transform.position).normalized;
        rb.MovePosition(transform.position + direction * Time.deltaTime);


    }
    public void TakeDamage(float amountDamage)
    {
        Health -= amountDamage;
        if (Health <= 50)
        {

            dummy_states = AIStates.Dummyhit;
        }
    }

}
