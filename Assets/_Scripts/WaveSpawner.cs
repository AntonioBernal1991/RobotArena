using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public GameObject prefab;

    public float startTime, endTime;

    public float spawnRate;
   

    //manages  spawning rate.
    void Start()
    {
        WaveManager.SharedInstance.AddWave(this);
        InvokeRepeating("SpawnEnemy", startTime, spawnRate-(Time.deltaTime/1000));
        Invoke("EndWave",endTime);
    }

    //Spawns an enemy 
    void SpawnEnemy()

    {   
        Quaternion q = Quaternion.Euler(0,
            transform.rotation.y + Random.Range(-90.0f,90.0f) ,0);

        Instantiate(prefab, transform.position,q);

    
    }
    //Ends a wave.
    void EndWave()
    {   
        WaveManager.SharedInstance.RemoveWave(this);
        CancelInvoke();
    }
   
}
