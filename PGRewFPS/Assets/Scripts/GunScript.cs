using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;

    public Camera fpsCamera2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            ShootGun();
        }
    }
    void ShootGun()
    {
        RaycastHit hit;
        if(Physics.Raycast(fpsCamera2.transform.position , fpsCamera2.transform.forward,out hit, range)){

            Debug.Log(hit.transform.name);
        }

    }
}
