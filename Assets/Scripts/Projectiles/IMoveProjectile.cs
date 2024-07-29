using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public interface IMoveProjectile
{
    NavMeshAgent Agent { get; set; }
    void MoveProjectile(Vector3 goal, float speed, string target_tag);
}
