using System.Collections;
using UnityEngine;

public class KnockBack : MonoBehaviour
{
    public bool IsKnockedBack {  get; private set; }

    [SerializeField] private float knockBackTime = .2f;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    /// <summary>
    /// KockBackRoutine Method
    /// After KnockBackTime(S) Will Be:
    /// Reset IsKnoedBack: false
    /// Reset rb.Velocity: Vector2.rezo
    /// </summary>
    /// <param name="knockBackTime"></param>
    /// <returns>IEnumerator</returns>
    private IEnumerator KockBackRoutine(float knockBackTime)
    {
        yield return new WaitForSeconds(knockBackTime);
        IsKnockedBack = false;
        rb.velocity = Vector2.zero;
    }

    /// <summary>
    /// GetKnockedBack Method
    /// Set IsKnockedBack: true
    /// Set rb.AddFore With this.Position, Attacker.Position and Thrust Power
    /// </summary>
    /// <param name="damageSource">Transform Attacker</param>
    /// <param name="knockBackThrust">Thrust Power</param>
    public void GetKnockedBack(Transform damageSource, float knockBackThrust)
    {
        IsKnockedBack = true;
        Vector2 difference = (transform.position - damageSource.position).normalized * knockBackThrust * rb.mass;
        rb.AddForce(difference, ForceMode2D.Impulse);
        StartCoroutine(KockBackRoutine(knockBackTime));
    }
}
