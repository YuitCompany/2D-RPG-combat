using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIFade : Singleton<UIFade>
{
    [SerializeField] private Image fadeSceneImage;
    [SerializeField] private float fadeSpeed = 1f;

    private IEnumerator fadeRoutine;

    // start fade scene
    public void FadeToBlack()
    {
        if (fadeRoutine != null)
        {
            StopCoroutine(fadeRoutine);
        }

        fadeRoutine = FadeRoutine(1);
        StartCoroutine(fadeRoutine);
    }

    // stop fade scene
    public void FadeToClear()
    {
        if(fadeRoutine != null)
        {
            StopCoroutine(fadeRoutine);
        }

        fadeRoutine = FadeRoutine(0);
        StartCoroutine(fadeRoutine);
    }

    ///
    /// create Fade Routine Method
    /// StartCoroutine(FadeRoutine());
    ///
    private IEnumerator FadeRoutine(float targetAlpha)
    {
        while (!Mathf.Approximately(fadeSceneImage.color.a, targetAlpha))
        {
            float alpha = Mathf.MoveTowards(fadeSceneImage.color.a, targetAlpha, fadeSpeed * Time.deltaTime);
            fadeSceneImage.color = new Color(fadeSceneImage.color.r, fadeSceneImage.color.g, fadeSceneImage.color.b, alpha);
            yield return null;
        }
        // feature code

    }
}
