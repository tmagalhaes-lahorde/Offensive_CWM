using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PVScript : MonoBehaviour
{

    public float CurrentHealth = 50.0f;
    public float Maxhealth = 100.0f;

    public Image HealthBarImage;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI text;
    public Image color;

    public bool activeptain = false; 
    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HealthBarImage.fillAmount = CurrentHealth / Maxhealth;
        healthText.text = CurrentHealth + " / " + Maxhealth;

        if (CurrentHealth >= 70)
        {
            color.color = Color.green;
        }

        if (CurrentHealth <= 70)
        {
            color.color = Color.yellow;
        }

        if (CurrentHealth <= 30)
        {
            color.color = Color.red;
        }

        if (CurrentHealth >= 100)
        {
            CurrentHealth = 100;
        }


        if (Input.GetKeyDown(KeyCode.K) && activeptain == true)
        {
            CurrentHealth = 100;
            text.text = "0";
        }
    }

    public void DamageButton(int damage)
    {
        CurrentHealth -= damage;
    }
    public void HealthButton(int Health)
    {
        CurrentHealth += Health;
    }
}
