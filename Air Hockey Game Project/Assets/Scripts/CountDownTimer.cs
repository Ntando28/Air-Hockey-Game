using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDownTimer : MonoBehaviour
{
    float currentTime = 0f;
    float startingTime = 5f;
    public P2ManagerScript manager;

    public GameObject ball;


    [SerializeField] Text CountDownText;

    private void Start()
    {
        currentTime = startingTime;
        ball.SetActive(false);
    }

    private void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        CountDownText.text = currentTime.ToString("0");

        if (currentTime <= 0)
        {
            currentTime = 0;
            CountDownText.text = "";
            ball.SetActive(true);
           // manager.Restart.SetActive(false);
        }
        else
        {
          //  manager.Restart.SetActive(true);
        }
    }
}
