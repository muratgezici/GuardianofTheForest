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
    private Vector3 TargetPos;
    private string TargetTag = "";
    private Vector3 Direction;
    private float DeathTimer = 0f;
    private float Damage = 0f;
    private void Start()
    {
        
        

    }
    public void SetDamage(float damage)
    {
        Damage = damage;
    }
    public void MoveProjectile(Vector3 goal, float speed, string target_tag)
    {
        TargetPos = goal;
        TargetTag = target_tag;
        Direction = (TargetPos - this.transform.position).normalized;
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
        if (collision.gameObject.tag == TargetTag)
        {
            if(TargetTag == "Player")
            {
                collision.gameObject.GetComponent<CPlayer>().Damage(Damage);
            }
            else if(TargetTag == "Enemy")
            {
                collision.gameObject.GetComponent<CEnemy>().Damage(Damage);
            }
            
            Destroy(gameObject);
        }
    }
}
