using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CobwebScript : MonoBehaviour

{

    private Image[] _imgs;
    public float fadeTime = 3f;
    
    // Start is called before the first frame update
    void Awake()
    {
        _imgs = GetComponentsInChildren<Image>();
        foreach (var img in _imgs)
        {
            img.color = Color.clear;
            
        }
        
        // Here is where the magic happens...
        // We subscribe our TriggerFadeIn() function to the delegate.
        // When the delegate sends its message out, TriggerFadeIn()
        // will be listening for it and trigger accordingly.

        DelegateScript.TestDelegate += TriggerFadeIn;
        
        // Take note of the syntax - We are referencing our static
        // delegate variable we created on our DelegateScript.cs Class. Then we use the += to indicate
        // we wish to subscribe to the delegate messaging service.

    }

    void TriggerFadeIn()
    {
        StartCoroutine(FadeIn());
    }

    IEnumerator FadeIn()
    {
        float t = 0f;

        while (t < fadeTime)
        {
            foreach (var img in _imgs)
            {
                img.color = Color.Lerp(Color.clear, Color.black, t / fadeTime);
            }

            t += Time.fixedDeltaTime;
            yield return null;
        }

        // To avoid our delivery repeatedly going to the same address, it is required we unsubscribe
        // from the delegate once you know you don't need it anymore. Just like Amazon Prime.
        
        DelegateScript.TestDelegate -= TriggerFadeIn;
        yield return null;
    }
}
