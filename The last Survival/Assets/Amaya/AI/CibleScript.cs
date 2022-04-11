using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CibleScript : MonoBehaviour
{
    private int nbHealth = 100;
    void Update()
    {
        Debug.Log(nbHealth);

        if(nbHealth <= 0)
        {
            this.gameObject.SetActive(false);
            nbHealth = 0;
        }
    }

    public void Hit(int dmg)
    {
        nbHealth -= dmg;
    }
}
