using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class TimerScript : MonoBehaviour
{

    //private float time;
    //public float timeInterval = 5f;
    //float tick;

    float Timer = 0;
    public TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //text.text = time.ToString();
        //time = (int)Time.time;
        Timer += Time.deltaTime;
        int time = (int)Timer;
        text.text = time.ToString();
    }
}
