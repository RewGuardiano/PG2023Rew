using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCSCript : MonoBehaviour,Ihealth
{

    Animator NPCAnimator;
    public Transform centrepoint;
    public NavMeshAgent agent;
    public float health = 100f;
    public float range = 10f;
    public void TakeDamage(float amountDamage)
    {
        health -= amountDamage;
        if(health <= 0f)
        {
            ObjDestroyed();
          //  Vector3 RandomSpawnPosition = new Vector3(Random.Range(-20, 18), 0, Random.Range(2, 18));
           // Dummy = (GameObject)Instantiate(Dummy, RandomSpawnPosition, Quaternion.identity);

        }
    }

    

    void ObjDestroyed()
    {
        Destroy(gameObject);
    }

    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        NPCAnimator = GetComponent<Animator>();
    }
    bool RandomPoint(Vector3 center, float range , out Vector3 result)
    {
        for (int i = 0; i < 30; i++)
        {
            Vector3 randomPoint = center + Random.insideUnitSphere * range;
            NavMeshHit hit;

            if(NavMesh.SamplePosition(randomPoint,out hit, 1.0f, NavMesh.AllAreas))
            {
                result = hit.position;
                return true;
            }
        }
        result = Vector3.zero;
        return false;
    }

    void Update()
    {
        Vector3 point;
        if (agent.remainingDistance <= agent.stoppingDistance)
        {


            if(RandomPoint(centrepoint.position,range,out point))
            {
                Debug.DrawRay(point, Vector3.up, Color.blue, 1.0f);
                agent.SetDestination(point);
            }

        }
    }


}



