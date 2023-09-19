using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    //Controls the spwaning wave countdown.
    [SerializeField] int min, seg;

    private float remaining;
    private bool onTheMove;
    public List<WaveSpawner> waves;
    private void Awake()
    {
        remaining = (min * 60) + seg;
    }
    private void Update()
    {
        if (onTheMove)
            remaining -= Time.deltaTime;
            if(remaining<1)
            {
              
              waves[0].spawnRate -= 0.001f; 
              waves[1].spawnRate -= 0.001f;
              waves[2].spawnRate -= 0.001f;
              waves[3].spawnRate -= 0.001f;
             }
            int tempMin = Mathf.FloorToInt(remaining / 60);
            int tempSeg = Mathf.FloorToInt(remaining % 60);
    }












}
