using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AreaExit : MonoBehaviour
{
    [SerializeField] private string sceneToLoad;
    [SerializeField] private string sceneTransitionName;

    // checker Player move to ExitScene Collision
    // and change present Scene (SceneTransitionName)
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerController>())
        {
            SceneManager.LoadScene(sceneToLoad);
            SceneManagement.Instance.SetTransitionName(this.sceneTransitionName);
        }
    }
}
