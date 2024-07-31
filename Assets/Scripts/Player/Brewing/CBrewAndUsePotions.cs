using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CBrewAndUsePotions : MonoBehaviour
{
    CPlayer _Player;
    private int TreeCount = 0;
    private int MushroomCount = 0;
    private int FlowerCount = 0;
    [SerializeField] GameObject BigProjectile;
    [SerializeField] GameObject MultipleProjectile;
    [SerializeField] GameObject[] Aims;
    private void Start()
    {
        _Player = GetComponentInParent<CPlayer>();
        
    }
    private void Update()
    {
        TreeCount = _Player.TreeCount;
        MushroomCount= _Player.MushroomCount;
        FlowerCount= _Player.FlowerCount;

        if(TreeCount>0 && MushroomCount>0 && Input.GetMouseButtonDown(1))
        {
            GameObject closest_enemy = GetClosestEnemy();
            //Debug.Log(Enemies.Count);
            if (closest_enemy != null)
            {
                GameObject bullet = GameObject.Instantiate(BigProjectile, transform.position, Quaternion.identity);
                bullet.GetComponent<CProjectile>().SetDamage(18f);
                bullet.GetComponent<CProjectile>().MoveProjectile(closest_enemy.transform.position, 15f, "Enemy");
                
            }
            _Player.AddMushroom(-1);
            _Player.AddTree(-1);
        }
        if (TreeCount > 0 && FlowerCount > 0 && Input.GetMouseButtonDown(0))
        {
                foreach (GameObject aim in Aims)
                {
                GameObject bullet = GameObject.Instantiate(MultipleProjectile, transform.position, Quaternion.identity);
                bullet.GetComponent<CProjectile>().SetDamage(11f);
                bullet.GetComponent<CProjectile>().MoveProjectile(aim.transform.position, 15f, "Enemy");
                }


            _Player.AddFlower(-1);
            _Player.AddTree(-1);
        }
    }

    public GameObject GetClosestEnemy()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject closest_obj = null;
        float minDist = Mathf.Infinity;
        foreach (GameObject obj in objs)
        {
            float distance = Vector3.Distance(obj.transform.position, transform.position);
            if (obj.activeSelf == true)
            {
                if (distance < minDist)
                {
                    closest_obj = obj;
                    minDist = distance;
                }
            }

        }
        return closest_obj;
    }
}
