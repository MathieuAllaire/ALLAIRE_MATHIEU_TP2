using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
public class Warrock : MonoBehaviour
{
    private NavMeshAgent agent;
    private int HP = 6;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        agent = GetComponent<NavMeshAgent>();

        Vector3 newDestination = new Vector3(16f, 0f, -52f);
        
        agent.SetDestination(newDestination);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Death()
    {
        if (HP == 0)
        {
            animator.enabled = false;
            SetKinematic(false);
            Destroy(gameObject, 5);
        }
    }

    void SetKinematic(bool newValue)
    {
        Rigidbody[] bodies = GetComponentsInChildren<Rigidbody>();
        foreach (Rigidbody rb in bodies)
        {
            rb.isKinematic = newValue;
        }
    }

}