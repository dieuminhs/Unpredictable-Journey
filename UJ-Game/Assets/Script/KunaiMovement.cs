using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KunaiMovement : MonoBehaviour
{
    private Rigidbody2D r2;
    public float timeOn = 1.0f,timeOut = 0.0f;
    public float speed = 0f;

    // Start is called before the first frame update
    void Start()
    {
        r2 = GetComponent<Rigidbody2D>();
        r2.velocity = new Vector2(0, 0);
    }

    // Update is called once per frame
    void Update()
    {

        if (timeOn > 0)
        {
            timeOn -= Time.deltaTime;
        }
        else if (timeOut > 0)
        {
            r2.velocity = new Vector2(0, speed * Time.deltaTime);
            timeOut -= Time.deltaTime;
        }
        else Destroy(gameObject);
        
    }
}
