using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D r2;
    private Animator animator;
    [SerializeField]
    private float speed = 0.0f;
    private GameObject skillOne;
    // Start is called before the first frame update
    void Start()
    {
        skillOne = GameObject.Find("Fear");
        skillOne.SetActive(false);
        r2 = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("moveX", r2.velocity.x);
        animator.SetFloat("moveY", r2.velocity.y);

        if (Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 ||
            Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1)
        {
            animator.SetFloat("lastMoveX", Input.GetAxisRaw("Horizontal"));
            animator.SetFloat("lastMoveY", Input.GetAxisRaw("Vertical"));
        }
    }

    private void FixedUpdate()
    {
        r2.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized * speed * Time.deltaTime;
    }

    public void CastAble()
    {
        skillOne.SetActive(true);
    }

    public void Freeze()
    {
        speed = 0.0f;
    }

    public void Unfreeze()
    {
        speed = 200.0f;
    }
}
