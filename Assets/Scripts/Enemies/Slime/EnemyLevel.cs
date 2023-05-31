using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyLevel : MonoBehaviour
{
    [SerializeField] private int currentLevel = 1;

    private void Update()
    {
        this.gameObject.GetComponent<Text>().text = "Lv " + currentLevel.ToString();
    }
}
