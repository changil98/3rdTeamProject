using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    public Image fadeImage;
    public float fadeSpeed = 1.0f;

    private bool isFadingOut = false;

    public void Start()
    {
        StartCoroutine(FadeIn());
    }

    public void FadeToScene(string sceneName)
    {
        StartCoroutine(FadeOut(sceneName));
    }

    private IEnumerator FadeIn()
    {
        float alpha = 1.0f;
        while(alpha > 0)
        {
            alpha -= Time.deltaTime * fadeSpeed;
            fadeImage.color = new Color(0, 0, 0, alpha);
            yield return null;
        }
    }

    public IEnumerator FadeOut(string sceneName)
    {
        if(isFadingOut)
        {
            yield break;
        }

        isFadingOut = true;

        float alpha = 0.0f;
        while(alpha < 1 )
        {
            alpha += Time.deltaTime * fadeSpeed;
            fadeImage.color = new Color(0,0,0, alpha);
            yield return null;
        }
    }
}
