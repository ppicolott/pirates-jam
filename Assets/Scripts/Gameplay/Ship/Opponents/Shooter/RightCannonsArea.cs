using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightCannonsArea : MonoBehaviour
{
    public Ship ship;
    public bool attacking;

    private void Start()
    {
        ship = transform.parent.GetComponent<Ship>();
        attacking = false;
    }

    private void FixedUpdate()
    {
        if (attacking)
        {
            ship.RightSideTripleShot();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            attacking = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        attacking = false;
    }
}
