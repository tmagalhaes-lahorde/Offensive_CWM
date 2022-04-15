using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CibleScript : MonoBehaviour
{
    public int nbHealth = 100;
    private float timerinzone = 1;
    public bool outZone = false, outNextZone = true;

    void Update()
    {

        if(nbHealth <= 0)
        {
            this.gameObject.SetActive(false);
            nbHealth = 0;
        }

        if (outZone == true)
        {
            timerinzone -= Time.deltaTime;

            if (timerinzone <= 0)
            {
                nbHealth -= 1;
                timerinzone = 1;
            }
        }
    }

    public void Hit(int dmg)
    {
        nbHealth -= dmg;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("HealthKit") && nbHealth <= 100)
        {
            nbHealth = 100;
            other.enabled = false;
        }

        if (other.gameObject.tag == "NextZone")
        {
            outNextZone = false;
        }
        if (other.gameObject.tag =="Zone")
        {
            outZone = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "NextZone")
        {
            outNextZone = true;
        }

        if (other.gameObject.tag == "Zone")
        {
            outZone = true;
        }
    }
}
