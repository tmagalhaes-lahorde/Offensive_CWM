using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndComponent : MonoBehaviour
{
    public Image WinBG;

    public Text Win;
    public Text Lose;
    public Text Title;

    public Text Score;
    public Text Rank;
    public Text Kills;

    public bool Winning, Lost;
    private void Start()
    {
        WinBG.gameObject.SetActive(false);
        Win.gameObject.SetActive(false);
        Lose.gameObject.SetActive(false);
        Title.gameObject.SetActive(false);
        Score.gameObject.SetActive(false);
        Rank.gameObject.SetActive(false);
        Kills.gameObject.SetActive(false);

        Winning = false;
        Lost = false;
    }

    private void Update()
    {

        Kills.text = GetComponent<PlayerScript>().nbKills.ToString() + "kills";
        Rank.text = GetComponent<EnnemiesAlive>().EnnemiesAliveCount.Length.ToString();
        Score.text = GetComponent<TimerScript>().time.ToString();

        if(Winning)
        {
            ActiveEnd();
            Win.gameObject.SetActive(true);

            Time.timeScale = 0f;
        }

        if(Lost)
        {
            ActiveEnd();
            Lose.gameObject.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void ActiveEnd()
    {
        Title.gameObject.SetActive(true);
        WinBG.gameObject.SetActive(true);
        Score.gameObject.SetActive(true);
        Rank.gameObject.SetActive(true);
        Kills.gameObject.SetActive(true);
    }
}
