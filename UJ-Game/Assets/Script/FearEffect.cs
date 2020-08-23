using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FearEffect : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Monster")
        {
            other.gameObject.GetComponent<AIMeleeMovement>().Fear();
        }
    }

}

