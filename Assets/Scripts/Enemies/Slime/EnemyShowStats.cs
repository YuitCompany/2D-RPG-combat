using BaseMonster;
using UnityEngine;
using UnityEngine.UI;

public class EnemyShowStats : MonoBehaviour
{
    [SerializeField] private SlimeStats slimeStats;

    [SerializeField] private Text textLevel;
    [SerializeField] private Text textName;

    private void Awake()
    {
        slimeStats = GetComponentInParent<SlimeStats>();    
    }

    private void Start()
    {
        textLevel.text = "Lv " + slimeStats.Get_IntStatusSlime(MonsterProperty.level).ToString();
        textName.text = slimeStats.Get_StringStatusSlime(MonsterProperty.name);
    }
}
