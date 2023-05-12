using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float playerMovementSpeed = 1f;

    private PlayerControls playerControls;
    private Vector2 player_Movement;
    private Rigidbody2D player_rb;
    private Animator playerMovingAnim;


    /// <summary>
    /// unity system method
    /// </summary>
    private void Awake()
    {
        playerControls = new PlayerControls();
        player_rb = GetComponent<Rigidbody2D>();
        playerMovingAnim = GetComponent<Animator>();
    }

    private void Update()
    {
        PlayerInput();
    }

    private void FixedUpdate()
    {
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

        playerMovingAnim.SetFloat("MoveX", player_Movement.x);
        playerMovingAnim.SetFloat("MoveY", player_Movement.y);
    }

    // set move for player
    private void PlayerMove()
    {
        player_rb.MovePosition(player_rb.position + player_Movement * playerMovementSpeed * Time.fixedDeltaTime);
    }
}
