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
        // destroy Particle After use
        if (_particleDestroy && !_particleDestroy.IsAlive())
        {
            DestroySelf();
        }
    }

    // destroy object after call method
    public void DestroySelf()
    {
        Destroy(this.gameObject);
    }
}
