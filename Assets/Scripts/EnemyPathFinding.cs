using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class EnemyPathFinding : MonoBehaviour
{
    [SerializeField] private float slimeMoveSpeed = 2f;

    private Rigidbody2D slime_rb;
    private Vector2 moveDir;
    private Animator slimeMovingAnim;
    private SpriteRenderer slimeSpriteRenderer;


    /// <summary>
    /// Unity System Method
    /// </summary>
    private void Awake()
    {
        slime_rb = GetComponent<Rigidbody2D>();
        slimeMovingAnim = GetComponent<Animator>();
        slimeSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        slime_rb.MovePosition(slime_rb.position + moveDir * (slimeMoveSpeed * Time.fixedDeltaTime));
    }

    /// <summary>
    /// EnemyPathFinding Public method
    /// </summary>
    public void MoveTo(Vector2 targetPosition)
    {
        // get change Direction
        moveDir = targetPosition;
        
        // FacingAnimation for movement(left/right)
        if (moveDir.x > 0) slimeSpriteRenderer.flipX = false;
        else slimeSpriteRenderer.flipX = true;

        // check movement for change moving Animation
        if (moveDir.x != 0 || moveDir .y != 0) slimeMovingAnim.SetBool("isMoving", true);
        else slimeMovingAnim.SetBool("isMoving", false);
    }
}
