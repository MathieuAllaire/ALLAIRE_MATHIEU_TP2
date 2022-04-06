using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
public class warrock : MonoBehaviour
{
    private NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newDestination = new Vector3(float.PositiveInfinity, float.PositiveInfinity, float.PositiveInfinity);
        
        agent.SetDestination(newDestination);
    }
    
}