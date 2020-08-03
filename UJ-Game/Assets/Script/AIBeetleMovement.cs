using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBeetleMovement : MonoBehaviour
{
    private Animator beeAnim;
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
        beeAnim = GetComponent<Animator>();
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
        } else if(Vector3.Distance(transform.position, playerPos.position) < minRange)
        {
            AttackPlayer();
        }
    }

    private void AttackPlayer()
    {
        beeAnim.SetBool("isAttack", true);
        beeAnim.SetBool("isFlying", false);
        beeAnim.SetFloat("attackX", playerPos.position.x - transform.position.x);
        beeAnim.SetFloat("attackY", playerPos.position.y - transform.position.y);
    }

    void FollowPlayer()
    {
        beeAnim.SetBool("isFlying", true);
        beeAnim.SetBool("isAttack", false);
        beeAnim.SetFloat("moveX", playerPos.position.x - transform.position.x);
        beeAnim.SetFloat("moveY", playerPos.position.y - transform.position.y);
        transform.position = Vector2.MoveTowards(transform.position, playerPos.position, speed * Time.deltaTime);
    }

    public void GoHome()
    {
        beeAnim.SetBool("isFlying", true);
        beeAnim.SetFloat("moveX", homePos.position.x - transform.position.x);
        beeAnim.SetFloat("moveY", homePos.position.y - transform.position.y);
        transform.position = Vector2.MoveTowards(transform.position, homePos.position, speed * Time.deltaTime);
        if(Vector2.Distance(transform.position, homePos.position) == 0)
        {
            beeAnim.SetBool("isFlying", false);
        }
    }
}
