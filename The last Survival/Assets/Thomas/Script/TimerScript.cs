using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class TimerScript : MonoBehaviour
{

    public int time;
    public float timeInterval = 5f;
    float tick;

    float Timer = 0;
    public TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;
        time = (int)Timer;
        text.text = time.ToString();
    }
}
