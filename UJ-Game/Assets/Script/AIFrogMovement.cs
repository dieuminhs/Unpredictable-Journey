using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIFrogMovement : MonoBehaviour
{
    private Animator animator;
    public Transform target;
    [SerializeField]
    private float speed = 0f;
    [SerializeField]
    private float maxRange = 0f;
    [SerializeField]
    private float minRange = 0f;
    public Transform homePos;
    //public bool moveRight;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        target = FindObjectOfType<PlayerMovement>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, target.position) <= maxRange 
            && Vector3.Distance(transform.position, target.position) >= minRange)
        {
            FollowPlayer();
        }
        else if (Vector3.Distance(transform.position, target.position) >= maxRange)
        {
            GoHome();
        }
    }

    void FollowPlayer()
    {
        animator.SetBool("isJumping", true);
        if (target.position.x > transform.position.x)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            transform.localScale = new Vector2(-1, 1);
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            transform.localScale = new Vector2(1, 1);
        }
    }

    public void GoHome()
    {
        if (homePos.position.x > transform.position.x)
        {
            transform.position = Vector2.MoveTowards(transform.position, homePos.position, speed * Time.deltaTime);
            transform.localScale = new Vector2(-1, 1);
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, homePos.position, speed * Time.deltaTime);
            transform.localScale = new Vector2(1, 1);
        }
        if (Vector3.Distance(transform.position, homePos.position) == 0)
        {
            animator.SetBool("isJumping", false);
        }
    }
}
