using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// @author Mathieu Allaire
/// @desc The night shade enemy that inherits from enemy
/// </summary>
public class NightShade : Enemy
{
    

    #region Monobehaviour
    // Start is called before the first frame update
    override public void Awake()
    {
        base.Awake();
        //Set night shade health
        Health = 20;
    }

    // Update is called once per frame
    override public void Update()
    {

    }



    #endregion
    public override void Die()
    {
        Manager.gold += 2;
        base.Die();
    }
}