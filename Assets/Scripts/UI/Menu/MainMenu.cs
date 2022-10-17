using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenuCanvas;
    public GameObject optionsMenuCanvas;

    public void NewGame()
    {
        SceneManager.LoadScene("GameSession");
    }

    public void Options()
    {
        mainMenuCanvas.SetActive(false);
        optionsMenuCanvas.SetActive(true);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
