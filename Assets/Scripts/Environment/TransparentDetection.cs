using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TransparentDetection : MonoBehaviour
{
    [Range(0f, 1f)]
    [SerializeField] private float transparencyAmount = .8f;
    [SerializeField] private float fadeTime = .4f;

    private SpriteRenderer spriteRenderer;
    private Tilemap tilemap;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        tilemap = GetComponent<Tilemap>();
    }

    /// <summary>
    /// OnTriggerEnter2D Method
    /// Blur Object When Player Behind
    /// </summary>
    /// <param name="collision">Check For Player Has Moved Behind The Object</param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>())
        {
            if(spriteRenderer)
            {
                StartCoroutine(FadeOnMoveRoutine(spriteRenderer, fadeTime, spriteRenderer.color.a, transparencyAmount));
            }
            if(tilemap)
            {
                StartCoroutine(FadeOnMoveRoutine(tilemap, fadeTime, tilemap.color.a, transparencyAmount));
            }
        }
    }

    /// <summary>
    /// OnTriggerExit2D Method
    /// End Of Blur Object When Player Behind
    /// </summary>
    /// <param name="collision">Check For Player Has Left Behind The Object</param>
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>())
        {
            if (spriteRenderer)
            {
                StartCoroutine(FadeOnMoveRoutine(spriteRenderer, fadeTime, spriteRenderer.color.a, 1f));
            }
            if (tilemap)
            {
                StartCoroutine(FadeOnMoveRoutine(tilemap, fadeTime, tilemap.color.a, 1f));
            }
        }
    }
    
    /// <summary>
    /// FadeOnMoveRoutine OveLoad Method
    /// Blur Object (SriteRenderer/Tilemap)
    /// </summary>
    /// <param name="spriteRenderer">Object SpriteRenderer</param>
    /// <param name="fadeTime">Time For Fade Routine</param>
    /// <param name="startValue">Start Alpha Color On RBGA</param>
    /// <param name="targetTransParencyAmount">Target TransParency</param>
    /// <returns>IEnumerator</returns>
    private IEnumerator FadeOnMoveRoutine(SpriteRenderer spriteRenderer, float fadeTime, float startValue, float targetTransParencyAmount)
    {
        float elapsedTime = 0;

        while (elapsedTime < fadeTime)
        {
            elapsedTime += Time.deltaTime;
            float newAlpha = Mathf.Lerp(startValue, targetTransParencyAmount, elapsedTime / fadeTime);
            spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, newAlpha);

            yield return null;
        }
    }
    private IEnumerator FadeOnMoveRoutine(Tilemap tilemap, float fadeTime, float startValue, float targetTransParencyAmount)
    {
        float elapsedTime = 0;

        while (elapsedTime < fadeTime)
        {
            elapsedTime += Time.deltaTime;
            float newAlpha = Mathf.Lerp(startValue, targetTransParencyAmount, elapsedTime / fadeTime);
            tilemap.color = new Color(tilemap.color.r, tilemap.color.g, tilemap.color.b, newAlpha);

            yield return null;
        }
    }
}
