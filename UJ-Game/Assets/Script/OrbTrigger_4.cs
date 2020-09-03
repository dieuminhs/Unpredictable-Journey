using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbTrigger_4 : MonoBehaviour
{

    public Dialogue dialogue;
    private Rigidbody2D r2;
    private HealthManage healthManage;


    void Start()
    {
        healthManage = FindObjectOfType<HealthManage>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            healthManage.Restore();
            TriggerDialogue();
            Destroy(gameObject);
        }
    }

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}
