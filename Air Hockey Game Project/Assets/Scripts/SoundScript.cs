using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundScript : MonoBehaviour
{
    public AudioClip BallCollusion;
    public AudioClip Score;
    private AudioSource audioSource;
    public AudioClip LostGame;
    public AudioClip WinGame;
    

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
   public void PlayBallCollusion()
    {
        audioSource.PlayOneShot(BallCollusion);
       
    }  

    public void PlayScore()
    {
        audioSource.PlayOneShot(Score);
    }

    public void PlayLostGame()
    {
        audioSource.PlayOneShot(LostGame);
    }

    public void PlayWinGame()
    {
        audioSource.PlayOneShot(WinGame);
    }

}


