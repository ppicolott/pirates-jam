using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Ship : MonoBehaviour
{
    private Animation shoot;
    private Animation death;
    private new Rigidbody2D rigidbody;
    private SpriteRenderer spriteRenderer;
    public Sprite fullHealth;
    public Sprite halfHealth;
    public Sprite lowHealth;
    public float speed;
    public float leftRotation;
    public float rightRotation;
    public float health;
    public float damage;
    public GameObject sideShot;
    public GameObject frontShot;

    public void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        speed = 0.15f;
        leftRotation = 4f;
        rightRotation = -4f;
        health = 100f;
        damage = 5f;
    }

    public void Update()
    {
        if (health > 75)
        {
            spriteRenderer.sprite = fullHealth;
        }
        if (health > 50)
        {
            spriteRenderer.sprite = halfHealth;
        }
        if (health > 25)
        {
            spriteRenderer.sprite = lowHealth;
        }
    }

    public void Move()
    {
        rigidbody.transform.Translate(0, speed, 0);
    }

    public void Rotate(float _rotation)
    {
        rigidbody.rotation += _rotation;
    }

    public void FrontalSingleShot()
    {

    }

    public void SideTripleShot(Vector2 _direction)
    {

    }
}
