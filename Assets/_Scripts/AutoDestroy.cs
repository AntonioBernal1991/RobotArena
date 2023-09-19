using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour
{

    //Hides objects whith a delay after it was created.


    public float destructionDelay;
    void OnEnable()
    {
     Invoke("HideObject", destructionDelay);
    }


    private void HideObject()
    {
        gameObject.SetActive(false);
    }

}
