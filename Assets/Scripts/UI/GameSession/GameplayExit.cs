using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameplayExit : MonoBehaviour
{
    public static GameplayExit Instance;
    public GameObject sessionEndingCanvas;
    public GameObject gameplayCanvas;

    private void FixedUpdate()
    {
        if(Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            XButton();
        }
    }

    public void XButton()
    {
        sessionEndingCanvas.SetActive(true);
        gameplayCanvas.SetActive(false);
    }
}
