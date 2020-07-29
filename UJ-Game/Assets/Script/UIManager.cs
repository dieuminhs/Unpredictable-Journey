using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private HealthManage healthManage;
    public Slider healthBar;
    public Text hpText;
    // Start is called before the first frame update
    void Start()
    {
        healthManage = FindObjectOfType<HealthManage>();
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.maxValue = healthManage.maxHealth;
        healthBar.value = healthManage.currentHealth;
        hpText.text = "HP: " + healthManage.currentHealth + "/" + healthManage.maxHealth;
    }
}
