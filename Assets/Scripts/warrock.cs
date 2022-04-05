using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class warrock : MonoBehaviour
{
    private NavMeshAgent agent;

    private bool isAgentBusy = false;

    private Animator animatorWarrok;

    private float inputVertical;
    private float inputHorizontal;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        animatorWarrok = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        inputVertical = input.GetAxis("Vertical");

        if (!isAgentBusy)
        {
            Vector3 newDestination = new Vector3(Random.Range(-12f, 8f), 1f, Random.Range(-12f, 12));

            agent.SetDestination(newDestination);

            isAgentBusy = true;
        }

        if (inputVertical > 0.1f)
        {
            animatorWarrok.SetBool("isWalking", true);
        }
        else
        {
            animatorWarrok.SetBool("isWalking", false);
        }
    }
}