using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flash : MonoBehaviour
{
    [SerializeField] private Material whiteFlashMat;
    [SerializeField] private float restoreDefaultMatTime = .1f;

    private Material defauldMat;
    private SpriteRenderer spriteRenderer;

    /// <summary>
    /// unity Sytem Method
    /// </summary>
    private void Awake()
    {
        spriteRenderer  = GetComponent<SpriteRenderer>();
        defauldMat = spriteRenderer.material;
    }
    
    /// <summary>
    /// Flash Public Method
    /// </summary>
    public IEnumerator FlashRoutine()
    { 
        // feature code
        spriteRenderer.material = whiteFlashMat;
        yield return new WaitForSeconds(restoreDefaultMatTime);
        spriteRenderer.material = defauldMat;
    }

    public float GetRestoreMatTime()
    {
        return restoreDefaultMatTime;
    }
}
