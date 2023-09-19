using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMode : MonoBehaviour
{
    [SerializeField]

    private Life playerLife;

    [SerializeField]

    private Life baseLife;
    //Checks the death , loose and win events.
    private void Start()
    {
        playerLife.onDeath.AddListener(OnPlayerLose);
        baseLife.onDeath.AddListener(OnPlayerLose);
        EnemyManager.SharedInstance.onEnemyChanged.AddListener(OnPlayerWin);
    }

    //Saves score and loads the loose scene.
    void OnPlayerLose()
    {
        RegisterScore();
        SceneManager.LoadScene("LooseScene", LoadSceneMode.Single);
        
    }
    //Saves score and loads the loose scene.
    void OnPlayerWin()
    {
        if (EnemyManager.SharedInstance.EnemyCount <= 0 &&
            WaveManager.SharedInstance.GetWaves <= 0)
        {
            RegisterScore();
            SceneManager.LoadScene("WinScene", LoadSceneMode.Single);
        }
    }
    //Saves score and loads the win scene.
    void RegisterScore()
    {
        var actualScore  = ScoreManager.SharedInstance.Amount;
       PlayerPrefs.SetInt("Last Score", actualScore);

        var highScore = PlayerPrefs.GetInt("High Score",0);
        if (actualScore > highScore)
        {
            PlayerPrefs.SetInt("High Score", actualScore);
        }
    }
    //Registrates time.
    void RegisterTime()
    {
        var actualTime = Time.time;
        PlayerPrefs.SetFloat("Last Time", actualTime);

        var lowTime = PlayerPrefs.GetFloat("Lowest Time", 999999.0f);
        if (actualTime > lowTime)
        {
            PlayerPrefs.SetFloat("Lowest Time", lowTime);
        }
    }

}
