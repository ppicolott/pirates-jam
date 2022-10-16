using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public GameObject sideShotPrefab;
    public GameObject frontShotPrefab;

    public void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        speed = 0.15f;
        leftRotation = 4f;
        rightRotation = -4f;
        health = 90f;
    }

    public void Update()
    {
        if (health > 60)
        {
            spriteRenderer.sprite = fullHealth;
        }
        if (health > 30 && health <= 60)
        {
            spriteRenderer.sprite = halfHealth;
        }
        if (health <= 30 && health > 0)
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
        GameObject _frontShot = Instantiate(frontShotPrefab, transform.Find("CenterCannon").position, transform.rotation);
        _frontShot.GetComponent<Rigidbody2D>().AddForce(transform.Find("CenterCannon").up * _frontShot.GetComponent<Bullet>().speed, ForceMode2D.Force);
    }

    public void RightSideTripleShot()
    {
        GameObject _rightSideShot = Instantiate(sideShotPrefab, transform.Find("RightCannons").position, transform.rotation);
        _rightSideShot.GetComponent<Rigidbody2D>().AddForce(transform.Find("RightCannons").up * _rightSideShot.GetComponent<Bullet>().speed, ForceMode2D.Force);
    }

    public void LeftSideTripleShot()
    {
        GameObject _leftSideShot = Instantiate(sideShotPrefab, transform.Find("LeftCannons").position, transform.rotation);
        _leftSideShot.GetComponent<Rigidbody2D>().AddForce(transform.Find("LeftCannons").up * _leftSideShot.GetComponent<Bullet>().speed, ForceMode2D.Force);
    }
}
