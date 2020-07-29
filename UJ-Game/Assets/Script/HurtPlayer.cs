using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HurtPlayer : MonoBehaviour
{
    private float waitToHurt = 1f;
    private bool isTouching;
    private HealthManage healthManage;
    private bool reloading;
    private float waitToLoad = 2f;
    [SerializeField]
    private int damageToGive = 10;

    // Start is called before the first frame update
    void Start()
    {
        healthManage = FindObjectOfType<HealthManage>();
    }

    // Update is called once per frame
    void Update()
    {
        if (healthManage.currentHealth <= 0)
        {
            reloading = true;
        }
        if (reloading)
        {
            waitToLoad -= Time.deltaTime;
            if(waitToLoad <= 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }

        if (isTouching)
        {
            waitToHurt -= Time.deltaTime;
            if (waitToHurt <= 0)
            {
                healthManage.HurtPlayer(damageToGive);
                waitToHurt = 1f;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Player")
        {
            healthManage.HurtPlayer(damageToGive);
            
        }
        
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.collider.tag == "Player")
        {
            isTouching = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.collider.tag == "Player")
        {
            isTouching = false;
            waitToHurt = 1f;
        }
    }
}
