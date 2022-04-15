using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnnemiesAlive : MonoBehaviour
{

    public GameObject[] EnnemiesAliveCount;
    public GameObject Player;
    public TextMeshProUGUI text;

    public bool win = false;
    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        EnnemiesAliveCount = GameObject.FindGameObjectsWithTag("User");
        text.text = EnnemiesAliveCount.Length.ToString();

       if (EnnemiesAliveCount.Length == 1)
        {
            win = true;
        }
    }
}
