using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PVScript : MonoBehaviour
{

    public float CurrentHealth = 100.0f;
    public float Maxhealth = 100.0f;
    private float timerInZone = 1;

    public AudioSource healthSource;
    public AudioClip healthClip;

    public bool outZone = false;
    public bool lose = false;
    public Image HealthBarImage;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI text;
    public Image color;
    public RawImage inStormEffect;

    public int medikit = 0;
    

    private void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        if (CurrentHealth <= 0)
        {
            lose = true;
        }

        HealthBarImage.fillAmount = CurrentHealth / Maxhealth;
        healthText.text = CurrentHealth + " / " + Maxhealth;

        //if (CurrentHealth >= 70)
        //{
        //    color.color = Color.green;
        //}
        //
        //if (CurrentHealth <= 70)
        //{
        //    color.color = Color.yellow;
        //}
        //
        //if (CurrentHealth <= 30)
        //{
        //    color.color = Color.red;
        //}
        //
        //if (CurrentHealth >= 100)
        //{
        //    CurrentHealth = 100;
        //}
        //
        //if (Input.GetKeyDown(KeyCode.K) || Input.GetButton("UseHeal") && medikit >= 1 && CurrentHealth != 100) 
        //{
        //    CurrentHealth = 100;
        //    medikit = 0;
        //    //text.text = "0";
        //}

        if(outZone == true)
        {
            inStormEffect.enabled = true;
        
            timerInZone -= Time.deltaTime;

            if(timerInZone <= 0)
            {
                CurrentHealth -= 1;
        
                timerInZone = 1;
        
            }
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("soin") && medikit <= 0) 
        {
            text.text = "1";
            healthSource.PlayOneShot(healthClip);
            medikit = 1;
            other.enabled = false;
        }

        if (other.gameObject.tag == "Zone")
        {
            inStormEffect.enabled = false;
            outZone = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Zone")
        {
            inStormEffect.enabled = true;
            outZone = true;
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
