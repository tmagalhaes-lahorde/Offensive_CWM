using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AmmowScript : MonoBehaviour
{

    public int Currentammow = 200;
    public int Maxammow = 200;

    public AudioSource ammoSource;
    public AudioClip ammoClip;

    public TextMeshProUGUI text;

    private void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        text.text = Currentammow + " / " + Maxammow;

        if (Currentammow >= 200)
        {
            Currentammow = 200;
        }

        if (Currentammow <= 0)
        {
            Currentammow = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ammow") && Currentammow <= 200)
        {
            Debug.Log("Ammow");
            //ammoSource.PlayOneShot(ammoClip);
            Currentammow += 200;
            text.text = Currentammow + " / " + Maxammow;
            other.gameObject.SetActive(false);
        }
    }
}