using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public static PlayerController instance;

    public float initHealth;
    float _health;

    private void Awake()
    {
        _health = initHealth;
        if (instance == null) instance = this;

        DontDestroyOnLoad(this.gameObject);
    }
}
