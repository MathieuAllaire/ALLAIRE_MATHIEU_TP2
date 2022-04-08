using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// @author Mathieu Allaire
/// @desc The night shade enemy that inherits from enemy
/// </summary>
public class Warrock : Enemy
{

    #region Monobehaviour
    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        //Set night shade health
        Health = 20;
    }

    // Update is called once per frame
    void Update()
    {

    }

    #endregion

}