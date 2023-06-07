using UnityEngine;
using UnityEngine.UI;

public class HealthChange : MonoBehaviour
{
    [SerializeField] private GameObject healthChangePrefabs;
    [SerializeField] private Transform textStartPos;

    private GameObject healthChange;

    /// <summary>
    /// ShowTakeDamageUI Method
    /// After Take Damge
    /// Show Amount Of Damage Taken
    /// By Initializing A Text Object
    /// </summary>
    /// <param name="source">Damage Amount</param>
    public void ShowTakeDamageUI(int source)
    {
        healthChange = Instantiate(healthChangePrefabs, textStartPos.position, Quaternion.identity);
        healthChange.transform.SetParent(textStartPos);
        TakeChangeHealth(source);
    }

    /// <summary>
    /// TakeChangeHealth Method
    /// Change The Text Color
    /// With The Amount Of Damage/Heal Received
    /// Damage: source >= 0
    /// heal: source < 0
    /// </summary>
    /// <param name="source">Damage Amount</param>
    private void TakeChangeHealth(int source)
    {
        if (source >= 0)
        {
            healthChange.GetComponent<Text>().color = Color.red;
            healthChange.GetComponent<Text>().text = '-' + source.ToString();
        }
        else
        {
            healthChange.GetComponent <Text>().color = Color.green;
            healthChange.GetComponent<Text>().text = '+' + source.ToString();
        }
    }
}
