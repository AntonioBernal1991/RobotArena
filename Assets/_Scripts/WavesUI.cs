using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WavesUI : MonoBehaviour
{
    //Updates the Waves count.
    private Text _text;
    private void Start()
    {
        _text = GetComponent<Text>();
        WaveManager.SharedInstance.onWaveChanged.AddListener(RefreshText);
        RefreshText();
    }

    void RefreshText()
    {
        _text.text = "WAVE: " +
                   WaveManager.SharedInstance.MaxWaves;
                 
    }
}
