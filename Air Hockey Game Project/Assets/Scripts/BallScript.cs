using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public ScoreScript ScorescriptInstance;
    public static bool WasScore{ get; private set; }
    public float MaxSpeed;
    private Rigidbody2D rb;

    public SoundScript soundScript;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        WasScore = false;

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
   
        if (!WasScore)
        {
            if (other.tag == "P2Goal")
            {
                ScorescriptInstance.Increment(ScoreScript.Score.P1Score);
                WasScore = true;
                soundScript.PlayScore();
                StartCoroutine(ResetBall(false));
                


            }
            else if (other.tag == "P1Goal")
            {
                ScorescriptInstance.Increment(ScoreScript.Score.P2Score);
                WasScore = true;
                soundScript.PlayScore();
                StartCoroutine(ResetBall(true));
            }
               
        }    

    }

    private void OnCollisionEnter2D(Collision2D border)
    {
        if (border.gameObject.tag == "border")
        {
            soundScript.PlayBallCollusion();
        }
    }
    private IEnumerator ResetBall(bool didP2Score)
    {
        yield return new WaitForSecondsRealtime(1);
        WasScore = false;
        rb.velocity = rb.position = new Vector2(0, 0);

        if (didP2Score)
            rb.position = new Vector2(0, -1);
        else
            rb.position = new Vector2(0, 1); //this code makes the balls move after scoring to normal position
        
    }

    public void CenterBall()
    {
        rb.position = new Vector2(0, 0);
    }

    private void FixedUpdate()
    {
        rb.velocity = Vector2.ClampMagnitude(rb.velocity, MaxSpeed);
    }
    
    
} 

