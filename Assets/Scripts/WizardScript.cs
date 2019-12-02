using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardScript : MonoBehaviour
{

    public float Area = 2f;
    
    // Start is called before the first frame update
    void Awake()
    {
        
        // Here is where the magic happens...
        // We subscribe our Teleport() function to the delegate.
        // When the delegate sends its message out, Teleport()
        // will be listening for it and trigger accordingly.
        
        DelegateScript.TestDelegate += Teleport;
        
        // Take note of the syntax - We are referencing our static
        // delegate we created on our DelegateScript.cs Class. Then we use the += to indicate
        // we wish to subscribe to the delegate messaging service.
    }


    
    // Note - our function must have the same return type and number of parameters
    // as our delegate or it won't be able to subscribe
    // Our TestDelegate returns void, and takes no paramters.
    
    void Teleport()
    {
        Vector2 randPos = Random.insideUnitCircle * Area;
        transform.position = randPos;
    }

    private void OnDisable()
    {
        // To avoid our delivery going to an empty address, it is required we unsubscribe
        // from the delegate once you know you don't need it anymore. Just like Amazon Prime.
        
        DelegateScript.TestDelegate -= Teleport;
    }
}
