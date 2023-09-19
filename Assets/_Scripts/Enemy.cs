using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int pointsAmount = 10 ;
    public Collider collider;
 
    private void Awake()
    {
        var life = GetComponent<Life>();
        life.onDeath.AddListener(DestroyEnemy);
        
    }
    //Adds the enemy to the enemy list of the manager.
    private void Start()
    {
        EnemyManager.SharedInstance.AddEnemy(this);
    }
    //kills the enemy
    private void DestroyEnemy()
    {
        Animator anim = GetComponent<Animator>();
        
        anim.SetTrigger("Play Die");
        Destroy(gameObject, 2);
        Destroy(collider, 0);

        EnemyManager.SharedInstance.RemoveEnemy(this);
        ScoreManager.SharedInstance.Amount += pointsAmount;
    }
    //Destroys the event listener of the enemy when it dies.
    private void OnDestroy()
    {
        var life = GetComponent <Life>();
        life.onDeath.RemoveListener(DestroyEnemy);

    }

}
