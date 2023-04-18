using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    GameManagerScript theManager;

    public ParticleSystem MuzzleFlash;
    public Camera fpsCamera2;
    // Start is called before the first frame update

    void Start()
    {
        theManager = FindObjectOfType<GameManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            ShootGun();
          
        }
        void ShootGun()
        {

            theManager.ImShooting(transform.parent);
            MuzzleFlash.Play();
            RaycastHit hit;
            if (Physics.Raycast(fpsCamera2.transform.position, fpsCamera2.transform.forward, out hit, range))
            {

                Debug.Log(hit.transform.name);
                Ihealth ObjHit = hit.transform.GetComponent<Ihealth>();
                if (ObjHit != null)
                {
                    ObjHit.TakeDamage(50f);
                }

            }

        }
    }
}
