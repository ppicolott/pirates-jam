using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisionArea : MonoBehaviour
{
    public static bool pursuing;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag.Equals("Player"))
        {
            pursuing = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        pursuing = false;
    }
}
