using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager SharedInstance;

    public List<Enemy> enemies;

    public int EnemyCount
    {
        get => enemies.Count;
    }

    public UnityEvent onEnemyChanged;
    
    private void Awake()
    {
        if (SharedInstance == null) 
        { 
            SharedInstance = this;
            enemies = new List<Enemy>();     
        }
        else 
        { Destroy(this); }
    }
    //Adds an enemy to the list
    public void AddEnemy(Enemy enemy)
    {
        enemies.Add(enemy);
        onEnemyChanged.Invoke();
    }
    //Removes an enemy from the list
    public void RemoveEnemy(Enemy enemy)
    {
        enemies.Remove(enemy);
        onEnemyChanged.Invoke();
    }
}
