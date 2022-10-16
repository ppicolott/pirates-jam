using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public float reachDistance;
    public float damage;

    private void Awake()
    {
        speed = 0.05f;
        reachDistance = 0.5f;
        damage = Player.Instance.damage;
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
        if (collision.gameObject.tag.Equals("Opponent"))
        {
            collision.gameObject.GetComponent<Ship>().health -= damage;
            if (collision.gameObject.GetComponent<Ship>().health <= 0)
            {
                Destroy(collision.gameObject);
            }
            Destroy(gameObject);
        }
    }
}
