using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public interface IMoveProjectile
{
    NavMeshAgent Agent { get; set; }
    void MoveProjectile(Transform goal, float speed);
}
