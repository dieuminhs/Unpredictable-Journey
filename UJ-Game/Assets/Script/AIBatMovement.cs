using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBatMovement : MonoBehaviour
{
    private Animator batAnim;
    [SerializeField]
    private float speed = 0f;
    public Transform playerPos;
    [SerializeField]
    private float maxRange = 0f;
    [SerializeField]
    private float minRange = 0f;
    // Start is called before the first frame update
    void Start()
    {
        batAnim = GetComponent<Animator>();
        playerPos = FindObjectOfType<PlayerMovement>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(playerPos.position, transform.position) > 1.5f)
        {
            FollowPlayer();
        } else if(Vector2.Distance(playerPos.position, transform.position) <= 1.5f)
        {
            batAnim.SetBool("isFlying", false);
        }
        
    }

    private void FollowPlayer()
    {
        batAnim.SetBool("isFlying", true);
        batAnim.SetFloat("moveX", playerPos.position.x - transform.position.x);
        batAnim.SetFloat("moveY", playerPos.position.y - transform.position.y);
        transform.position = Vector2.MoveTowards(transform.position, playerPos.position, speed * Time.deltaTime);
    }
}
