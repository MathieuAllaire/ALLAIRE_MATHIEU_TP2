using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// @author Mathieu Allaire
/// @desc Abstract class for an enemy
/// </summary>
public class Enemy : MonoBehaviour
{

    #region Getter/setters
    //Agent that lets the enemy follow the path
    public NavMeshAgent Agent { get; private set; }

    //Destination of our enemy
    public Vector3 Destination { get; set; }

    //Amount of time before our enemy disapears on death
    public float DeathTimer { get; set; }

    //Amount of health the enemy has
    private int health;
    public int Health 
    {
        get { return health; }
        set
        {
            if (value > 0)
            {
                health = value;
            } 
            else
            {
                //If were trying to set health below 0, default to 0
                health = 0;
            }
        } 
    }

    //Animator of the enemy (walking animation, etc.)
    public Animator Anim { get; private set; }

    #endregion

    #region MonoBehaviour
    // Start is called before the first frame update
    void Start()
    {
        //Set the kinematics to true (so our enemy is able to stand, walk, etc.)
        SetKinematic(true);
        //Get our animator component
        Anim = GetComponent<Animator>();
        //Get our agent component
        Agent = GetComponent<NavMeshAgent>();
        //Set default enemy health to 3
        Health = 3;
        //Set default death timer to 2 seconds
        DeathTimer = 2f;
        //Set our enemy destination
        Destination = new Vector3(16f, 0f, -52f);
        Agent.SetDestination(Destination);
    }

    // Update is called once per frame
    void Update()
    {

    }

    #endregion

    #region Methods
    //Handles the death of our enemy
    public void TakeDamage(int amount)
    {
        //Make sure our value is positive so we don't give hp to our enemy
        Health -= Math.abs(amount);

        //If the health is 0 or below, enemy die's
        if (Health <= 0f)
        {
            Die();
        }
    }

    //Handles the death of our enemy
    private void Die()
    {
        //Set kinematics to false so our enemy starts to ragdoll to death
        SetKinematic(false);
        //stop the movement of the enemy
        Agent.isStopped = true;
        //stop the animations
        Anim.enabled = false;
        //Destroy our enemy after X seconds
        Destroy(gameObject, DeathTimer);
    }

    //Takes all our rigidbodies 
    void SetKinematic(bool newValue)
    {
        Rigidbody[] bodies = GetComponentsInChildren<Rigidbody>();
        foreach (Rigidbody rb in bodies)
        {
            rb.isKinematic = newValue;
        }
    }

    #endregion

}