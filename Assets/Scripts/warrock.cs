using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
public class Warrock : MonoBehaviour
{
    private NavMeshAgent agent;
    private float health = 3f;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        SetKinematic(true);
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();

        Vector3 newDestination = new Vector3(16f, 0f, -52f);
        
        agent.SetDestination(newDestination);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Death(float amount)
    {
        health -= amount;


        if (health <= 0f)
        {
            SetKinematic(false);
            agent.isStopped = true;
            animator.enabled = false;
            
            Destroy(gameObject, 2);
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