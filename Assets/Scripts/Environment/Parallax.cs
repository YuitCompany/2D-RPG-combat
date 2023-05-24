using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] private float parallaxOffset = -.15f;

    private Camera cameraSetParallax;
    private Vector2 startPos;
    private Vector2 travel => (Vector2)cameraSetParallax.transform.position - startPos;

    /// <summary>
    /// Unity System Method
    /// </summary>
    private void Awake()
    {
        cameraSetParallax = Camera.main;
    }

    private void Start()
    {
        startPos = this.transform.position;
    }

    private void FixedUpdate()
    {
        this.transform.position = startPos + travel * parallaxOffset;
    }
}
