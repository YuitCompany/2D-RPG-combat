using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public bool IsFacingLeft { get { return isFacingLeft; } set { isFacingLeft = value; } }

    [SerializeField] private float playerMovementSpeed = 1f;

    private PlayerControls playerControls;
    private Vector2 player_Movement;
    private Rigidbody2D player_rb;
    private Animator playerMovingAnim;
    private SpriteRenderer playerSpriteRenderer;

    private bool isFacingLeft = false;

    /// <summary>
    /// unity system method
    /// </summary>
    private void Awake()
    {
        playerControls = new PlayerControls();
        player_rb = GetComponent<Rigidbody2D>();
        playerMovingAnim = GetComponent<Animator>();
        playerSpriteRenderer = GetComponent<SpriteRenderer>();
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
        player_rb.MovePosition(player_rb.position + player_Movement * (playerMovementSpeed * Time.fixedDeltaTime));
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
}
