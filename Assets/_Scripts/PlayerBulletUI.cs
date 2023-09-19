using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerBulletUI : MonoBehaviour
{
    //Shows the bullets the player has.
    private Text _text;

    public PlayerShooting targetShooting;
    private void Awake()
    {
        _text = GetComponent<Text>();

    }

    private void Update()
    {
        _text.text = "Bullets:  " +  (Mathf.Max(targetShooting.bulletsAmount, 0)).ToString();
    }
}
