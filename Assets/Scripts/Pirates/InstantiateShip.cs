using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class InstantiateShip : MonoBehaviour
{
    private float health, speed, leftRotation, rightRotation;
    private Sprite sprite;
    private GameObject sideShotPrefab;
    private GameObject frontShotPrefab;
    private AudioSource canonSFX;

    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rigidbody;

    [SerializeField]
    private GameObject healthBar, centerCannon, leftCannons, rightCannons;

    public PirateShip pirateShip;

    private void Awake()
    {
        health = pirateShip.health;
        speed = pirateShip.speed;
        leftRotation = pirateShip.leftRotation;
        rightRotation = pirateShip.rightRotation;
        sprite = pirateShip.sprite;
        sideShotPrefab = pirateShip.sideShotPrefab;
        frontShotPrefab = pirateShip.frontShotPrefab;
        canonSFX = GameObject.Find("CanonSFX").GetComponent<AudioSource>();

        spriteRenderer = transform.Find("Rigidbody").GetComponentInChildren<SpriteRenderer>();
        spriteRenderer.sprite = pirateShip.sprite;
        rigidbody = GetComponentInChildren<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (GameObject.Find("PlayerShip"))
        {
            if (Keyboard.current.wKey.isPressed || Keyboard.current.upArrowKey.isPressed)
            {
                Move();
            }
            if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed)
            {
                Rotate(rightRotation);
            }
            if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed)
            {
                Rotate(leftRotation);
            }
            if (Keyboard.current.spaceKey.isPressed || Keyboard.current.numpad0Key.isPressed || Keyboard.current.digit0Key.isPressed || Keyboard.current.enterKey.isPressed)
            {
                FrontalSingleShot();
            }
            if (Keyboard.current.eKey.isPressed || Keyboard.current.numpad1Key.isPressed || Keyboard.current.digit1Key.isPressed || Keyboard.current.leftCtrlKey.isPressed)
            {
                RightSideTripleShot();
            }
            if (Keyboard.current.qKey.isPressed || Keyboard.current.numpad2Key.isPressed || Keyboard.current.digit2Key.isPressed || Keyboard.current.rightCtrlKey.isPressed)
            {
                LeftSideTripleShot();
            }
        }
    }

    public void Move()
    {
        rigidbody.transform.Translate(0, speed, 0);
        healthBar.transform.position = new Vector3(rigidbody.transform.position.x - 0.9f, rigidbody.transform.position.y + 1.25f, 0);
    }

    public void Rotate(float _rotation)
    {
        rigidbody.rotation += _rotation;
    }

    public void FrontalSingleShot()
    {
        if (!GameObject.Find("FrontalSingleShot(Clone)"))
        {
            GameObject _frontShot = Instantiate(frontShotPrefab, centerCannon.transform);
            _frontShot.GetComponent<Rigidbody2D>().AddForce(centerCannon.transform.up * _frontShot.GetComponent<Bullet>().speed, ForceMode2D.Force);
            canonSFX.Play();
        }
    }

    public void RightSideTripleShot()
    {
        if (!GameObject.Find("SideTripleShot(Clone)"))
        {
            GameObject _rightSideShot = Instantiate(sideShotPrefab, rightCannons.transform);
            _rightSideShot.GetComponent<Rigidbody2D>().AddForce(rightCannons.transform.up * _rightSideShot.GetComponent<Bullet>().speed, ForceMode2D.Force);
            canonSFX.Play();
        }
    }

    public void LeftSideTripleShot()
    {
        if (!GameObject.Find("SideTripleShot(Clone)"))
        {
            GameObject _leftSideShot = Instantiate(sideShotPrefab, leftCannons.transform);
            _leftSideShot.GetComponent<Rigidbody2D>().AddForce(leftCannons.transform.up * _leftSideShot.GetComponent<Bullet>().speed, ForceMode2D.Force);
            canonSFX.Play();
        }
    }
}
