using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CibleScript : MonoBehaviour
{
    public int nbHealth = 10;
    private float timerinzone = 1;
    public bool outZone = false;

    void Update()
    {
        Debug.Log(nbHealth);

        if(nbHealth <= 0)
        {
            this.gameObject.SetActive(false);
            nbHealth = 0;
        }

        if (outZone == false)
        {
            Debug.Log("ntm");
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
        if (other.CompareTag("soin") && nbHealth <= 100)
        {
            nbHealth = 100;
            GameObject.Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "Zone")
        {
            outZone = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Zone")
        {
            outZone = true;
        }
    }
}
