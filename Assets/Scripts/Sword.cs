using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Sword : MonoBehaviour
{
    private PlayerControls playerControls;
    private Animator swordAnim;
    private PlayerController playerController;
    private ActiveWeapon activeWeapon;

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
    /// Sword Method
    /// </summary>
    // enable for PlayerControls Script on class
    private void OnEnable()
    {
        playerControls.Enable();
    }

    // get trigger creat motion for sword
    private void Attack()
    {
        swordAnim.SetTrigger("Attack");
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
}
