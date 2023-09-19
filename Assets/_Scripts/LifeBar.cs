
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class LifeBar : MonoBehaviour
{
    [Tooltip("Target life to be reflected by the bar")]
    public Life targetLife;

    private Image _image;

    private void Awake()
    {
        _image = GetComponent<Image>();
    }

    //Shows the life Bar with the life left.
    private void Update()

        
    {
        _image.fillAmount = targetLife.Amount / targetLife.maximumLife;
    }
}