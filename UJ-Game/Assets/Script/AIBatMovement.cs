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
    private GameObject player;

    private bool StayWithPlayer;
    private float width, height;
    private Rigidbody2D r1, r2;

    private float _x, _y;



    // Start is called before the first frame update
    void Start()
    {
        StayWithPlayer = true;
        r1 = GetComponent<Rigidbody2D>();
        batAnim = GetComponent<Animator>();
        playerPos = FindObjectOfType<PlayerMovement>().transform;

        player = GameObject.Find("MainCharacter");

        player.GetComponent<PlayerMovement>().CastAble();

        r2 = player.GetComponent<Rigidbody2D>();
        width = player.GetComponent<SpriteRenderer>().bounds.size.x / 2;
        height = player.GetComponent<SpriteRenderer>().bounds.size.y / 2;

        _x = Camera.main.gameObject.transform.position.x + Camera.main.orthographicSize * 5 / 2;
        _y = Camera.main.gameObject.transform.position.y + Camera.main.orthographicSize;
    }

    // Update is called once per frame
    void Update()
    {
        if (StayWithPlayer)
        {
            if (Vector2.Distance(playerPos.position, transform.position) > 1.5f)
            {
                FlyToPlayer();
            }
            else if (Vector2.Distance(playerPos.position, transform.position) <= 1.5f)
            {
                FollowPlayer();
            }
        }
        else FlyAway();
    }

    private void FlyToPlayer()
    {
        batAnim.SetBool("isFlying", true);
        batAnim.SetFloat("moveX", playerPos.position.x - transform.position.x);
        batAnim.SetFloat("moveY", playerPos.position.y - transform.position.y);

        transform.position = Vector2.MoveTowards(transform.position, playerPos.position, speed * Time.deltaTime);
    }

    private void FollowPlayer()
    {

        r1.velocity = r2.velocity;

        batAnim.SetFloat("moveX", r1.velocity.x);
        batAnim.SetFloat("moveY", r1.velocity.y);
    }

    public void FlyAway()
    {
        StayWithPlayer = false;
        batAnim.SetBool("isFlying", true);
        batAnim.SetFloat("moveX", _x - transform.position.x);
        batAnim.SetFloat("moveY", _y - transform.position.y);
        Vector2 awayPos = new Vector2(_x, _y);
        transform.position = Vector2.MoveTowards(transform.position, awayPos, speed * Time.deltaTime);

        if(Vector2.Distance(awayPos, transform.position)<=1)
        {
            Destroy(gameObject);
        }
    }
}