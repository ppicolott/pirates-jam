using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pursue : MonoBehaviour
{
    private Vector3 lookAtTarget;
    private float angle;
    private Quaternion lookTo;
    public Ship ship;
    public float rotationModifier;
    public float lookSpeed;
    public float chaserAttackDamage;

    private void Start()
    {
        ship = transform.GetComponent<Ship>();
        ship.speed = 1f;
        rotationModifier = 90f;
        lookSpeed = 40f;
        ship.attackDamage = 30f;
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
        if (collision.gameObject.tag.Equals("Player"))
        {
            if (collision.gameObject.GetComponent<Ship>().health > 0)
            {
                collision.gameObject.GetComponent<Ship>().health -= ship.attackDamage;
                collision.gameObject.GetComponent<Ship>().debrisFX.Play();
                ship.explosionFX.SetActive(true);
                collision.gameObject.GetComponent<Ship>().shootExplosionFX.SetActive(true);
            }
            if (collision.gameObject.GetComponent<Ship>().health > 30 && collision.gameObject.GetComponent<Ship>().health <= 60)
            {
                collision.gameObject.GetComponent<Ship>().health -= ship.attackDamage;
                collision.gameObject.GetComponent<Ship>().debrisFX.Play();
                ship.explosionFX.SetActive(true);
                collision.gameObject.GetComponent<Ship>().yellowFlamesFX.SetActive(true);
                collision.gameObject.GetComponent<Ship>().orangeFlamesFX.SetActive(true);
                collision.gameObject.GetComponent<Ship>().shootExplosionFX.SetActive(true);
            }
            if (collision.gameObject.GetComponent<Ship>().health <= 0)
            {
                collision.gameObject.GetComponent<Ship>().debrisFX.Play();
                ship.explosionFX.SetActive(true);
                collision.gameObject.GetComponent<Ship>().explosionFX.SetActive(true);
            }
        }
    }
}
