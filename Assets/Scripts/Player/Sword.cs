using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

using BaseCharacter;


public class Sword : MonoBehaviour
{
    [SerializeField] private GameObject slashAnimPrefas;
    [SerializeField] private Transform slashAnimSpamPoint;

    private PlayerControls playerControls;
    private Animator swordAnim;
    private PlayerController playerController;
    private ActiveWeapon activeWeapon;

    private GameObject slashAnim;

    private bool isAttacking;

    /// <summary>
    /// Unity System method
    /// </summary>
    private void Awake()
    {
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
    /// Sword Private Method
    /// </summary>
    // enable for PlayerControls Script on class
    private void OnEnable()
    {
        playerControls.Enable();
    }

    // get trigger create motion for sword
    private void Attack()
    {
        if(isAttacking) { return; }

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

    // sword has facing to mouse
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
    /// Sword Public Method
    /// </summary>
    // unenable Sword Conllider
    public void DoneAttackingAnimEvent()
    {
        this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
    }

    // rotation slash anim with up attack
    public void SlashUpFlipAnimEvent()
    {
        slashAnim.gameObject.transform.rotation = Quaternion.Euler(180, 0, 0);

        if(playerController.IsFacingLeft)
        {
            slashAnim.GetComponent<SpriteRenderer>().flipX = true;
        } 
    }

    // rotation slash anim with down attack
    public void SlashDownFlipAnimEvent()
    {
        slashAnim.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);

        if (playerController.IsFacingLeft)
        {
            slashAnim.GetComponent<SpriteRenderer>().flipX = true;
        }
    }

    /// create Attacked Routine Method
    private IEnumerator EndAttackRoutine()
    {
        // feature code
        yield return new WaitForSeconds(PlayerController.Instance.playerInfo.Get_FloatProperty(PropertyType.attack_speed));
        isAttacking = false;
    }
}
