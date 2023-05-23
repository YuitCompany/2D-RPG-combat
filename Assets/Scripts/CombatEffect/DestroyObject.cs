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
            DestroySelfAnimEvent();
        }
    }

    // destroy object after call method
    public void DestroySelfAnimEvent()
    {
        Destroy(this.gameObject);
    }
}
