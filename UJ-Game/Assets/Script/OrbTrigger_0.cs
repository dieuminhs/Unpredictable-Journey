using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbTrigger_0 : MonoBehaviour
{

    public Dialogue dialogue;
    private Rigidbody2D r2;
    private GameObject gate;

    void Start()
    {
        gate = GameObject.Find("Portal");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            gate.SetActive(false);
            TriggerDialogue();
            Destroy(gameObject);

        }
    }

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}
