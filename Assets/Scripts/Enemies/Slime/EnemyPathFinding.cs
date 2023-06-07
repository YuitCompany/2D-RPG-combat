using UnityEngine;
using BaseObject;

public class EnemyPathFinding : MonoBehaviour
{
    [SerializeField] private SlimeStats slimeStats;

    private Rigidbody2D slime_rb;
    private Vector2 moveDir;
    private Animator slimeMovingAnim;
    private SpriteRenderer slimeSpriteRenderer;
    private KnockBack knockBack;

    /// <summary>
    /// Unity System Method
    /// </summary>
    private void Awake()
    {
        slimeStats = GetComponentInParent<SlimeStats>();
        slime_rb = GetComponent<Rigidbody2D>();
        slimeMovingAnim = GetComponent<Animator>();
        slimeSpriteRenderer = GetComponent<SpriteRenderer>();
        knockBack = GetComponent<KnockBack>();
    }

    private void FixedUpdate()
    {
        if (knockBack.IsKnockedBack) { return; }
        slime_rb.MovePosition(slime_rb.position + moveDir * 
            (slimeStats.Get_FloatStatusSlime(ObjectProperty.move_speed) * Time.fixedDeltaTime));
    }

    /// <summary>
    /// EnemyPathFinding Public method
    /// </summary>
    public void MoveTo(Vector2 targetPosition)
    {
        // get change Direction
        moveDir = targetPosition;
        
        // FacingAnimation for movement(left/right)
        if (moveDir.x > 0)
        {
            slimeSpriteRenderer.flipX = false;
        }
        else
        {
            slimeSpriteRenderer.flipX = true;
        }

        // check movement for change moving Animation
        if (moveDir.x != 0 || moveDir.y != 0)
        {
            slimeMovingAnim.SetBool("isMoving", true);
        }
        else
        {
            slimeMovingAnim.SetBool("isMoving", false);
        }
    }
}
