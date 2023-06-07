using UnityEngine;

public class Destructible : MonoBehaviour
{
    [SerializeField] private GameObject destroyVFX;
    [SerializeField] private float objectHealth = 2;

    /// <summary>
    /// OnTriggerEnter2D Method
    /// Plant Will Be Affected When Player Attack
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<DamageSource>())
        {
            InteractionPlant();
        }
    }

    /// <summary>
    /// InteractionPlant Method
    /// The Canopy Burst Out
    /// </summary>
    private void InteractionPlant()
    {
        objectHealth -= 1;
        Instantiate(destroyVFX, this.transform.position, Quaternion.identity);

        if(objectHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
