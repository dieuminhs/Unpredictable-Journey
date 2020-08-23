using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastSkill : MonoBehaviour
{
    private float delay1 = 0.3f;
    private float delay2 = 0.3f;
    private float delay3 = 0.3f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {

            if (delay1 > 0) // Skill cooldown
            {
                delay1 -= Time.deltaTime;
            }
            else // Cast skill 
            {

            }
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            if (delay2 > 0) // Skill cooldown
            {
                delay2 -= Time.deltaTime;
            }
            else // Cast skill 
            {

            }
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            if (delay3 > 0) // Skill cooldown
            {
                delay3 -= Time.deltaTime;
            }
            else // Cast skill 
            {

            }
        }
    }
}
