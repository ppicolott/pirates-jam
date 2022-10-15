using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public Ship ship;

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
}
