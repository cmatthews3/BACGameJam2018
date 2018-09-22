using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public static PlayerController instance;

    public float initHealth;
    float _health;

    public float speed = 3f;
    public float vertSpeed = 5f;

    public GameObject groundPlane;

    private void Awake()
    {
        _health = initHealth;
        if (instance == null) instance = this;

        DontDestroyOnLoad(this.gameObject);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += (groundPlane.transform.forward * vertSpeed) *Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += (-groundPlane.transform.forward * vertSpeed) * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += (groundPlane.transform.right * speed) * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += (-groundPlane.transform.right * speed) * Time.deltaTime;
        }

    }
}
