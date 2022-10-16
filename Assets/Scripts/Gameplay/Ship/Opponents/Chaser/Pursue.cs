using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEngine.GraphicsBuffer;

public class Pursue : MonoBehaviour
{
    public Ship ship;
    public Vector3 lookAtTarget;
    public float angle;
    public float rotationModifier;
    public Quaternion lookTo;
    public float lookSpeed;
    public float chaserAttackDamage;

    private void Start()
    {
        ship = transform.GetComponent<Ship>();
        ship.speed = 1f;
        rotationModifier = 90f;
        lookSpeed = 40f;
        if (GameObject.Find("Chaser"))
        {
            chaserAttackDamage = GameObject.Find("Chaser").GetComponent<Ship>().attackDamage;
        }
    }

    private void FixedUpdate()
    {
        if (VisionArea.pursuing)
        {
            Pursuit();
        }
    }

    private void Pursuit()
    {
        lookAtTarget = GameObject.Find("Player").transform.position - transform.position;
        angle = Mathf.Atan2(lookAtTarget.y, lookAtTarget.x) * Mathf.Rad2Deg - rotationModifier;
        lookTo = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookTo, Time.deltaTime * lookSpeed);

        transform.position = Vector2.MoveTowards(transform.position, GameObject.Find("Player").transform.position, ship.speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name + " - " + collision.gameObject.GetComponent<Ship>().health);
        if (collision.gameObject.tag.Equals("Player"))
        {
            collision.gameObject.GetComponent<Ship>().health -= chaserAttackDamage;
            if (collision.gameObject.GetComponent<Ship>().health <= 0)
            {
                Destroy(collision.gameObject);
            }
        }
    }
}
