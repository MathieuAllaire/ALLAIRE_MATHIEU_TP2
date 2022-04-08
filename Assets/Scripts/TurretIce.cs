using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

/// <summary>
/// @author Mathieu Allaire
/// @desc Handles the ice turret
/// </summary>
public class TurretIce : Turret
{

    #region Monobehaviour
    // Start is called before the first frame update
    override public void Awake()
    {
        base.Awake();
        //Set damage to 5
        Damage = 5;
    }

    #endregion
}
