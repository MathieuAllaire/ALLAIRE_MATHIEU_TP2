using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class CubeColliderChateau : MonoBehaviour
{
    public GuiManager manager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ennemie")
        {
            manager.hpInt --;
            Destroy(collision.gameObject);
        }
    }
}
