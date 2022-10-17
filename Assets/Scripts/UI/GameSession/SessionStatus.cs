using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SessionStatus : MonoBehaviour
{
    private float sessionTimer;
    private float chaserSpawnTimer;
    private float shooterSpawnTimer;

    public GameObject sessionEndingCanvas;
    public GameObject gameplayCanvas;

    public TMP_Text scoreText;
    public TMP_Text opponentSpawnTimeText;

    public GameObject chaserPrefab;
    public GameObject shooterPrefab;

    private void Start()
    {
        sessionTimer = SessionSettings.sessionTime;
        scoreText.text = "Score: " + SessionSettings.score;
        opponentSpawnTimeText.text = "Opponent Spawn Time: " + SessionSettings.spawnTime + " s";

        chaserSpawnTimer = SessionSettings.spawnTime;
        shooterSpawnTimer = SessionSettings.spawnTime;
    }

    private void FixedUpdate()
    {
        scoreText.text = "Score: " + SessionSettings.score;

        if(sessionTimer > 0)
        {
            sessionTimer -= Time.deltaTime;
        }
        if(sessionTimer <= 0)
        {
            sessionEndingCanvas.SetActive(true);
            gameplayCanvas.SetActive(false);
        }

        if (!GameObject.Find("Chaser"))
        {
            if (chaserSpawnTimer > 0)
            {
                chaserSpawnTimer -= Time.deltaTime;
            }
            if (chaserSpawnTimer <= 0)
            {
                if (!GameObject.Find("Chaser(Clone)"))
                {
                    Instantiate(chaserPrefab, new Vector3(-5.94f, -4.87f, 0), Quaternion.identity);
                    chaserSpawnTimer = SessionSettings.spawnTime;
                }
            }
        }

        if (!GameObject.Find("Shooter"))
        {
            if (shooterSpawnTimer > 0)
            {
                shooterSpawnTimer -= Time.deltaTime;
            }
            if (shooterSpawnTimer <= 0)
            {
                if (!GameObject.Find("Shooter(Clone)"))
                {
                    Instantiate(shooterPrefab, new Vector3(5.29f, 4.31f, 0), new Quaternion(0, 0, 180f, 0));
                    shooterSpawnTimer = SessionSettings.spawnTime;
                }
            }
        }
    }
}
