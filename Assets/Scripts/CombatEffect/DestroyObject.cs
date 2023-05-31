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
        // destroy Particle After Complete
        DestroyParticleAnimEvent();
    }

    // destroy object after call method
    /// <summary>
    /// DestroySelfAnimEvent Method
    /// Destroy Object If Added And Called
    /// </summary>
    public void DestroySelfAnimEvent()
    {
        Destroy(this.gameObject);
    }

    /// <summary>
    /// DestroyParticleAnimEvent Method
    /// Destroy Particle After Completing The Activity
    /// </summary>
    public void DestroyParticleAnimEvent()
    {
        if (_particleDestroy && !_particleDestroy.IsAlive())
        {
            DestroySelfAnimEvent();
        }
    }
}
