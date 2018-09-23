using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public enum State
    {
        move,
        attack,
        dead
    };

    public State state = State.move;

    private bool dead;
    GameObject player;
    public float vertSpeed = 3;
    public float speed = 3;
    public GameObject groundPlane;
    public Animator anim;

	void Start () {
        player = PlayerController.instance.gameObject;
        anim = GetComponent<Animator>();
        state = State.move;
	}
	
	void Update () {
        if (dead) {return;}

        if (GetComponent<HealthController>().health <= 0)
        {
            state = State.dead;
        }

        switch (state)
        {
            case State.move:
                Move();
                break;
            case State.attack:
                Attack();
                break;
            case State.dead:
                Death();
                break;
        }     
	}

    void Move()
    {
        if (Vector3.Distance(player.transform.position, transform.position) < 2)
        {
            state = State.attack;
        }
        if (player.transform.position.z > transform.position.z + .2f)
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

    void Attack()
    {
        anim.SetTrigger("attack");

        if (Vector3.Distance(player.transform.position, transform.position) > 2)
        {
            state = State.move;
            anim.SetTrigger("end");
        }
    }

    void Death()
    {
        anim.SetTrigger("dead");
        dead = true;
    }
}
