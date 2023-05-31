using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UILoadScene : Singleton<UILoadScene>
{
    [SerializeField] private Slider sliderLoader;
    [SerializeField] private Gradient gradientLoaderColor;
    [SerializeField] private Image fillColorLoader;

    private IEnumerator loadSceneRoutine;
    private float defaultLoadTime = 1f;

    
    /// <summary>
    /// Set Slider.MaxValue With Value
    /// Set Image.Color With Gradient.Evaluate With 1f value
    /// </summary>
    /// <param name="value">Value Set For Slider.MaxValue</param>
    private void SetMaxLoaderBar(float value)
    {
        sliderLoader.maxValue = value;
        fillColorLoader.color = gradientLoaderColor.Evaluate(1f);
    }

    /// <summary>
    /// Set Slider.Value With Value
    /// Set Image.Color With Gradient.Evaluate using Slider
    /// </summary>
    /// <param name="value">Value Set For Slider.MaxValue</param>
    private void SetCurrentLoaderBar(float value)
    {
        sliderLoader.value = value;
        fillColorLoader.color = gradientLoaderColor.Evaluate(sliderLoader.normalizedValue);
    }

    /// <summary>
    /// LoadSceneRoutine Method
    /// Load New Scene With Name: sceneToLoad
    /// Change Slider.Value
    /// </summary>
    /// <param name="sceneToLoad">Scene Will Be Load</param>
    /// <returns>IEnumerator</returns>
    private IEnumerator LoadSceneRoutine(string sceneToLoad)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneToLoad);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            SetCurrentLoaderBar(progress);
            yield return null;
        }
    }

    /// <summary>
    /// FadedAnimRoutine Method
    /// Set Slider Value And MaxValue
    /// Start Fade Scene: FadeToBlack
    /// DelayRoutine: While
    /// Active Slider And Load New Scene
    /// </summary>
    /// <param name="sceneToLoad">Scene Will Be Load</param>
    /// <returns>IEnumerator</returns>
    private IEnumerator FadedAnimRoutine(float loadTime, string sceneToLoad)
    {
        SetMaxLoaderBar(1f);
        SetCurrentLoaderBar(0f);
        // Before Load Time Code
        FadeToBlack();

        while (loadTime >= 0)
        {
            loadTime -= Time.deltaTime;
            // while load time code
            yield return null;
        }
        // After Load Time Code
        sliderLoader.gameObject.SetActive(true);
        LoadSceneBar(sceneToLoad);
    }
    /// <summary>
    /// ClearAnimRoutine Method
    /// Wait For 2(S) Before 
    /// Inactive Slider And Clear Fade Scene: FadeToClear
    /// </summary>
    /// <returns></returns>
    private IEnumerator ClearAnimRoutine()
    {
        yield return new WaitForSeconds(2f);
        sliderLoader.gameObject.SetActive(false);
        FadeToClear();
    }

    /// <summary>
    /// LoadCreneBar Method
    /// Loading Screne
    /// </summary>
    private void LoadSceneBar(string sceneToLoad)
    {
        if (loadSceneRoutine != null)
        {
            StopCoroutine(loadSceneRoutine);
        }

        loadSceneRoutine = LoadSceneRoutine(sceneToLoad);
        StartCoroutine(loadSceneRoutine);
    }

    /// <summary>
    /// FadeToBlack Method
    /// Start Fade Screne
    /// </summary>
    private void FadeToBlack()
    {
        if (loadSceneRoutine != null)
        {
            StopCoroutine(loadSceneRoutine);
        }

        loadSceneRoutine = UIFade.Instance.FadeRoutine(1);
        StartCoroutine(loadSceneRoutine);
    }

    /// <summary>
    /// FadeToClear Method
    /// Stop Fade Screne
    /// </summary>
    private void FadeToClear()
    {
        if (loadSceneRoutine != null)
        {
            StopCoroutine(loadSceneRoutine);
        }

        loadSceneRoutine = UIFade.Instance.FadeRoutine(0);
        StartCoroutine(loadSceneRoutine);
    }

    /// <summary>
    /// LoadSceneAnim Method
    /// Using FadeToLoad/FadeToClear/LoadCene Method
    /// For Load New Scene
    /// </summary>
    /// <param name="sceneToLoad">Scene Will Be Load</param>
    public void LoadSceneAnim(string sceneToLoad)
    {
        StartCoroutine(FadedAnimRoutine(defaultLoadTime, sceneToLoad));
        StartCoroutine(ClearAnimRoutine());
    }
}
