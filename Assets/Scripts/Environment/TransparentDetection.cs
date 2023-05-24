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
     
    // start change opaty (Object)
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

    // stop change opaty (Object)
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

    // hidden Objet when player Move to Objet (SriteRenderer/Tilemap)
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
