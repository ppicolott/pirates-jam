using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private Button newGameButton, optionsButton, exitButton;
    [SerializeField]
    private GameObject mainMenuCanvas, optionsMenuCanvas;

    private void Awake()
    {
        newGameButton.onClick.AddListener(NewGame);
        optionsButton.onClick.AddListener(OptionsScreen);
        exitButton.onClick.AddListener(ExitGame);
    }

    private void NewGame()
    {
        SceneManager.LoadScene("GameSession");
    }

    private void OptionsScreen()
    {
        mainMenuCanvas.SetActive(false);
        optionsMenuCanvas.SetActive(true);
    }

    private void ExitGame()
    {
        Application.Quit();
    }
}
