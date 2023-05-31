using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AreaExit : MonoBehaviour
{
    [SerializeField] private string sceneToLoad;
    [SerializeField] private string sceneTransitionName;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // checker Player move to ExitScene Collision
        // and change present Scene (SceneTransitionName)
        if(collision.gameObject.GetComponent<PlayerController>())
        {
            SceneManagement.Instance.SetTransitionName(this.sceneTransitionName);
            UILoadScene.Instance.LoadSceneAnim(this.sceneToLoad);
        }
    }
}
