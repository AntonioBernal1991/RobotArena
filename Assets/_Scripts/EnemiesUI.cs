using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemiesUI : MonoBehaviour
{
    private Text _text;
  
    private void Start()
    {
        _text = GetComponent<Text>();
        EnemyManager.SharedInstance.onEnemyChanged.AddListener(RefreshText);
        RefreshText();
    }
    //Counts the spawned enemies.
    void RefreshText()
    {
        _text.text = "ENEMIES: " + EnemyManager.SharedInstance.EnemyCount;
    }
}
