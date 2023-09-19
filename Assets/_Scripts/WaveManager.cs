using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WaveManager : MonoBehaviour
{
    public static WaveManager SharedInstance;

    public List<WaveSpawner> waves;

    public UnityEvent onWaveChanged;
    public int GetWaves
    {
        get => waves.Count;
    }
    private int maxWaves;
    public int MaxWaves
    {
        get => maxWaves;
    }


    private void Awake()
    {
        if (SharedInstance == null)
        {
            SharedInstance = this;
            waves = new List<WaveSpawner>();
        }
        else
        {
            Destroy(this);
        }
    }

    //Adds waves.
    public void AddWave(WaveSpawner wave)
    {
        maxWaves++;
        waves.Add(wave);
        onWaveChanged.Invoke();
    }
    //Removes waves.
    public void RemoveWave(WaveSpawner wave)
    {
        waves.Remove(wave);
        onWaveChanged.Invoke();
    }
}
