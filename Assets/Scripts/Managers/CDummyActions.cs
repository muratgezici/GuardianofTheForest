using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CDummyActions : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 500))
        {
            transform.position = new Vector3(hit.point.x, hit.point.y, hit.point.z);
            
          
           
        }
    }
}
