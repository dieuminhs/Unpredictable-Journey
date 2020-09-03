using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbTrigger_3 : MonoBehaviour
{

    public Dialogue dialogue;
    private Rigidbody2D r2;



    void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {

            TriggerDialogue();
            Destroy(gameObject);
        }
    }

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}
