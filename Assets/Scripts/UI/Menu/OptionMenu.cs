using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OptionMenu : MonoBehaviour
{
    public GameObject mainMenuCanvas;
    public GameObject optionsMenuCanvas;
    public TMP_Text sessionTimeText;
    public TMP_Text spawnTimeText;
    public Button increaseSessionTime;
    public Button decreaseSessionTime;
    public Button increaseSpawnTime;
    public Button decreaseSpawnTime;

    private void Start()
    {
        if(SessionSettings.sessionTime == 180f)
        {
            sessionTimeText.text = "3 minutes";
        }
        if (SessionSettings.sessionTime == 60f)
        {
            sessionTimeText.text = "1 minute";
        }
        spawnTimeText.text = SessionSettings.spawnTime.ToString() + " seconds";
    }

    private void FixedUpdate()
    {
        if (SessionSettings.sessionTime == 180f)
        {
            increaseSessionTime.interactable = false;
            decreaseSessionTime.interactable = true;
        }
        if (SessionSettings.sessionTime == 60f)
        {
            increaseSessionTime.interactable = true;
            decreaseSessionTime.interactable = false;
        }

        if (SessionSettings.spawnTime == 60f)
        {
            increaseSpawnTime.interactable = false;
            decreaseSpawnTime.interactable = true;
        }
        else if (SessionSettings.spawnTime == 10f)
        {
            increaseSpawnTime.interactable = true;
            decreaseSpawnTime.interactable = false;
        }
        else
        {
            increaseSpawnTime.interactable = true;
            decreaseSpawnTime.interactable = true;
        }
    }

    public void IncreaseSessionTime()
    {
        SessionSettings.sessionTime = 180f;
        sessionTimeText.text = "3 minutes";
    }

    public void DecreaseSessionTime()
    {
        SessionSettings.sessionTime = 60f;
        sessionTimeText.text = "1 minute";
    }

    public void IncreaseSpawnTime()
    {
        if (SessionSettings.spawnTime >= 10f && SessionSettings.spawnTime < 60f)
        {
            SessionSettings.spawnTime += 10f;
        }
        spawnTimeText.text = SessionSettings.spawnTime.ToString() + " seconds";
    }

    public void DecreaseSpawnTime()
    {
        if (SessionSettings.spawnTime <= 60f && SessionSettings.spawnTime > 10f)
        {
            SessionSettings.spawnTime -= 10f;
        }
        spawnTimeText.text = SessionSettings.spawnTime.ToString() + " seconds";
    }

    public void MainMenu()
    {
        optionsMenuCanvas.SetActive(false);
        mainMenuCanvas.SetActive(true);
    }
}
