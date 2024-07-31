using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public interface IEnemyMoveable
{
    NavMeshAgent Agent { get; set; }
    bool IsFacingTowardsPlayer {  get; set; }

    void MoveEnemy(Transform goal, string speed);
    void CheckForFacing (Transform goal);
}
