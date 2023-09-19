using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Gameover : MonoBehaviour
{
    public Text actualScore, actualTime, bestScore, bestTime;
    //Sets UI Score.
    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        actualScore.text = "Score: " + PlayerPrefs.GetInt("Last Score");
        actualTime.text = "Time: " + PlayerPrefs.GetFloat("Last Time");
        bestScore.text = "Best: " + PlayerPrefs.GetInt("High Score");
        bestTime.text = "Best: " + PlayerPrefs.GetFloat("Low Time");
    }
    //Loads principal  scene.
    public void ReloadLevel()
        {
            SceneManager.LoadScene("Arena");
        }
    

    
}
