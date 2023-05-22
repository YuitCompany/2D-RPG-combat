using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    private PlayerControls playerControls;
    private Animator swordAnim;


    /// <summary>
    /// Unity System method
    /// </summary>
    private void Awake()
    {
        swordAnim = GetComponent<Animator>();
        playerControls = new PlayerControls();
    }

    private void Start()
    {
        playerControls.Combat.Attack.started += _ => Attack();
    }

    /// <summary>
    /// Sword Method
    /// </summary>
    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void Attack()
    {
        swordAnim.SetTrigger("Attack");
    }
}
