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
    private float loadtime = 1f;

    /// <summary>
    /// private Method
    /// </summary>
    private void SetMaxLoaderBar(float value)
    {
        sliderLoader.maxValue = value;
        fillColorLoader.color = gradientLoaderColor.Evaluate(1f);
    }
    private void SetCurrentLoaderBar(float value)
    {
        sliderLoader.value = value;
        fillColorLoader.color = gradientLoaderColor.Evaluate(sliderLoader.normalizedValue);
    }

    /// <summary>
    /// Pulbic Method
    /// </summary>
    private void SetSliderValue()
    {
        SetMaxLoaderBar(1f);
        SetCurrentLoaderBar(0f);
    }

    private void ChangeSliderValue(float value)
    {
        SetCurrentLoaderBar(value);
    }

    /// create LoadScene Routine Method
    private IEnumerator LoadSceneRoutine(string sceneToLoad)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneToLoad);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            ChangeSliderValue(progress);
            yield return null;
        }
    }

    ///
    /// create DelayForAnimRoutine Method
    /// StartCoroutine(DelayForAnimRoutine(loadTime));
    ///
    private IEnumerator FadedAnimRoutine(string sceneToLoad)
    {
        SetSliderValue();
        // Before Load Time Code
        FadeToBlack();

        while (loadtime >= 0)
        {
            loadtime -= Time.deltaTime;
            // while load time code
            yield return null;
        }
        // After Load Time Code
        sliderLoader.gameObject.SetActive(true);
        LoadSceneBar(sceneToLoad);
    }
    private IEnumerator ClearAnimRoutine()
    {
        yield return new WaitForSeconds(2f);
        sliderLoader.gameObject.SetActive(false);
        FadeToClear();
    }

    // stard load scene
    private void LoadSceneBar(string sceneToLoad)
    {
        if (loadSceneRoutine != null)
        {
            StopCoroutine(loadSceneRoutine);
        }

        loadSceneRoutine = LoadSceneRoutine(sceneToLoad);
        StartCoroutine(loadSceneRoutine);
    }

    // start fade scene
    private void FadeToBlack()
    {
        if (loadSceneRoutine != null)
        {
            StopCoroutine(loadSceneRoutine);
        }

        loadSceneRoutine = UIFade.Instance.FadeRoutine(1);
        StartCoroutine(loadSceneRoutine);
    }

    // stop fade scene
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
    /// Public Method
    /// </summary>
    //// LoadScene Method Using FadeToLoad/FadeToClear/LoadCene Method
    public void LoadSceneAnim(string sceneToLoad)
    {
        StartCoroutine(FadedAnimRoutine(sceneToLoad));
        StartCoroutine(ClearAnimRoutine());
    }
}
