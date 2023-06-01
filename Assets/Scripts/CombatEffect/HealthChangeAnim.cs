using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthChangeAnim : MonoBehaviour
{
    private float loadTime = 1f;
    private float textSpeed = 1f;

    private void Awake()
    {
        StartCoroutine(MovingTextAnim());
    }

    /// <summary>
    /// MovingTextAnim Method
    /// Text Object Will Be Move Up
    /// Until It Disappears
    /// </summary>
    /// <returns>IEnumerator</returns>
    private IEnumerator MovingTextAnim()
    {
        // Before Load Time Code
        while (loadTime >= 0)
        {
            loadTime -= Time.deltaTime;
            // While Load Time Code
            transform.position = new
                Vector2(transform.position.x, transform.position.y + textSpeed * Time.deltaTime);
            yield return null;
        }
        // After Load Time Code
        Destroy(gameObject);
    }
}
