using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMantisMovement : MonoBehaviour
{
    private Animator mantisAnim;
    [SerializeField]
    private float speed = 0f;
    public Transform playerPos;
    [SerializeField]
    private float maxRange = 0f;
    [SerializeField]
    private float minRange = 0f;
    public Transform homePos;
    // Start is called before the first frame update
    void Start()
    {
        mantisAnim = GetComponent<Animator>();
        playerPos = FindObjectOfType<PlayerMovement>().transform;
    }

    // Update is called once per frame
    void Update()
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

    private void AttackPlayer()
    {
        mantisAnim.SetBool("isAttack", true);
        mantisAnim.SetBool("isMoving", false);
        mantisAnim.SetFloat("attackX", playerPos.position.x - transform.position.x);
        mantisAnim.SetFloat("attackY", playerPos.position.y - transform.position.y);
    }

    void FollowPlayer()
    {
        mantisAnim.SetBool("isMoving", true);
        mantisAnim.SetBool("isAttack", false);
        mantisAnim.SetFloat("moveX", playerPos.position.x - transform.position.x);
        mantisAnim.SetFloat("moveY", playerPos.position.y - transform.position.y);
        transform.position = Vector2.MoveTowards(transform.position, playerPos.position, speed * Time.deltaTime);
    }

    public void GoHome()
    {
        mantisAnim.SetBool("isMoving", true);
        mantisAnim.SetFloat("moveX", homePos.position.x - transform.position.x);
        mantisAnim.SetFloat("moveY", homePos.position.y - transform.position.y);
        transform.position = Vector2.MoveTowards(transform.position, homePos.position, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, homePos.position) == 0)
        {
            mantisAnim.SetBool("isMoving", false);
        }
    }
}
