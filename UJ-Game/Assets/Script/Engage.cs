using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Engage : MonoBehaviour
{
    private Animator animator;
    public GameObject attackEffect;

    // Update is called once per frame
    void Start()
    {
        animator = GetComponent<Animator>();
    }

     public void AlertAppear(string message)
    {
        if (message.Equals("AppearAnimationEnded"))
        {
            if (animator.GetFloat("direction") > 0)
            {
                animator.SetBool("attack", true);

                GameObject attack = Instantiate(attackEffect);
                float x = transform.position.x;
                float y = transform.position.y;
                attack.transform.position = new Vector3(x, y, 0);
            }

        }
    }

    public void AlertDisappear(string message)
    {

        if (message.Equals("DisappearAnimationEnded"))
        {
            if (animator.GetFloat("direction") <0)
            {
                Destroy(gameObject);
            }
        }
    }

    public void AlertAttack(string message)
    {
        if(message.Equals("AttackStartOver"))
        {

            GameObject attack = Instantiate(attackEffect);
            float x = transform.position.x;
            float y = transform.position.y;
            attack.transform.position = new Vector3(x, y, 0);
        }
    }
}
