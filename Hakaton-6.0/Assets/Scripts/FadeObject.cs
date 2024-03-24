using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeObject : MonoBehaviour
{
    public float fadeSpeed, fadeAmount;
    float originalOpacity;
    Material material;
    public bool doFade;

    void Start()
    {
        material = GetComponent<Renderer>().material;
        originalOpacity = material.color.a;
    }

    void Update()
    {
        if (doFade) FadeNow();
        else ResetFade();
    }

    private void FadeNow()
    {
        Color currentColor = material.color;
        Color smoothColor = new Color(currentColor.r, currentColor.b, currentColor.g,
            Mathf.Lerp(currentColor.a, fadeAmount, fadeSpeed * Time.deltaTime));
        material.color = smoothColor;
    }

    private void ResetFade()
    {
        Color currentColor = material.color;
        Color smoothColor = new Color(currentColor.r, currentColor.b, currentColor.g,
            Mathf.Lerp(currentColor.a, originalOpacity, fadeSpeed * Time.deltaTime));
        material.color = smoothColor;
    }
}
