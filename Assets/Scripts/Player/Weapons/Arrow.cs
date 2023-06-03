using System.Collections;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Animator arrowAnim;
    
    public int arrowDamage = 3;

    private bool arrowHit = false;
    private float deathTime = 5f;
    private float arrowPlyTime = .5f;

    public float angle;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        arrowAnim = GetComponent<Animator>();
    }

    private void Start()
    {
        StartCoroutine(ArrowFlyRoutine(arrowPlyTime));
    }

    /// <summary>
    /// ArrowFlyRoutine Method
    /// The Arrow Will Fly For Some Time
    /// Before The Collision Or Time Up
    /// </summary>
    /// <param name="loadTime">Fly Time</param>
    /// <returns>IEnumerator</returns>
    private IEnumerator ArrowFlyRoutine(float loadTime)
    {
        transform.rotation = Quaternion.Euler(0, 0, angle - 45);
        // Before Load Time Code
        while (loadTime >= 0)
        {
            loadTime -= Time.deltaTime;
            if (arrowHit) { break; }
            // While Load Time Code
            yield return null;
        }
        // After Load TIme Code
        StartCoroutine(ArrowFallenRoutine());
    }

    /// <summary>
    /// ArrowFallenRoutine Method
    /// The Arrow Will Fall And Destroy
    /// After A Period Of Time
    /// </summary>
    /// <returns>IEnumerator</returns>
    private IEnumerator ArrowFallenRoutine()
    {
        // Before Delay Time Code
        ArrowFallen();
        arrowAnim.SetTrigger("Falled");
        yield return new WaitForSeconds(deathTime);
        // After Delay Time Code
        Destroy(gameObject);
    }

    /// <summary>
    /// OnTriggerEnter2D Method
    /// The Arrow Will Will Collide With Monster
    /// And Fall Instantly
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyHealth enemyHealth = collision.GetComponent<EnemyHealth>();

        if(enemyHealth)
        {
            enemyHealth.TakeDamage(arrowDamage);
            StartCoroutine(ArrowFallenRoutine());
        }
    }

    /// <summary>
    /// ArrowFallen Method
    /// Setup Arrow 
    /// Make It Harmless After Falling
    /// </summary>
    private void ArrowFallen()
    {
        arrowHit = true;
        rb.isKinematic = true;
        rb.velocity = Vector2.zero;
        this.gameObject.GetComponent<PolygonCollider2D>().enabled = false;
    }
}
