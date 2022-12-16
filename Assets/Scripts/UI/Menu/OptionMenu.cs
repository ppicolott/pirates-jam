using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OptionMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject mainMenuCanvas;
    [SerializeField]
    private GameObject optionsMenuCanvas;

    [SerializeField]
    private Button increaseSessionTime;
    [SerializeField]
    private Button decreaseSessionTime;
    [SerializeField]
    private Button increaseSpawnTime;
    [SerializeField]
    private Button decreaseSpawnTime;
    [SerializeField]
    private Button mainMenuButton;

    [SerializeField]
    private TMP_Text sessionTimeText;
    [SerializeField]
    private TMP_Text spawnTimeText;

    private void Awake()
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

        increaseSessionTime.onClick.AddListener(IncreaseSessionTime);
        decreaseSessionTime.onClick.AddListener(DecreaseSessionTime);
        increaseSpawnTime.onClick.AddListener(IncreaseSpawnTime);
        decreaseSpawnTime.onClick.AddListener(DecreaseSpawnTime);
        mainMenuButton.onClick.AddListener(MainMenu);
    }

    private void Update()
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
        switch (SessionSettings.spawnTime)
        {
            case 10f:
                SessionSettings.spawnTime = 20f;
                break;
            case 20f:
                SessionSettings.spawnTime = 30f;
                break;
            case 30f:
                SessionSettings.spawnTime = 40f;
                break;
            case 40f:
                SessionSettings.spawnTime = 50f;
                break;
            case 50f:
                SessionSettings.spawnTime = 60f;
                break;
        }
        spawnTimeText.text = SessionSettings.spawnTime.ToString() + " seconds";
    }

    public void DecreaseSpawnTime()
    {
        switch (SessionSettings.spawnTime)
        {
            case 60f:
                SessionSettings.spawnTime = 50f;
                break;
            case 50f:
                SessionSettings.spawnTime = 40f;
                break;
            case 40f:
                SessionSettings.spawnTime = 30f;
                break;
            case 30f:
                SessionSettings.spawnTime = 20f;
                break;
            case 20f:
                SessionSettings.spawnTime = 10f;
                break;
        }
        spawnTimeText.text = SessionSettings.spawnTime.ToString() + " seconds";
    }

    public void MainMenu()
    {
        optionsMenuCanvas.SetActive(false);
        mainMenuCanvas.SetActive(true);
    }
}
