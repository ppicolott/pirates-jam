using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SessionStatus : MonoBehaviour
{
    private float chaserSpawnTimer;
    private float shooterSpawnTimer;
    public static SessionStatus Instance;
    public int score = 0;
    public float opponentSpawnTime = 10f;
    public TMP_Text scoreText;
    public TMP_Text opponentSpawnTimeText;
    public GameObject chaserPrefab;
    public GameObject shooterPrefab;

    private void Start()
    {
        Instance = this;
        scoreText.text = "Score: " + score;
        opponentSpawnTimeText.text = "Opponent Spawn Time: " + opponentSpawnTime + " s";
        chaserSpawnTimer = opponentSpawnTime;
        shooterSpawnTimer = opponentSpawnTime;
    }

    private void FixedUpdate()
    {
        scoreText.text = "Score: " + score;

        if (!GameObject.Find("Chaser"))
        {
            if (SessionStatus.Instance.chaserSpawnTimer > 0)
            {
                chaserSpawnTimer -= Time.deltaTime;
            }
            if (SessionStatus.Instance.chaserSpawnTimer <= 0)
            {
                if (!GameObject.Find("Chaser(Clone)"))
                {
                    Instantiate(chaserPrefab, new Vector3(-5.94f, -4.87f, 0), Quaternion.identity);
                    chaserSpawnTimer = opponentSpawnTime;
                }
            }
        }

        if (!GameObject.Find("Shooter"))
        {
            if (SessionStatus.Instance.shooterSpawnTimer > 0)
            {
                shooterSpawnTimer -= Time.deltaTime;
            }
            if (SessionStatus.Instance.shooterSpawnTimer <= 0)
            {
                if (!GameObject.Find("Shooter(Clone)"))
                {
                    Instantiate(shooterPrefab, new Vector3(5.29f, 4.31f, 0), new Quaternion(0, 0, 180f, 0));
                    shooterSpawnTimer = opponentSpawnTime;
                }
            
            }
        }
    }
}
