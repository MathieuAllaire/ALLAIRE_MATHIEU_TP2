using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretGun : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GetTarget()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, 10f);

        foreach (Collider c in colliders)
        {
            if (c.tag == "Ennemie")
            {
                Collider target = c;

            }
        }
    }
}
