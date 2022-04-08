using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

/// <summary>
/// @author Mathieu Allaire
/// @desc Handles the bomber turret
/// </summary>
public class TurretBomber : Turret
{

    #region Monobehaviour
    // Start is called before the first frame update
    override public void Awake()
    {
        base.Awake();
        //Set damage to 6
        Damage = 6;
    }

    #endregion
}
