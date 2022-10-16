using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public Ship ship;
    public float damage;

    private void Start()
    {
        ship = GetComponent<Ship>();
    }

    private void FixedUpdate()
    {
        if (Keyboard.current.wKey.isPressed)
        {
            ship.Move();
        }
        if (Keyboard.current.dKey.isPressed)
        {
            ship.Rotate(ship.rightRotation);
        }
        if (Keyboard.current.aKey.isPressed)
        {
            ship.Rotate(ship.leftRotation);
        }
    }

    private void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            ship.FrontalSingleShot();
        }
        if (Keyboard.current.qKey.wasPressedThisFrame)
        {
            ship.RightSideTripleShot();
        }
        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            ship.LeftSideTripleShot();
        }
    }
}
