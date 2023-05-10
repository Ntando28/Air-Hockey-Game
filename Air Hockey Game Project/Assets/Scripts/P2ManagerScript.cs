using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class P2ManagerScript : MonoBehaviour
{
    [Header("Canvas")]
    public GameObject CanvaGame;
    public GameObject Restart;

    [Header("CanvasRestart")]
    public Text WinTxt;
    public Text LooseTxt;

    [Header("Other")]
    public SoundScript soundScript;

    public ScoreScript scoreScript;

    public BallScript ballScript;
    public PlayerMovement playerMovement;
    public PlayerScript1 playerScript;

    public void Start()
    {
        WinTxt.gameObject.SetActive(false);
        LooseTxt.gameObject.SetActive(false);

    }
    public void ShowRestartCanvas(bool DidBool2Win)
    {
        Time.timeScale = 0;

        CanvaGame.SetActive(false);
        Restart.SetActive(true);

        if (DidBool2Win)
        {
            Restart.SetActive(true);
            soundScript.PlayLostGame();
            WinTxt.gameObject.SetActive(false);
            LooseTxt.gameObject.SetActive(true);

        }
        else
        {
            soundScript.PlayWinGame();
            WinTxt.gameObject.SetActive(true);
            LooseTxt.gameObject.SetActive(false);

        }
    }
    public void GameRestart()
    {
        Time.timeScale = 1;

        CanvaGame.SetActive(true);
        Restart.SetActive(false);

        scoreScript.ResetScore();
        ballScript.CenterBall();
        playerMovement.ResetPosition();
        playerScript.ResetPosition();

    }
}

