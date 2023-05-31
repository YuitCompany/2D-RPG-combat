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
    /// SlimeRoamingRoutine Method
    /// After roamChangeDirTime(Second)
    /// Create A New movement Direction
    /// </summary>
    /// <returns>IEnumerator</returns>
    private IEnumerator SlimeRoamingRoutine()
    {
        while (_state == SlimeState.Roaming)
        {
            Vector2 roamPosition = GetRoamingPosition();
            enemyPathFinding.MoveTo(roamPosition);
            yield return new WaitForSeconds(roamChangeDirTime);
        }
    }

    /// <summary>
    /// GetRoamingPosition Method
    /// Create Random Vector
    /// </summary>
    /// <returns>Vector2</returns>
    private Vector2 GetRoamingPosition()
    {
        return new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
    }

}
