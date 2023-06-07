using BaseObject;
using UnityEngine;

public class Bow : MonoBehaviour
{
    [SerializeField] private PlayerStats playerStats;
    [SerializeField] private GameObject arrowAnimPrefabs;
    [SerializeField] private Transform  arrowSpamPoint;
    [SerializeField] private Transform arrowList;
    [SerializeField] private int bowDamage = 2;

    private PlayerControls playerControls;
    private PlayerController playerController;
    private ActiveWeapon activeWeapon;
    private Animator bowAnim;
    private GameObject arrowAnim;

    bool isBowPull;
    // Code For Hold And Upper Damge (Inactive)
    //[SerializeField] private float speedPower = .5f;
    //[SerializeField] private float maxBowPower = 500f;
    [SerializeField] private float bowPower = 500f;

    private void Awake()
    {
        playerStats = GetComponentInParent<PlayerStats>();
        playerController = GetComponentInParent<PlayerController>();
        activeWeapon = GetComponentInParent<ActiveWeapon>();
        bowAnim = GetComponent<Animator>();
        playerControls = new PlayerControls();
    }

    private void Start()
    {
        playerControls.Combat.Attack.started += _ => StartHoldAttacking();
        playerControls.Combat.Attack.canceled += _ => StopHoldAttacking();
    }

    private void Update()
    {
        MouseFollowWithOffset();
       // if(playerControls.Combat.Attack.started) += _ => StartCoroutine(HoldAttackHigherRoutine(speedPower));
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

        activeWeapon.transform.rotation = Quaternion.Euler(0, 0, GetAngleMousePos());
    }

    /// <summary>
    /// StartHodAttacking Method
    /// Changle Bool Value when Start Holding
    /// </summary>
    private void StartHoldAttacking()
    {
        if (isBowPull) { return; }
        isBowPull = true;
        bowAnim.SetTrigger("Holding");
    }

    /// <summary>
    /// StopHodAttacking Method
    /// Changle Bool Value when Released
    /// </summary>
    private void StopHoldAttacking()
    {
        if (!isBowPull) { return; }
        //if (!(bowPower > 200f)) return;

        isBowPull = false;
        bowAnim.SetTrigger("EndHolding");

        arrowAnim = Instantiate(arrowAnimPrefabs, arrowSpamPoint.position, arrowSpamPoint.rotation);
        arrowAnim.GetComponent<Rigidbody2D>().AddForce(arrowSpamPoint.transform.right * bowPower);
        arrowAnim.GetComponent<Arrow>().angle = GetAngleMousePos();
        arrowAnim.GetComponent<Arrow>().arrowDamage = bowDamage + playerStats.Get_IntStatusPlayer(ObjectProperty.attack_amount);
        arrowAnim.transform.SetParent(arrowList.transform);
        //bowPower = 0f;
    }

    private float GetAngleMousePos()
    {
        // get mouse position in screen
        Vector3 mousePos = Input.mousePosition;
        // get player position in screen 
        Vector3 playerScreenPoint = Camera.main.WorldToScreenPoint(playerController.transform.position);

        return Mathf.Atan2(mousePos.y - playerScreenPoint.y, mousePos.x - playerScreenPoint.x) * Mathf.Rad2Deg;
    }
}
