using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMeleeMovement : MonoBehaviour
{
    private Animator anim;
    [SerializeField]
    public float speed = 0f;
    private float fearTimeout = 2.0f;
    private bool feared;
    public Transform playerPos;
    [SerializeField]
    private float maxRange = 0f;
    [SerializeField]
    private float minRange = 0f;

    public Transform homePos;

    // Start is called before the first frame update
    void Start()
    {
        feared = false;
        anim = GetComponent<Animator>();
        playerPos = FindObjectOfType<PlayerMovement>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (feared)
        {
            if (fearTimeout > 0)
            {
                fearTimeout -= Time.deltaTime;
                FollowPlayer();
            }
            else
            {
                fearTimeout = 2.0f;
                feared = false;
                speed *= -1;
            }
        }
        else
        {
            if (Vector3.Distance(transform.position, playerPos.position) <= maxRange
                && Vector3.Distance(transform.position, playerPos.position) >= minRange)
            {
                FollowPlayer();
            }
            else if (Vector3.Distance(transform.position, playerPos.position) >= maxRange)
            {
                GoHome();
            }
            else if (Vector3.Distance(transform.position, playerPos.position) < minRange)
            {
                AttackPlayer();
            }
        }
    }

    private void AttackPlayer()
    {
        anim.SetBool("isAttack", true);
        anim.SetBool("isMoving", false);
        anim.SetFloat("attackX", playerPos.position.x - transform.position.x);
        anim.SetFloat("attackY", playerPos.position.y - transform.position.y);
    }

    void FollowPlayer()
    {
        anim.SetBool("isMoving", true);
        anim.SetBool("isAttack", false);
        anim.SetFloat("moveX", playerPos.position.x - transform.position.x);
        anim.SetFloat("moveY", playerPos.position.y - transform.position.y);
        transform.position = Vector2.MoveTowards(transform.position, playerPos.position, speed * Time.deltaTime);
    }

    public void GoHome()
    {

        anim.SetBool("isMoving", true);
        anim.SetFloat("moveX", homePos.position.x - transform.position.x);
        anim.SetFloat("moveY", homePos.position.y - transform.position.y);
        transform.position = Vector2.MoveTowards(transform.position, homePos.position, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, homePos.position) == 0)
        {
            anim.SetBool("isMoving", false);
        }
    }

    public void Fear()
    {
        Debug.Log("Oof");
        speed *= -1;
        feared = true;
    }
}
