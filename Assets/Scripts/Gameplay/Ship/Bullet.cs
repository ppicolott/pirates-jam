using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public float coolDown;
    public float playerAttackDamage;
    public float shooterAttackDamage;

    private void Awake()
    {
        speed = 0.05f;
        coolDown = 0.5f;
        if (GameObject.Find("Player"))
        {
            playerAttackDamage = GameObject.Find("Player").GetComponent<Ship>().attackDamage;
        }
        if (GameObject.Find("Shooter"))
        {
            shooterAttackDamage = GameObject.Find("Shooter").GetComponent<Ship>().attackDamage;
        }
    }

    private void Update()
    {
        coolDown -= Time.deltaTime;
        if (coolDown <= 0)
        {
            Destroy(gameObject);
            coolDown = 0.5f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Contains("Grid"))
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.tag.Equals("Opponent"))
        {
            collision.gameObject.GetComponent<Ship>().health -= playerAttackDamage;
            if (collision.gameObject.GetComponent<Ship>().health <= 0)
            {
                Destroy(collision.gameObject);
            }
            Destroy(gameObject);
        }
        if (collision.gameObject.tag.Equals("Player"))
        {
            collision.gameObject.GetComponent<Ship>().health -= shooterAttackDamage;
            if (collision.gameObject.GetComponent<Ship>().health <= 0)
            {
                Destroy(collision.gameObject);
            }
            Destroy(gameObject);
        }
    }
}
