using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AreaExit : MonoBehaviour
{
    [SerializeField] private string sceneToLoad;
    [SerializeField] private string sceneTransitionName;

    private float waitToLoadTime = 1f;

    // checker Player move to ExitScene Collision
    // and change present Scene (SceneTransitionName)
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerController>())
        {
            SceneManagement.Instance.SetTransitionName(this.sceneTransitionName);

            UIFade.Instance.FadeToBlack();
            StartCoroutine(LoadSceneRoutine());
        }
    }

    ///
    /// create LoadSceneRoutine Method
    /// StartCoroutine(LoadSceneRoutine());
    ///
    private IEnumerator LoadSceneRoutine()
    {
        while (waitToLoadTime >= 0)
        {
            waitToLoadTime -= Time.deltaTime;
            yield return null;
        }
        // feature code
        SceneManager.LoadScene(sceneToLoad);
        UIFade.Instance.FadeToClear();
    }
}
