using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.AI;
using static UnityEditor.PlayerSettings;

public class CProjectile : MonoBehaviour, IMoveProjectile
{
    public NavMeshAgent Agent { get; set; }
    private bool IsMoveEnabled = false;
    private Transform TargetPos;
    private Vector3 Direction;
    private float DeathTimer = 0f;
    private void Start()
    {
        
        

    }
    public void MoveProjectile(Transform goal, float speed)
    {
        TargetPos = goal;
        Direction = (TargetPos.position - this.transform.position).normalized;
        Debug.Log(Direction);
        Direction *= speed / 100;
        gameObject.SetActive(true);
        StartCoroutine(MoveTowardsPlayer(speed));

    }
  
    IEnumerator MoveTowardsPlayer(float speed)
    {
        while (true)
        {
            yield return new WaitForSeconds(0.01f);
            DeathTimer++;
            gameObject.transform.position = new Vector3(transform.position.x + Direction.x, transform.position.y, transform.position.z + Direction.z);
            if(DeathTimer > 300f)
            {
                Destroy(gameObject);
            }
        }
        
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.transform == TargetPos)
        {
            Destroy(gameObject);
        }
    }
}
