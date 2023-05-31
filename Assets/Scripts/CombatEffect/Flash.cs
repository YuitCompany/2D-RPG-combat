using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flash : MonoBehaviour
{
    public float RestoreDefaultMatTime { get {  return restoreDefaultMatTime; } }

    [SerializeField] private Material whiteFlashMat;
    [SerializeField] private float restoreDefaultMatTime = .1f;

    private Material defauldMat;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer  = GetComponent<SpriteRenderer>();
        defauldMat = spriteRenderer.material;
    }

    /// <summary>
    /// FlashRoutine Method
    /// Object Will Be Flash: defaultMat -> WhiteFlashMat
    /// In About restoreDefaultMatTime
    /// Object Will Be Reset: whiteFlashMat -> DefaultMat
    /// </summary>
    /// <returns>IEnumerator</returns>
    public IEnumerator FlashRoutine()
    { 
        // feature code
        spriteRenderer.material = whiteFlashMat;
        yield return new WaitForSeconds(restoreDefaultMatTime);
        spriteRenderer.material = defauldMat;
    }
}
