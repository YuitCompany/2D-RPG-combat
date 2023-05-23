using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private float roamChangeDirTime = 2f;


    private enum SlimeState
    {
        Roaming
    }

    private SlimeState _state;
    private EnemyPathFinding enemyPathFinding;

    /// <summary>
    /// Unity System Method
    /// </summary>
    private void Awake()
    {
        enemyPathFinding = GetComponent<EnemyPathFinding>();
        _state = SlimeState.Roaming;
    }

    private void Start()
    {
        StartCoroutine(SlimeRoamingRoutine());
    }

    /// <summary>
    /// EnemyAI method
    /// </summary>
    
    // create time for change direction
    private IEnumerator SlimeRoamingRoutine()
    {
        while (_state == SlimeState.Roaming)
        {
            Vector2 roamPosition = GetRoamingPosition();
            enemyPathFinding.MoveTo(roamPosition);
            yield return new WaitForSeconds(roamChangeDirTime);
        }
    }

    // create random direction for slime
    private Vector2 GetRoamingPosition()
    {
        return new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
    }

}
