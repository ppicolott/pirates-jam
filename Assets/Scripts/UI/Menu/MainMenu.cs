using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private Button newGameButton;
    [SerializeField]
    private Button optionsButton;
    [SerializeField]
    private Button exitButton;
    [SerializeField]
    private GameObject mainMenuCanvas;
    [SerializeField]
    private GameObject optionsMenuCanvas;

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
