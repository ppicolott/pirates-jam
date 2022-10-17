using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SessionEnding : MonoBehaviour
{
    public void PlayAgain()
    {
        SessionSettings.score = 0;
        SceneManager.LoadScene("GameSession");
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
