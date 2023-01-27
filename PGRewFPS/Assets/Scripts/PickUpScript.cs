using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpScript : MonoBehaviour
{


    internal enum PickUpItemStates { Waiting, Held,DoYourThing }
    internal PickUpItemStates currentState = PickUpItemStates.Waiting;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   
}
