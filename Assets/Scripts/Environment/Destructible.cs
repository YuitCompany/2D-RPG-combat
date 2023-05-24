using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour
{
    [SerializeField] private GameObject destroyVFX;
    [SerializeField] private float objectHealth = 2;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<DamageSource>())
        {
            objectHealth -= 1;
            Instantiate(destroyVFX, this.transform.position, Quaternion.identity);

            if(objectHealth <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
