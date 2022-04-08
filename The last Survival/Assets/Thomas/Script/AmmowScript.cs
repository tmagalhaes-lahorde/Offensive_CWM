using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AmmowScript : MonoBehaviour
{

    public int Currentammow = 50;
    public int Maxammow = 200;

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
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ammow") && Currentammow != 200)
        {
            Currentammow += 200;
            text.text = Currentammow + " / " + Maxammow;
            GameObject.Destroy(other.gameObject);
        }
    }
}