using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour {

    public int health = 5;

    public int TakeDamage(int damage)
    {
        health -= damage;
        return health;
    }
}
