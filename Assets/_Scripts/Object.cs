using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour
{
    //Everytime the player collides this object , he obtains 50 bullets more.

    public PlayerShooting bullets;
    public AudioSource reload;
    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
        {
            bullets.bulletsAmount += 50;
            reload.Play();
            
            
        }

    }








}
