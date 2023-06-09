using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIFade : Singleton<UIFade>
{
    [SerializeField] private Image fadeSceneImage;
    [SerializeField] private float fadeSpeed = 1f;

    /// <summary>
    /// FadeRountine Method
    /// Object Will Disappear/Appear if targetAlpha(0f -> 1f) is Changed
    /// </summary>
    /// <param name="targetAlpha">Transparent Value</param>
    /// <returns>IEnumerator</returns>
    public IEnumerator FadeRoutine(float targetAlpha)
    {
        while (!Mathf.Approximately(fadeSceneImage.color.a, targetAlpha))
        {
            float alpha = Mathf.MoveTowards(fadeSceneImage.color.a, targetAlpha, fadeSpeed * Time.deltaTime);
            fadeSceneImage.color = new Color(fadeSceneImage.color.r, fadeSceneImage.color.g, fadeSceneImage.color.b, alpha);
            yield return null;
        }
    }
}
