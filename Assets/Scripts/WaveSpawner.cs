using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// @author Mathieu Allaire
/// @desc Manages the wave of enemy spawning
/// </summary>
public class WaveSpawner : MonoBehaviour
{

    #region Getter/Setter
    //if we need to spawn the next wave or not
    public bool NeedToSpawn { get; set; }
    //The wave we're currently in
    public int CurrentWave { get; set; }
    //minimum amount of enemies in a wave
    public const int MinimumEnemyInWave = 2;
    //delay before starting the first wave
    public const float DelayBeforeStarting = 3.0f;
    //Current timer
    public float Timer { get; set; }
    //total enemy in the current wave
    private int enemyTotalInWave;
    public int EnemyTotalInWave
    {
        get { return enemyTotalInWave; }
        set
        {
            if (value <= 0)
            {
                enemyTotalInWave = MinimumEnemyInWave;
            }
            else
            {
                enemyTotalInWave = value;
            }
        }
    }

    //enemy left in the current wave
    public int EnemyLeftInWave { get; set; }
    //Time we wait between enemy spawning
    public const float TimeBetweenSpawn = 1.0f;

    //List of our enemy prefabs to spawn
    [SerializeField]
    private GameObject[] enemiesPrefab;

    //Spawn point of enemies
    [SerializeField]
    private GameObject spawnPoint;

    #endregion

    #region Monobehaviour
    // Start is called before the first frame update
    void Start()
    {
        NeedToSpawn = true;
        Timer = DelayBeforeStarting;
        CurrentWave = 1;
    }

    // Update is called once per frame
    void Update()
    {
        //If timer is equals to 0 and need to spawn, spawn the next wave
        if (Timer <= 0f && NeedToSpawn)
        {
            SpawnWave(CurrentWave);
            NeedToSpawn = false;
        }
        else if(Timer >= 0f)
        {
            Timer -= Time.deltaTime;
        }

    }

    #region Methods
    //Spawn the current wave
    public void SpawnWave(int wave)
    {
        EnemyTotalInWave = GetAmtEnemyInWave(wave);
        EnemyLeftInWave = EnemyTotalInWave;
        StartCoroutine(SpawnEnemy());
        
    }

    //Get the amount of enemy to spawn in a wave
    private int GetAmtEnemyInWave(int wave)
    {
        return MinimumEnemyInWave + (Random.Range(CurrentWave, CurrentWave + 2));
    }

    //Executes when an enemy dies
    public void EnemyDie()
    {
        EnemyLeftInWave--;
        if (EnemyLeftInWave <= 0)
        {
            CurrentWave++;
            NeedToSpawn = true;
            Timer = DelayBeforeStarting / 3f;
        }
    }

    //Spawn a random enemy
    IEnumerator SpawnEnemy()
    {
        for(int i = 0; i < EnemyTotalInWave; i++)
        {
            GameObject enemytoSpawnPrefab = enemiesPrefab[Random.Range(0, enemiesPrefab.Length)];
            GameObject enemyToSpawn = Instantiate(enemytoSpawnPrefab, spawnPoint.transform.position, Quaternion.identity);
            Animator animComponent = enemyToSpawn.GetComponent<Animator>();
            animComponent.enabled = true;
            yield return new WaitForSeconds(TimeBetweenSpawn);
        }
        
    }

    #endregion


    #endregion

}