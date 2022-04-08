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
    #region Getter/setter
    //Checks if the warrock is a clone or the original
    public bool IsClone { get; set; }

    //Prefab of warrock
    public GameObject warrockPrefab;

    #endregion

    #region MonoBehaviour
    // Start is called before the first frame update
    override public void Awake()
    {
        base.Awake();
        IsClone = false;
        //Set warrock health
        Health = 30;
    }

    // Update is called once per frame
    override public void Update()
    {
   
    }

    #endregion

    public override void Die()
    {
        Manager.gold += 3;
        base.Die();
        if (!IsClone)
        {
            //Instiate the 2 clones, activate the animator, set health and the clones
            GameObject warrockClone1 = Instantiate(warrockPrefab, new Vector3(transform.position.x + 1.5f, transform.position.y, transform.position.z), Quaternion.identity);
            GameObject warrockClone2 = Instantiate(warrockPrefab, new Vector3(transform.position.x - 1.5f, transform.position.y, transform.position.z), Quaternion.identity);
            Animator animator1 = warrockClone1.GetComponent<Animator>();
            Animator animator2 = warrockClone2.GetComponent<Animator>();
            Warrock warrockComponent1 = warrockClone1.GetComponent<Warrock>();
            Warrock warrockComponent2 = warrockClone2.GetComponent<Warrock>();
            warrockComponent1.IsClone = true;
            warrockComponent2.IsClone = true;
            warrockComponent1.Health = 15;
            warrockComponent2.Health = 15;
            animator1.enabled = true;
            animator2.enabled = true;
        }
    }
}