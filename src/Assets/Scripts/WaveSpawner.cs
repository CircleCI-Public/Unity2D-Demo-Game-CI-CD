using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    //Enemy Prefab
    public GameObject Enemy;
    public GameObject LaneControllerObject;
    private LaneController LaneController;
    //Wave information
    public int numOfWaves = 3;
    public int waveSacleFactor = 2;
    public float waveTimer = 15f;
    public int currentWave = 0;
    private float timeToNextWave;
    [Range(0, 1)]
    public float percentOfPassing = 0.1f;
    private bool waveIsActive = false;
    // Enemy info
    public int baseNumOfEnemies = 15;
    private int enemiesLeft;
    private float avgTimeBetweenEnemies = 0.8f;
    private float timeToNextEnemy = 1f;
    // Start is called before the first frame update
    void Start()
    {
        timeToNextWave = waveTimer;
        enemiesLeft = baseNumOfEnemies;
        LaneController = LaneControllerObject.GetComponent<LaneController>();
        Debug.Log("Wave 1 begin!");
        currentWave = 1;
        waveIsActive = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (waveIsActive) //Is there currently an active wave?
        {
            if (enemiesLeft > 0) // Do we have any more enemies to spawn in this wave?
            {
                if ( timeToNextEnemy <= 0)
                {
                    enemiesLeft--;
                    SpawnEnemy();
                    timeToNextEnemy = avgTimeBetweenEnemies;
                }
                else
                {
                    timeToNextEnemy = timeToNextEnemy - avgTimeBetweenEnemies * Time.deltaTime;
                }
            }
            else // No more enemies to spawn? Time to end the wave
            {
                waveIsActive = false;

            }
            
        }
        else
        {
            if (currentWave <= numOfWaves ) // Are there any more waves to start?
            {
                if ( timeToNextWave <= 0)
                {
                    timeToNextWave = waveTimer;
                    NextWave();
                }
                else
                {
                    timeToNextWave -= Time.deltaTime;
                }
                
            }
        }
    }

    void SpawnEnemy()
    {
        float heightOfLane = 1f;
        float baseLine = 0.89f;
        float spawnLane = Random.Range(0, LaneController.numOfLanes - 1);
        Debug.Log("spawn lane: " + spawnLane.ToString());
        Vector3 startPos = new Vector3(10.20f, (baseLine + (heightOfLane * spawnLane)), 0);
        Instantiate(Enemy, startPos, Quaternion.identity);
    }
    void NextWave()
    {
        Debug.Log("starting wave: " + currentWave.ToString());
        currentWave++;
        enemiesLeft = (baseNumOfEnemies * currentWave);
        waveIsActive = true;
    }

}
