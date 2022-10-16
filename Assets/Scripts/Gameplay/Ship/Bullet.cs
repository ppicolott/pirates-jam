using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public float reachDistance;

    private void Awake()
    {
        speed = 0.05f;
        reachDistance = 0.5f;
    }

    private void Update()
    {
        reachDistance -= Time.deltaTime;
        if(reachDistance <= 0)
        {
            Destroy(gameObject);
            reachDistance = 0.5f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name.Contains("Grid"))
        {
            Destroy(gameObject);
        }
    }
}
