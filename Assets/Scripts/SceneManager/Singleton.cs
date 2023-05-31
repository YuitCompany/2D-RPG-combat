using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
    public static T Instance { get { return instance; } }

    private static T instance;

    /// <summary>
    /// Create Custom virtual Awake
    /// Object Will Not Be Destroyed When Load New Scene
    /// </summary>
    protected virtual void Awake()
    {
        if(instance != null && this.gameObject != null)
        {
            Destroy(this.gameObject);
        } else
        {
            instance = (T)this;
        }

        if(!this.gameObject.transform.parent)
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }
}
