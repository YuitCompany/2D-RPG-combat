using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    private ParticleSystem _particleDestroy;

    private void Awake()
    {
        _particleDestroy = GetComponent<ParticleSystem>();
    }

    private void Update()
    {
        if (_particleDestroy && !_particleDestroy.IsAlive())
        {
            DestroySelf();
        }
    }

    public void DestroySelf()
    {
        Destroy(this.gameObject);
    }
}
