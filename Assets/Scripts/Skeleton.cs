using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// @author Mathieu Allaire
/// @desc The skeleton enemy that inherits from enemy
/// </summary>
public class Warrock : Enemy
{

    #region Monobehaviour
    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        //Set skeleton health
        Health = 15;
    }

    // Update is called once per frame
    void Update()
    {

    }

    #endregion

}