using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class EndComponent : MonoBehaviour
{
    public GameObject Joueur_Restants;
    public GameObject Player;
    public GameObject GameTime;

    public EventSystem M_EventSystem;

    public Image WinBG;

    public Text Win;
    public Text Lose;
    public Text Title;

    public Text Score;
    public Text Rank;

    public GameObject MenuBTN;

    public bool Winning, Lost;
    private void Start()
    {
        MenuBTN.gameObject.SetActive(false);
        WinBG.gameObject.SetActive(false);
        Win.gameObject.SetActive(false);
        Lose.gameObject.SetActive(false);
        Title.gameObject.SetActive(false);
        Score.gameObject.SetActive(false);
        Rank.gameObject.SetActive(false);

        Lost = false;
    }

    private void Update()
    {

        //Kills.text = Player.GetComponent<PlayerScript>().nbkills.ToString();
        Rank.text = "You ranked : " + Joueur_Restants.GetComponent<EnnemiesAlive>().EnnemiesAliveCount.Length.ToString();
        Score.text = "Your game lasted : " + GameTime.GetComponent<TimerScript>().time.ToString() + "s";

        if (Joueur_Restants.GetComponent<EnnemiesAlive>().win)
        {
            ActiveEnd();
            M_EventSystem.SetSelectedGameObject(MenuBTN);
            Win.gameObject.SetActive(true);
            Time.timeScale = 0f;

            //Time.timeScale = 0f;
        }

        if(Player.GetComponent<PVScript>().lose)
        {
            ActiveEnd();
            M_EventSystem.SetSelectedGameObject(MenuBTN);
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

        MenuBTN.SetActive(true);

    }
}
