using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    GameObject player;
    public float vertSpeed = 3;
    public float speed = 3;
    public GameObject groundPlane;

	void Start () {
        player = PlayerController.instance.gameObject;
	}
	
	void Update () {
        if (Vector3.Distance(player.transform.position, transform.position) < .3f)
        {
            //enemy attack
        }
        else if (player.transform.position.z > transform.position.z + .2f)
        {
            transform.position += (groundPlane.transform.forward * vertSpeed) * Time.deltaTime;
        }
        else if (player.transform.position.z < transform.position.z - .2f)
        {
            transform.position += (-groundPlane.transform.forward * vertSpeed) * Time.deltaTime;
        }
        else if (player.transform.position.x > transform.position.x)
        {
            transform.position += (groundPlane.transform.right * speed) * Time.deltaTime;
        }
        else
        {
            transform.position += (-groundPlane.transform.right * speed) * Time.deltaTime;
        }

	}
}
