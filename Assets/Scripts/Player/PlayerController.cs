using System;
using System.Collections;
using UnityEngine;

using BaseCharacter;


public class PlayerController : Singleton<PlayerController>
{
    public bool IsFacingLeft { get { return isFacingLeft; } set { isFacingLeft = value; } }

    [SerializeField] private TrailRenderer dashTrailRenderer;

    private PlayerControls playerControls;
    private Vector2 player_Movement;
    private Rigidbody2D player_rb;
    private Animator playerMovingAnim;
    private SpriteRenderer playerSpriteRenderer;
    private float dashTime = .2f;

    public CharacterStar playerInfo;

    private bool isFacingLeft = false;
    private bool isDashing;

    /// <summary>
    /// unity system method
    /// </summary>
    protected override void Awake()
    {
        base.Awake();

        playerControls = new PlayerControls();

        player_rb = GetComponent<Rigidbody2D>();
        playerMovingAnim = GetComponent<Animator>();
        playerSpriteRenderer = GetComponent<SpriteRenderer>();

        playerInfo = new CharacterStar();
        CreatePlayer(playerInfo);
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
    /// PlayerController method
    /// </summary>
    
    // Enable playerControls script
    private void OnEnable()
    {
        playerControls.Enable();
    }

    // get controls input on playerControls
    private void PlayerInput()
    {
        player_Movement = playerControls.Movement.Move.ReadValue<Vector2>();

        // setup player move animation with player_movement
        playerMovingAnim.SetFloat("MoveX", player_Movement.x);
        playerMovingAnim.SetFloat("MoveY", player_Movement.y);
    }

    // set move for player
    private void PlayerMove()
    {
        player_rb.MovePosition(player_rb.position + player_Movement *
            (playerInfo.Get_FloatProperty(PropertyType.move_speed) * Time.fixedDeltaTime));
    }

    // player has facing to mouse
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

    // Player has move faster
    private void Dash()
    {
        if (isDashing) { return; }

        isDashing = true;
        playerInfo.Set_Property(PropertyType.move_speed, playerInfo.Get_FloatProperty(PropertyType.dash_amount));
        dashTrailRenderer.emitting = true;
        StartCoroutine(EndDashRoutine());
    }

    ///
    /// create EndDash Routine Method
    ///
    private IEnumerator EndDashRoutine()
    {
        // feature code
        yield return new WaitForSeconds(dashTime);
        playerInfo.Set_Property(PropertyType.move_speed, playerInfo.Get_FloatProperty(PropertyType.defaut_move_speed));
        dashTrailRenderer.emitting = false;
        yield return new WaitForSeconds(playerInfo.Get_FloatProperty(PropertyType.dash_cd));
        isDashing = false;
    }

    // add data
    private void CreatePlayer(CharacterStar player)
    {
        player.Add_Property(new StringProperty(PropertyType.name, "Yuit"));
        player.Add_Property(new IntProperty(PropertyType.level, 1));

        player.Add_Property(new IntProperty(PropertyType.health_point, 100));
        player.Add_Property(new IntProperty(PropertyType.max_health_point, 100));

        player.Add_Property(new IntProperty(PropertyType.mana_point, 20));
        player.Add_Property(new IntProperty(PropertyType.max_mana_point, 20));

        player.Add_Property(new FloatProperty(PropertyType.defaut_move_speed, 5f));
        player.Add_Property(new FloatProperty(PropertyType.move_speed, 5f));

        player.Add_Property(new FloatProperty(PropertyType.dash_amount, 20f));
        player.Add_Property(new FloatProperty(PropertyType.dash_cd, 1f));

        player.Add_Property(new IntProperty(PropertyType.attack_amount, 1));
        player.Add_Property(new FloatProperty(PropertyType.attack_speed, .5f));

        player.Add_Property(new IntProperty(PropertyType.defense_amount, 3));

        player.Add_Property(new IntProperty(PropertyType.anti_effect, 30));
    }
}
