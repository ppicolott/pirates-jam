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
        if (Keyboard.current.wKey.isPressed || Keyboard.current.upArrowKey.isPressed)
        {
            ship.Move();
        }
        if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed)
        {
            ship.Rotate(ship.rightRotation);
        }
        if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed)
        {
            ship.Rotate(ship.leftRotation);
        }
    }

    private void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame || Keyboard.current.numpad0Key.wasPressedThisFrame || Keyboard.current.digit0Key.wasPressedThisFrame || Keyboard.current.enterKey.wasPressedThisFrame)
        {
            ship.FrontalSingleShot();
        }
        if (Keyboard.current.eKey.wasPressedThisFrame || Keyboard.current.numpad1Key.wasPressedThisFrame || Keyboard.current.digit1Key.wasPressedThisFrame || Keyboard.current.leftCtrlKey.wasPressedThisFrame)
        {
            ship.RightSideTripleShot();
        }
        if (Keyboard.current.qKey.wasPressedThisFrame || Keyboard.current.numpad2Key.wasPressedThisFrame || Keyboard.current.digit2Key.wasPressedThisFrame || Keyboard.current.rightCtrlKey.wasPressedThisFrame)
        {
            ship.LeftSideTripleShot();
        }
    }
}
