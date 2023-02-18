using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSCript : MonoBehaviour,Ihealth
{

    public float moveSpeed = 3f;
    public float rotSpeed = 10f;

    private bool isWandering = false;
    private bool isRotatingLeft = false;
    private bool isRotatingRight = false;
    private bool isWalking = false;

    Animator NPCAnimator;
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


    
    void Update()
    {
        NPCAnimator = GetComponent<Animator>();
        if(isWandering == false)
        {
            StartCoroutine(Wander());

        }
        if(isRotatingRight == true)
        {
            gameObject.GetComponent<Animator>().Play("breathe");
            transform.Rotate(transform.up * Time.deltaTime * rotSpeed);

        }

        if (isRotatingLeft == true)
        {

            gameObject.GetComponent<Animator>().Play("breathe");
            transform.Rotate(transform.up * Time.deltaTime * -rotSpeed);
        }
        if(isWalking == true)
        {
            gameObject.GetComponent<Animator>().Play("walk");
            transform.position += transform.forward * moveSpeed * Time.deltaTime * -rotSpeed;
        }

    }

    IEnumerator Wander()
    {

        int rotTime = Random.Range(1, 1);
        int rotateWait = Random.Range(1, 1);
        int rotateLorR = Random.Range(1, 2);
        int walkWait = Random.Range(1, 1);
        int walkTime = Random.Range(1, 1);

        isWandering = true;

        yield return new WaitForSeconds(walkWait);
        isWalking = true;
        yield return new WaitForSeconds(walkTime);
        isWalking = false;
        yield return new WaitForSeconds(rotateWait);
        if (rotateLorR == 1)
        {
            isRotatingRight = true;
            yield return new WaitForSeconds(rotTime);
            isRotatingRight = false;
        }
        if (rotateLorR == 2)
        {
            isRotatingLeft = true;
            yield return new WaitForSeconds(rotTime);
            isRotatingLeft = false;
        }
        isWandering = false;
    }
}



