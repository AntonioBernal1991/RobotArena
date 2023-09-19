using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnContact : MonoBehaviour
{
    public float damage;

    //Detects collision between a bullet and a character.
    
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        gameObject.SetActive(false);

        //Subtracts the damage inflicted from the life bar.
        Life life = other.GetComponent<Life>();
        if (life != null)
        { life.Amount -= damage;}
    }

}
