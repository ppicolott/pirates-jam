using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Pirate Ship", menuName = "Ship")]
public class PirateShip : ScriptableObject
{
    public float health;
    public float speed;
    public float leftRotation;
    public float rightRotation;
    public Sprite sprite;
    public GameObject sideShotPrefab;
    public GameObject frontShotPrefab;
}
