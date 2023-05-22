using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem.Utilities;

public class Sword : MonoBehaviour
{
    [SerializeField] private GameObject slashAnimPrefas;
    [SerializeField] private Transform slashAnmSpamPoint;
    //[SerializeField] private Transform weaponCollider; // bỏ

    private PlayerControls playerControls;
    private Animator swordAnim;
    private PlayerController playerController;
    private ActiveWeapon activeWeapon;

    private GameObject slashAnim;

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
        swordAnim.SetTrigger("Attack");
        this.gameObject.GetComponent<BoxCollider2D>().enabled = true;

        slashAnim = Instantiate(slashAnimPrefas, slashAnmSpamPoint.position, Quaternion.identity);
        slashAnim.transform.parent = this.transform.parent;
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
    public void DoneAttackingAnimEvent()
    {
        this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
    }

    public void SlashUpFlipAnimEvent()
    {
        slashAnim.gameObject.transform.rotation = Quaternion.Euler(180, 0, 0);

        if(playerController.IsFacingLeft)
        {
            slashAnim.GetComponent<SpriteRenderer>().flipX = true;
        } 
    }

    public void SlashDownFlipAnimEvent()
    {
        slashAnim.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);

        if (playerController.IsFacingLeft)
        {
            slashAnim.GetComponent<SpriteRenderer>().flipX = true;
        }
    }
}
