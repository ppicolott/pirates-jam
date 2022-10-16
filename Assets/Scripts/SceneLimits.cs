using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLimits : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name.Contains("Shot"))
        {
            Destroy(collision.gameObject);
        }
    }
}
