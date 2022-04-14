using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;


public class EndgameUImanager : MonoBehaviour
{
    public GameObject Win;
    public GameObject Lose;
    public bool Winner; //show if the player ranked first or not !

    public TMP_Text placementRank;
    public TMP_Text placementTime;
    private float timeGame;
    private int Rank;

    private void Start()
    {
        
    }
    private void Update()
    {
        if(Rank == 1)
        {
            Winner = true;
        }
        else
        {
            Winner = false;
        }

        if(Winner == true)
        {
            Win.SetActive(true);
            Lose.SetActive(false);
            placementRank.text = Rank.ToString();
        }
        else
        {
            Win.SetActive(false);
            Lose.SetActive(true);
            placementTime.text = timeGame.ToString();
        }
    }
}
