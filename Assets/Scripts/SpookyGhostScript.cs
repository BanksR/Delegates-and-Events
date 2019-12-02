using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpookyGhostScript : MonoBehaviour
{

    private SpriteRenderer _spr;
    public float fadeInTime = 5f;
    
    void Awake()
    {
        _spr = GetComponentInChildren<SpriteRenderer>();
        _spr.color = Color.clear;

        // Here is where the magic happens...
        // We subscribe our BeSpooky() function to the delegate.
        // When the delegate sends its message out, BeSpooky()
        // will be listening for it and trigger accordingly.
        
        DelegateScript.TestDelegate += BeSpooky;
        
        // Take note of the syntax - We are referencing our static
        // delegate variable we created on our DelegateScript.cs Class. Then we use the += to indicate
        // we wish to subscribe to the delegate messaging service.
    
    }

    // Note - our function must have the same return type and number of parameters
    // as our delegate or it won't be able to subscribe
    // Our TestDelegate returns void, and takes no paramters.
    
    public void BeSpooky()
    {
        // Start our being spooky process...
        StartCoroutine(FadeIn());
    }
    
    
    IEnumerator FadeIn()
    {
        float t = 0;

        while (t < fadeInTime)
        {
            _spr.color = Color.Lerp(Color.clear, Color.white, t / fadeInTime);
            t += Time.fixedDeltaTime;
            yield return null;
        }

        Debug.Log("WoooooOOOOOooooOOOOooooOOOOO");
        // Once we have been spooky 1 time, we can unsubscribe from the messaging service
        DelegateScript.TestDelegate -= BeSpooky;
        yield return null;
    }

    private void OnDisable()
    {
        // To avoid our delivery going to an empty address, it is required we unsubscribe
        // from the delegate once you know you don't need it anymore. Just like Amazon Prime.
        
        DelegateScript.TestDelegate -= BeSpooky;
    }
}
