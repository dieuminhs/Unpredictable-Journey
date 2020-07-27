using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIFrogMovement : MonoBehaviour
{
    private Animator animator;
    public Transform roamingPosition;
    [SerializeField]
    private float speed = 0f;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        GoToRoamingPosition();
        Debug.Log(Vector3.Distance(transform.position, roamingPosition.position));  
        if (Vector3.Distance(transform.position, roamingPosition.position) < 0.85f)
        {
            animator.SetBool("isJumping", false);
        }
    }

    void GoToRoamingPosition()
    {
        animator.SetBool("isJumping", true);
        transform.position = Vector2.MoveTowards(transform.position, roamingPosition.position, speed * Time.deltaTime);
    }
}
