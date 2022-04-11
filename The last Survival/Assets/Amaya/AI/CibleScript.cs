using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CibleScript : MonoBehaviour
{
    public int nbHealth = 100;
    void Update()
    {

        if(nbHealth <= 0)
        {
            this.gameObject.SetActive(false);
            nbHealth = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("soin") && nbHealth <= 100)
        {
            nbHealth = 100;
            GameObject.Destroy(other.gameObject);
        }
    }

    public void Hit(int dmg)
    {
        nbHealth -= dmg;
    }
}
