using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Life : MonoBehaviour
{
    //Sets life amount
    [SerializeField]
    private float amount;

    public float maximumLife = 100f;
    
    //Notifies when someone lifebar is empty.
    public UnityEvent onDeath;

    public float Amount
    {
        get => amount;
        set
        {
            amount = value;
            if(amount <= 0) 
            {   
                onDeath.Invoke(); 
                
            }
        }
    }
    private void Awake()
    {
        amount = maximumLife;
    }
}
