using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// @author Mathieu Allaire
/// @desc The skeleton enemy that inherits from enemy
/// </summary>
public class Skeleton : Enemy
{

    #region Monobehaviour
    // Start is called before the first frame update
    override public void Awake()
    {
        base.Awake();
        //Set skeleton health
        Health = 10;
        MaxHealth = 10;
    }

    // Update is called once per frame
    override public void Update()
    {

    }
   

    #endregion
    public override void Die()
    {
        Manager.gold += 1;
        base.Die();
    }

}