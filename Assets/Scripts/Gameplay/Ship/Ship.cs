using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    private new Rigidbody2D rigidbody;
    private SpriteRenderer spriteRenderer;

    [Space(10)]
    [Header("Structure")]
    [Space(5)]
    public float health;
    public float speed;
    public float leftRotation;
    public float rightRotation;
    [Space(10)]
    [Header("Damage")]
    [Space(5)]
    [Header("Attack Power")]
    [Space(5)]
    public float attackDamage;
    public float attackCoolDown;
    public GameObject sideShotPrefab;
    public GameObject frontShotPrefab;
    [Space(5)]
    [Header("UI")]
    [Space(5)]
    public GameObject lifeBar;
    public Sprite fullHealth;
    public Sprite halfHealth;
    public Sprite lowHealth;
    [Space(5)]
    [Header("VFX - Particles and Animation")]
    [Space(5)]
    public GameObject shootExplosionFX;
    public GameObject explosionFX;
    public GameObject yellowFlamesFX;
    public GameObject orangeFlamesFX;
    public ParticleSystem debrisFX;

    public void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        speed = 0.15f;
        leftRotation = 4f;
        rightRotation = -4f;
        health = 90f;
        attackDamage = 10f;
        attackCoolDown = 2f;
        debrisFX.Stop();
    }

    public void FixedUpdate()
    {
        lifeBar.transform.localScale = new Vector3(health/100, 0.5f, 0);

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
        if (GameObject.Find("Player") && !GameObject.Find("FrontalSingleShot(Clone)"))
        {
            GameObject _frontShot = Instantiate(frontShotPrefab, transform.Find("CenterCannon").position, transform.rotation);
            _frontShot.GetComponent<Rigidbody2D>().AddForce(transform.Find("CenterCannon").up * _frontShot.GetComponent<Bullet>().speed, ForceMode2D.Force);
        }
    }

    public void RightSideTripleShot()
    {
        if (GameObject.Find("Player") && !GameObject.Find("SideTripleShot(Clone)"))
        {
            GameObject _rightSideShot = Instantiate(sideShotPrefab, transform.Find("RightCannons").position, transform.rotation);
            _rightSideShot.GetComponent<Rigidbody2D>().AddForce(transform.Find("RightCannons").up * _rightSideShot.GetComponent<Bullet>().speed, ForceMode2D.Force);
        }
    }

    public void LeftSideTripleShot()
    {
        if (GameObject.Find("Player") && !GameObject.Find("SideTripleShot(Clone)"))
        {
            GameObject _leftSideShot = Instantiate(sideShotPrefab, transform.Find("LeftCannons").position, transform.rotation);
            _leftSideShot.GetComponent<Rigidbody2D>().AddForce(transform.Find("LeftCannons").up * _leftSideShot.GetComponent<Bullet>().speed, ForceMode2D.Force);
        }
    }
}
