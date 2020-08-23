using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstUnityInstantiate : MonoBehaviour
{
    public GameObject go;
    // Start is called before the first frame update
    void Start()
    {
        GameObject tmpObj = Instantiate(go);
        tmpObj.transform.position = new Vector3(-11,6 , 0);
    }

}
