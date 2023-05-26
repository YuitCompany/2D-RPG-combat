using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomIdleAnim : MonoBehaviour
{
    private Animator flameTorch;

    private void Awake()
    {
        flameTorch = GetComponent<Animator>();
    }

    private void Start()
    {
        AnimatorStateInfo stateAnim = flameTorch.GetCurrentAnimatorStateInfo(0);
        flameTorch.Play(stateAnim.fullPathHash, -1, Random.Range(0f, 1f));
    }
}
