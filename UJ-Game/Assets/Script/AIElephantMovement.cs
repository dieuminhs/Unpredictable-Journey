using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIElephantMovement : MonoBehaviour
{
    private Animator animator;
    public Transform roamingPosition;
    private float waitTime;
    [SerializeField]
    private float startWaitTime = 0f;
    [SerializeField]
    private float speed = 0f;
    [SerializeField]
    private float minX = 0f;
    [SerializeField]
    private float maxX = 0f;
    [SerializeField]
    private float minY = 0f;
    [SerializeField]
    private float maxY = 0f;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        roamingPosition.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
        waitTime = startWaitTime;
    }

    // Update is called once per frame
    void Update()
    {
        GoToRoamingPosition();
        if(Vector3.Distance(transform.position, roamingPosition.position) < 0.2f)
        {
            if(waitTime <= 0)
            {
                roamingPosition.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
                waitTime = startWaitTime;
            }
            else
            {
                animator.SetBool("isMoving", false);
                waitTime -= Time.deltaTime;
            }
            
        }
    }

    void GoToRoamingPosition()
    {
        animator.SetBool("isMoving", true);
        animator.SetFloat("moveX", roamingPosition.position.x - transform.position.x);
        animator.SetFloat("moveY", roamingPosition.position.y - transform.position.y);
        transform.position = Vector2.MoveTowards(transform.position, roamingPosition.position, speed * Time.deltaTime);
    }
}
