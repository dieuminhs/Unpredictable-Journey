using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfusionEffect : MonoBehaviour
{
    private GameObject batAlly;
    // Start is called before the first frame update
    void Start()
    {
        batAlly = GameObject.Find("BatAlly(Clone)");
        transform.position = batAlly.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
