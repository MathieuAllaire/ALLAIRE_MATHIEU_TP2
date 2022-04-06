using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
public class warrock : MonoBehaviour
{
     NavMeshAgent nm;
    Rigidbody rb;
    //Animation anim;
    public Transform Target;
    public Transform[] WayPoints;
    public int Cur_WayPoints;
    public int speed, stop_distance;
    public float PauseTimer;
    [SerializeField]
    private float cur_timer;
    //private bool isAgentBusy = false;


    // Start is called before the first frame update
    void Start()
    {
        nm = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();

        rb.freezeRotation = true;

        Target = WayPoints[Cur_WayPoints];
        cur_timer = PauseTimer;
        //agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        //Settings Updated
        nm.acceleration = speed;
        nm.stoppingDistance = stop_distance;

        float distance = Vector3.Distance(transform.position, Target.position);


        //Move to Waypoint
        if(distance > stop_distance && WayPoints.Length > 0)
        {
            //Animator : Set Bool for moving = True
            //Animator : Set Bool for Idle = false;
            //Find Waypoint
            Target = WayPoints[Cur_WayPoints];
        }
        else if(distance <= stop_distance && WayPoints.Length > 0)
        {
            if(cur_timer > 0)
            {
                cur_timer -= 0.01f;
                //Animator : Set Bool for moving = False
                //Animator : Set Bool for Idle = True;
            }
            if (cur_timer <= 0)
            {
                Cur_WayPoints++;
                if (Cur_WayPoints >= WayPoints.Length)
                {
                    Cur_WayPoints = 0;
                }
                Target = WayPoints[Cur_WayPoints];
                cur_timer = PauseTimer;
            }
        }

        nm.SetDestination(Target.position);


        //if (!isAgentBusy)
        //{
        //    Vector3 newDestination = new Vector3(Random.Range(-29f, 41.6f), 1f, Random.Range(2.9f, -103.1f));
        //
        //    agent.SetDestination(newDestination);
        //
        //    isAgentBusy = true;
        //}

    }
    
}