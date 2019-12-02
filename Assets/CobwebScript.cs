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

        DelegateScript.TestDelegate += TriggerFadeIn;

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

        DelegateScript.TestDelegate -= TriggerFadeIn;
        yield return null;
    }
}
