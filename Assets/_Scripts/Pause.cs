using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    public GameObject pauseMenu;
    public Button exitButton;

    private void Awake()
    {
        pauseMenu.SetActive(false);
        exitButton.onClick.AddListener(ExitGame);
    }
    //Activates pause menu and hides the mouse cursor.
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
        }
    }
    //Resumes pause menu and shows the mouse cursor.
    public void ResumeGame()
    {
        pauseMenu?.SetActive(false);
        Time.timeScale = 1;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    //Exits game.
    public void ExitGame()
    {
        print("Ejecuccion Finalizada");
       // UnityEditor.EditorApplication.isPlaying = false;
    }

}
