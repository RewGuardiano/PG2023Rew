using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnClone : MonoBehaviour
{
    private Vector3 originPosition;
    public GameObject Dummy;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
         if(Dummy == null)
        {
            Dummy = (GameObject)Instantiate(Dummy, originPosition, Quaternion.identity);
        }
    }
   


}
