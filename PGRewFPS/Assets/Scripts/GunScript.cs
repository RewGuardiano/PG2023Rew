using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    public int damage = 10;
    public float range = 50f;
    GameManagerScript theManager;
    MainCharacterScript theMan;
  

    public ParticleSystem MuzzleFlash;
    public Camera fpsCamera2;

    // Start is called before the first frame update

    void Start()
    {
        theManager = FindObjectOfType<GameManagerScript>();
        theMan = FindObjectOfType<MainCharacterScript>();
       
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

            theManager.ImShooting(theMan);
            MuzzleFlash.Play();
            RaycastHit hit;
            if (Physics.Raycast(fpsCamera2.transform.position, fpsCamera2.transform.forward, out hit, range))
            {

                Debug.Log(hit.transform.name);
                Ihealth ObjHit = hit.transform.GetComponent<Ihealth>();
                if (ObjHit != null)
                {
                    ObjHit.TakeDamage(50);
                    
                }
             



            }


        }
        
    }
  
}
  

