using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

/// <summary>
/// @author Mathieu Allaire
/// @desc Handles the turret gun
/// </summary>
public class TurretGun : Turret
{

    #region Monobehaviour
    // Start is called before the first frame update
    override public void Awake()
    {
        base.Awake();
        //Set damage to 3
        Damage = 3;
    }

    #endregion
}
