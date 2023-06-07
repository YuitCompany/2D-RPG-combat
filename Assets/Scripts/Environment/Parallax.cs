using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] private float parallaxOffset = -.15f;

    private Camera cameraSetParallax;
    private Vector2 startPos;
    private Vector2 travel => (Vector2)cameraSetParallax.transform.position - startPos;

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
        // Object Will Be Move Opposite A Bit
        this.transform.position = startPos + travel * parallaxOffset;
    }
}
