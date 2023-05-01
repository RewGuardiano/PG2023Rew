using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCSCript : MonoBehaviour,Ihealth
{
    
    Animator NPCAnimator;
    public GameObject Dummy;
    public int health = 150;
    public float range = 1f;
    GameManagerScript theManager;

    enum AIStates
    {
        Patrol, GunshotHeard,Attack
    }

    public int Health { get; private set; } = 100;
    public float ATTACK_TIME = 0.833F;


    Transform[] patrolPoints;
    public float waitTime = 1f;
    private int currentPointIndex=1;
    private Rigidbody rb;
    int number_of_patrol_points;
   

    AIStates dummy_current_state = AIStates.Patrol;

    Animator dummy_animator;
    private float thresholdDistance = 0.05f;
    private MainCharacterScript lockedOnTarget;
    private float meleeDistance = 2f;
    private float attackTimer;

    public void TakeDamage(int amountDamage)
    {
        health -= amountDamage;
        if (health <= 0)
        {
            theManager.ImDead(this);
            ObjDestroyed();

           

        }
    }
    void ObjDestroyed()
    {
        Destroy(gameObject);
        UIManager.instance.KillCount++;
        UIManager.instance.UpdateKillCounterUI();
    }

    void Start()
    {
        
        NPCAnimator = GetComponent<Animator>();

        dummy_animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;

        patrolPointScript[] allPoints = FindObjectsOfType<patrolPointScript>();

        number_of_patrol_points = UnityEngine.Random.Range(2, allPoints.Length - 1);

        patrolPoints = new Transform[number_of_patrol_points];

        for (int i = 0; i < number_of_patrol_points; i++)
        {
            patrolPoints[i] = allPoints[UnityEngine.Random.Range(0, allPoints.Length - 1)].transform;
        }





    }

    void Update()
    {


        switch (dummy_current_state)
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

                transform.LookAt(new Vector3(lockedOnTarget.transform.position.x, transform.position.y, lockedOnTarget.transform.position.z));

                if (distanceForChars(lockedOnTarget.transform.position, transform.position) < meleeDistance)
                {
                    print("Hit");
                    dummy_current_state = AIStates.Attack;

                    
                    dummy_animator.SetBool("Attacking", true);
                    attackTimer = ATTACK_TIME;
                }

                break;


            case AIStates.Attack:
               
                attackTimer -= Time.deltaTime;
                if (attackTimer <0)
                {
                    StartCoroutine(FindObjectOfType<MainCharacterScript>().TookDamage(10));
                   
                   
                }


                if (distanceForChars(lockedOnTarget.transform.position, transform.position) > meleeDistance)
                {
                    dummy_current_state = AIStates.GunshotHeard;
                    dummy_animator.SetBool("Attacking", false);

                    dummy_animator.SetBool("isRunning", true);

                }


                    break;
            
        }
    }

    private float distanceForChars(Vector3 position1, Vector3 position2)
    {
        // ignores the y for distance

        return Vector2.Distance(new Vector2(position1.x, position1.z), new Vector2(position2.x, position2.z));

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


        internal void gunshotHeard(MainCharacterScript playerWhoShot)
        {
            dummy_current_state = AIStates.GunshotHeard;
     
            dummy_animator.SetBool("isRunning", true);
 
        lockedOnTarget = playerWhoShot;

        }


   





























    internal void ImtheDaddy(GameManagerScript gameManagerScript)
    {
        theManager = gameManagerScript;
    }
}



