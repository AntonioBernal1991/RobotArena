using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    
    public static ScoreManager SharedInstance;
    [SerializeField]
           private int amount;
    public int Amount
    {
        get => amount;
        set => amount = value;
    }



    private void Awake()
    {
        if (SharedInstance == null)
        {
            SharedInstance = this;
        }
        else { Debug.LogWarning("Score Duplicado"); Destroy(gameObject); }
    }
}
