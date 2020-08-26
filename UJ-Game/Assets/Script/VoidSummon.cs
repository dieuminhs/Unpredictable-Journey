using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoidSummon : MonoBehaviour
{
    public bool summoned = false;
    public GameObject meleeVoid;
    private Animator animator;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {

            if (!summoned)
            {
                summoned = true;
                GameObject melee = Instantiate(meleeVoid);

                float x = transform.position.x;
                float y = transform.position.y;
                melee.transform.position = new Vector3(x, y, 0);
                animator = melee.GetComponent<Animator>();
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            animator.SetBool("attack", false);
            animator.SetFloat("direction", -1.0f);
            summoned = false;
        }
    }
}







