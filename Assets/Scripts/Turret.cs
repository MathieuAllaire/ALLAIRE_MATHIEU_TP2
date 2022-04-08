using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// @author Mathieu Allaire
/// @desc The abstract class for a turret
/// </summary>
public class Turret : MonoBehaviour
{

    #region Getter/setters
    //Target of the turret (the one we're currently shooting)
    private Transform Target { get; set; }

    //Damage of the turret
    private int damage;
    public int Damage 
    {  
        get{ return damage; }
        set
        {
            //If the damage of the turret is lower than 1, set it to 1
            if (value < 1)
            {
                damage = 1;
            }
            else
            {
                damage = value;
            }
        }
    }

    //Range of the turret
    private float range;
    public float Range { 
        get { return range; }
        set
        {
            //If range is set to 0 or below, set it to 1
            if (value <= 0f)
            {
                range = 1f;
            } 
            else
            {
                range = value;
            }
        }

    }

    //Tag of the enemy
    public string EnemyTag { get; set; }

    //Fire rate of the turret (1 shot every X seconds)
    private float firerate;
    public float FireRate { 
        get { return firerate; }
        set 
        {
            if (value <= 0f)
            {
                firerate = 1f;
            }
            else
            {
                firerate = value;
            }
        }
    }

    //Timer for the cooldown on the turret
    public float FireCountdown { get; set; }

    //Model to rotate
    public Transform ModelToRotate { get; set; }
    #endregion

    #region Monobehaviour
    // Start is called before the first frame update
    void Start()
    {
        //Invoke the method GetTarget every .5 seconds (so the turret aims at the target)
        InvokeRepeating("GetTarget", 0f, 0.5f);
        //Set default turret to have a fire rate of 1 shot every second
        FireRate = 1f;
        //Set the default enemy tag
        EnemyTag = "Ennemie";
        //Set the default tower damage to 1
        Damage = 1;
        //Set the default tower range to 15f
        Range = 15f;
        //Set fire count down to 0 (so it dosnt have a cd on start)
        FireCountdown = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        //If the target is null, skip
        if (Target == null)
            return;

        //Turret aim to the target
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = lookRotation.eulerAngles;
        ModelToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        //If the turret count down is 0 or below, shoot
        if (FireCountdown <= 0f)
        {
            Shoot(dir);
            FireCountdown = 1f / FireRate;
        }
        FireCountdown -= Time.deltaTime;
    }

    #endregion

    #region Methods
    void GetTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(EnemyTag);
        float shortestDist = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDist)
            {
                shortestDist = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDist <= Range)
        {
            Target = nearestEnemy.transform;
        }
        else
        {
            Target = null;
        }
    }

    //Action of shooting of the turret
    void Shoot(Vector3 dir)
    {
        RaycastHit hit;
        //Raycast to our target
        if (Physics.Raycast(transform.position, dir, out hit, Range))
        {
            //Draw the raycast in our scene view
            Debug.DrawRay(transform.position, dir, Color.red, 5.0f);

            //Grab the enemy component of our target
            Enemy enemy = hit.transform.GetComponent<Enemy>();

            //If the enemy is not null, take damage
            if (enemy != null)
            {
                enemy.TakeDamage(Damage);
            }
        }
    }
    #endregion

    #region Gizmos
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, Range);
    }

    #endregion

}
