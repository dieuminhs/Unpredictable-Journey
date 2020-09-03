using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Summon : MonoBehaviour
{
    public bool summoned = false;
    public GameObject go;
    private AIBatMovement batMovement;
    


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (!summoned)
            {

                summoned = true;
                GameObject tmpObj = Instantiate(go);
                float x = Camera.main.gameObject.transform.position.x + Camera.main.orthographicSize * 5 / 2;
                float y = Camera.main.gameObject.transform.position.y + Camera.main.orthographicSize;
                tmpObj.transform.position = new Vector3(x, y, 0);
                batMovement = tmpObj.GetComponent<AIBatMovement>();
            }
            else
            {
                summoned = false;
                batMovement.FlyAway();
            }
        }



    }
}
