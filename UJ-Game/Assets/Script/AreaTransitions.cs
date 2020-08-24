using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AreaTransitions : MonoBehaviour
{
    public string sceneToLoad;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player" && !other.isTrigger)
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
