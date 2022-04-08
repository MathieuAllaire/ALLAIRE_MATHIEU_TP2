using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// @author Mathieu Allaire
/// @desc The warrock enemy that inherits from enemy
/// </summary>
public class Warrock : Enemy
{

    #region MonoBehaviour
    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        //Set warrock health
        Health = 10;
    }

    // Update is called once per frame
    void Update()
    {

    }

    #endregion

}