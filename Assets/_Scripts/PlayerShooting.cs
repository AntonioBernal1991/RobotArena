using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{


    private float lastShootTime;
    public float shootRate;

    public GameObject shootingPoint;
    public ParticleSystem fireEffect;
    public AudioSource shootingSound;


    private Animator _animator;
    public int bulletsAmount;

    

    

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }


    //Checks if mouse is pressed.
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && Time.timeScale > 0)
        {

            shoot();

        }
    }
    //Shoots bullet
    public void shoot()
    {

        if (bulletsAmount > 0)

        {

            var timeSincelastshoot = Time.time - lastShootTime;
            if (timeSincelastshoot < shootRate)
            {
                return;
            }

            lastShootTime = Time.time;
            var bullet = ObjectPool.SharedInstance.GetFirstPooledObject();
            bullet.layer = 8;
            bullet.transform.position = shootingPoint.transform.position;
            bullet.transform.rotation = shootingPoint.transform.rotation;
            bullet.SetActive(true);
            shootingSound.Play();
            fireEffect.Play();
            bulletsAmount--;


        }




    }
}
