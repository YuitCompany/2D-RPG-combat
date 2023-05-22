using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBack : MonoBehaviour
{
    public bool IsKnockedBack {  get; private set; }

    [SerializeField] private float knockBackTime = .2f;


    private Rigidbody2D rb;

    /// <summary>
    /// Unity Sytem Method
    /// </summary>
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    ///
    /// create KockBack Routine Method
    ///
    private IEnumerator KockBackRoutine(float knockBackTime)
    {
        yield return new WaitForSeconds(knockBackTime);
        rb.velocity = Vector2.zero;
        IsKnockedBack = false;
    }

    /// <summary>
    /// KnockBack Public Method
    /// </summary>
    public void GetKnockedBack(Transform damageSource, float knockBackThrust)
    {
        IsKnockedBack = true;
        Vector2 difference = (transform.position - damageSource.position).normalized * knockBackThrust * rb.mass;
        rb.AddForce(difference, ForceMode2D.Impulse);
        StartCoroutine(KockBackRoutine(knockBackTime));
    }
}
