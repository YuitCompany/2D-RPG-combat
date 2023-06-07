using System.Collections;
using UnityEngine;

using BaseObject;


public class PlayerController : Singleton<PlayerController>
{
    public bool IsFacingLeft { get { return isFacingLeft; } set { isFacingLeft = value; } }

    [SerializeField] private PlayerStats playerStats;
    [SerializeField] private TrailRenderer dashTrailRenderer;

    private PlayerControls playerControls;
    private Vector2 player_Movement;
    private Rigidbody2D player_rb;
    private Animator playerMovingAnim;
    private SpriteRenderer playerSpriteRenderer;
    private float dashTime = .2f;

    private bool isFacingLeft = false;
    private bool isDashing;

    protected override void Awake()
    {
        base.Awake();

        playerStats = GetComponentInParent<PlayerStats>();
        playerControls = new PlayerControls();

        player_rb = GetComponent<Rigidbody2D>();
        playerMovingAnim = GetComponent<Animator>();
        playerSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        playerControls.Combat.Dash.performed += _ => Dash();
    }

    private void Update()
    {
        PlayerInput();
    }

    private void FixedUpdate()
    {
        PlayerFacingDirection();
        PlayerMove();
    }

    /// <summary>
    /// OnEnable Method
    /// Enable Movement Keyboard
    /// </summary>
    private void OnEnable()
    {
        playerControls.Enable();
    }

    /// <summary>
    /// PlayerInput Method
    /// Get Move From Keyoard
    /// Interactive Connection To Anim
    /// </summary>
    private void PlayerInput()
    {
        player_Movement = playerControls.Movement.Move.ReadValue<Vector2>();

        // setup player move animation with player_movement
        playerMovingAnim.SetFloat("MoveX", player_Movement.x);
        playerMovingAnim.SetFloat("MoveY", player_Movement.y);
    }

    /// <summary>
    /// PlayerMove Method
    /// rb.MovePosition using rb.pos, Keyboard.Move, player.move_speed, Time.fixelDeltaTime
    /// </summary>
    private void PlayerMove()
    {
        player_rb.MovePosition(player_rb.position + player_Movement *
            (playerStats.Get_FloatStatusPlayer(ObjectProperty.move_speed) * Time.fixedDeltaTime));
    }

    /// <summary>
    /// PlayerFacingDirection Method
    /// Player Will Loot At Mouse(Left/Right)
    /// </summary>
    private void PlayerFacingDirection()
    {
        // get mouse position in screen
        Vector3 mousePos = Input.mousePosition;
        // get player position in screen 
        Vector3 playerScreenPoint = Camera.main.WorldToScreenPoint(transform.position);

        // check location for player facing
        if(mousePos.x < playerScreenPoint.x)
        {
            IsFacingLeft = true;
            playerSpriteRenderer.flipX = true;
        } 
        else
        {
            IsFacingLeft = false;  
            playerSpriteRenderer.flipX = false;
        }
    }

    /// <summary>
    /// Dash Method
    /// The Player's Specal Abilities
    /// He Can Move Fast For A Short Time
    /// </summary>
    private void Dash()
    {
        if (isDashing) { return; }

        isDashing = true;
        playerStats.Change_StatusPlayer(ObjectProperty.move_speed, '+', playerStats.Get_FloatStatusPlayer(ObjectProperty.dash_amount));
        dashTrailRenderer.emitting = true;
        StartCoroutine(EndDashRoutine());
    }

    /// <summary>
    /// EndDashRoutine Method
    /// </summary>
    /// <returns>IEnumerator</returns>
    private IEnumerator EndDashRoutine()
    {
        // Player is Dashing
        yield return new WaitForSeconds(dashTime);
        playerStats.Change_StatusPlayer(ObjectProperty.move_speed, '=', playerStats.Get_FloatStatusPlayer(ObjectProperty.defaut_move_speed));
        dashTrailRenderer.emitting = false;

        // Player Geting Dash CD
        yield return new WaitForSeconds(playerStats.Get_FloatStatusPlayer(ObjectProperty.dash_cd));
        isDashing = false;
    }
}
