using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoScript : MonoBehaviour
{
    public int nbAmmo = 100;
    void Update()
    {
        if (nbAmmo <= 0)
        {
            this.gameObject.SetActive(false);
            nbAmmo = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ammow") && nbAmmo <= 200)
        {
            nbAmmo = 200;
            GameObject.Destroy(other.gameObject);
        }
    }
}
