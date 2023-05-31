using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

using BaseCharacter;


public class Sword : MonoBehaviour
{
    [SerializeField] private PlayerStats playerStats;
    [SerializeField] private GameObject slashAnimPrefas;
    [SerializeField] private Transform slashAnimSpamPoint;

    private PlayerControls playerControls;
    private Animator swordAnim;
    private PlayerController playerController;
    private ActiveWeapon activeWeapon;
    private GameObject slashAnim;

    private bool isAttacking;

    private void Awake()
    {
        playerStats = GetComponentInParent<PlayerStats>();
        playerController = GetComponentInParent<PlayerController>();
        activeWeapon = GetComponentInParent<ActiveWeapon>();
        swordAnim = GetComponent<Animator>();
        playerControls = new PlayerControls();
    }

    private void Start()
    {
        playerControls.Combat.Attack.started += _ => Attack();
    }

    private void Update()
    {
        MouseFollowWithOffset();
    }

    /// <summary>
    /// OnEnable Method
    /// Enable Attack Keyboard
    /// </summary>
    private void OnEnable()
    {
        playerControls.Enable();
    }

    /// <summary>
    /// MouseFollowWithOffset Method
    /// Player Will Loot At Mouse(Left/Right)
    /// And Sword Eke
    /// </summary>
    private void MouseFollowWithOffset()
    {
        // get mouse position in screen
        Vector3 mousePos = Input.mousePosition;
        // get player position in screen 
        Vector3 playerScreenPoint = Camera.main.WorldToScreenPoint(playerController.transform.position);

        // check location for player facing
        if (mousePos.x < playerScreenPoint.x)
        {
            activeWeapon.transform.rotation = Quaternion.Euler(0, 180, 0);
        } else
        {
            activeWeapon.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    /// <summary>
    /// Attack Method
    /// When Attacking:
    /// isAttacking = true
    /// swordAnim Will Active Through SetTrigger "Attack"
    /// Sword Collider Will Be Enable
    /// SlashAnim Will Instance And Set Locate At this.parent
    /// Start Routine After Attaked
    /// </summary>
    private void Attack()
    {
        // isAttacking: Check for CD attack
        // swordAnim == null: fix MissingReferenceException for Animator object
        if (isAttacking || swordAnim == null) { return; }

        isAttacking = true;
        // set Trigger
        swordAnim.SetTrigger("Attack");
        // Enable Sword Collider
        this.gameObject.GetComponent<BoxCollider2D>().enabled = true;

        // spawm slash anim
        slashAnim = Instantiate(slashAnimPrefas, slashAnimSpamPoint.position, Quaternion.identity);
        slashAnim.transform.parent = this.transform.parent;

        StartCoroutine(EndAttackRoutine());
    }

    /// <summary>
    /// EndAttackRounte Method
    /// Attack Being CD By Player.attack_speed
    /// </summary>
    /// <returns>IEnumerator</returns>
    private IEnumerator EndAttackRoutine()
    {
        // Attack 
        yield return new WaitForSeconds(playerStats.Get_FloatStatusPlayer(CharacterProperty.attack_speed));
        isAttacking = false;
    }

    /// <summary>
    /// DoneAttackingAnimEvent Method
    /// Sword Collider Will Be Unenable
    /// </summary>
    public void DoneAttackingAnimEvent()
    {
        this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
    }

    /// <summary>
    /// SlashUpFlipAnimEvent Method
    /// SlashAnim: Rotation 180 For Attack Up Anim
    /// </summary>
    public void SlashUpFlipAnimEvent()
    {
        slashAnim.gameObject.transform.rotation = Quaternion.Euler(180, 0, 0);

        if(playerController.IsFacingLeft)
        {
            slashAnim.GetComponent<SpriteRenderer>().flipX = true;
        } 
    }

    /// <summary>
    /// SlashDownFlipAnimEvent Method
    /// SlashAnim: Rotation 0 For Attack Down Anim
    /// </summary>
    public void SlashDownFlipAnimEvent()
    {
        slashAnim.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);

        if (playerController.IsFacingLeft)
        {
            slashAnim.GetComponent<SpriteRenderer>().flipX = true;
        }
    }

}
