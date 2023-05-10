using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreScript : MonoBehaviour
{
   public enum Score
    {
        P2Score, P1Score 
    }
    
    public TextMeshProUGUI P2Scoretxt, P1Scoretxt;

    public P2ManagerScript P2ManagerScript;

    public int MaxScore;

    #region Scores
    private int P2Score, P1Score;
    private int Player2Score
    {
        get { return P2Score; }
        set
        {
            P2Score = value;
            if (value == MaxScore)
                P2ManagerScript.ShowRestartCanvas(true);
           


        }
    }

    private int Player1Score
    {
        get { return P1Score; }
        set
        {
            P1Score = value;
            if (value == MaxScore)
                P2ManagerScript.ShowRestartCanvas(false);
        }
    }
    #endregion


    public void Increment(Score whichScore)
    {
        if (whichScore == Score.P2Score)
            P2Scoretxt.text = (++Player2Score).ToString();

        else
            P1Scoretxt.text = (++Player1Score).ToString();
    }

    public void ResetScore()
    {
        Player2Score = Player1Score = 0;
        P2Scoretxt.text = P1Scoretxt.text = "0";
    }

}

