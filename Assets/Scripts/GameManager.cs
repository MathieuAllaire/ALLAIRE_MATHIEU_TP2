using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GameManager : MonoBehaviour
{
    public NavMeshAgent agent;
    public bool isAgentBusy = false;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //Si l'agent n'est pas occupé
        if (!isAgentBusy)
        {
            //Je lui donne une destination
           
        }
    }
}
