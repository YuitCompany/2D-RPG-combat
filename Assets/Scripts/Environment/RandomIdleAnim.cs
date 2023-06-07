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
        FlameRandomAnim();
    }

    /// <summary>
    /// FlameRandomAnim Method
    /// Object Will Not Overlap When Run
    /// </summary>
    private void FlameRandomAnim()
    {
        AnimatorStateInfo stateAnim = flameTorch.GetCurrentAnimatorStateInfo(0);
        flameTorch.Play(stateAnim.fullPathHash, -1, Random.Range(0f, 1f));
    }
}
