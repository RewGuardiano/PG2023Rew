using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionScript : MonoBehaviour,Ihealth 
{
    public GameObject Minion;
    public int health = 150;
    Transform[] patrolPoints;
    public float waitTime = 1f;
    private int currentPointIndex = 1;
    int number_of_patrol_points;
    private Rigidbody rb;
    enum AIStates

    {
        GunshotHeard, Attack
    }
    public float ATTACK_TIME = 0.0833f;
    AIStates minion_current_state = AIStates.GunshotHeard;


    Animator MinionAnimator;
    private float thresholdDistance = 0.05f;
    private MainCharacterScript lockedOnTarget;
    private float meleeDistance = 1f;
    private float attackTimer;
    public int attackdamage = 1;

    public void TakeDamage(int amountDamage)
    {
        health -= amountDamage;
        if (health <= 0)
        {
            ObjDestroyed();
        }
    }

    private void ObjDestroyed()
    {
        Destroy(gameObject);
    }

   
    // Start is called before the first frame update
    void Start()
    {
      MinionAnimator = GetComponent<Animator>();

        MinionAnimator = GetComponent<Animator>();
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

    // Update is called once per frame
    void Update()
    {


        switch (minion_current_state)
        {

       
            case AIStates.GunshotHeard:

                transform.LookAt(new Vector3(lockedOnTarget.transform.position.x, transform.position.y, lockedOnTarget.transform.position.z));

                if (distanceForChars(lockedOnTarget.transform.position, transform.position) < meleeDistance)
                {
                    print("Hit");
                    minion_current_state = AIStates.Attack;


                    MinionAnimator.SetBool("Punch", true);
                    attackTimer = ATTACK_TIME;
                }

                break;


            case AIStates.Attack:

                attackTimer -= Time.deltaTime;
                if (attackTimer <= 0)
                {

                    DealDamage(lockedOnTarget);

                }


                if (distanceForChars(lockedOnTarget.transform.position, transform.position) > meleeDistance)
                {
                    minion_current_state = AIStates.GunshotHeard;
                    MinionAnimator.SetBool("Punch", false);

                }


                break;

        }
    }
    public void DealDamage(MainCharacterScript target)
    {
        var atm = target.GetComponent<MainCharacterScript>();
        if (atm != null)
        {
            atm.TakeDamage(attackdamage);
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
        minion_current_state = AIStates.GunshotHeard;

        MinionAnimator.SetBool("Movement", true);

        lockedOnTarget = playerWhoShot;

    }










}
