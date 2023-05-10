using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript1 : MonoBehaviour
{
    public float MaxMoveSpeed;

    private Rigidbody2D rb;
    private Vector2 startingPosition;
    
    public Rigidbody2D Ball;

    public Transform PlayerBoarderHolder;
    private Boarder PlayerBoarder;

    public Transform BallBoarderHolder;
    private Boarder BallBoarder;

    private Vector2 targetPosition;

    private bool isFirstTimeInOpponentHalf = true;
    private float offsetXFromTarget;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startingPosition = rb.position;

        PlayerBoarder = new Boarder(PlayerBoarderHolder.GetChild(0).position.y, PlayerBoarderHolder.GetChild(1).position.y, PlayerBoarderHolder.GetChild(2).position.x, PlayerBoarderHolder.GetChild(3).position.x);

        BallBoarder = new Boarder(BallBoarderHolder.GetChild(0).position.y, BallBoarderHolder.GetChild(1).position.y, BallBoarderHolder.GetChild(2).position.x, BallBoarderHolder.GetChild(3).position.x);

    }

   
    private void FixedUpdate()
    {
        if (!BallScript.WasScore)
        {

        }
        float movementSpeed;

        if (Ball.position.y < BallBoarder.Down)
        {
            if (isFirstTimeInOpponentHalf)
            {
                isFirstTimeInOpponentHalf = false;
                offsetXFromTarget = Random.Range(-1f, 1f);

            }
            movementSpeed = MaxMoveSpeed = Random.Range(5.5f, 5.5f);
            targetPosition = new Vector2(Mathf.Clamp(Ball.position.x + offsetXFromTarget, PlayerBoarder.Left, PlayerBoarder.Right),
                startingPosition.y);

        }
        else
        {

            isFirstTimeInOpponentHalf = true;

            movementSpeed = Random.Range(MaxMoveSpeed * 0.4f, MaxMoveSpeed);
            targetPosition = new Vector2(Mathf.Clamp(Ball.position.x,  PlayerBoarder.Left, PlayerBoarder.Right),
                Mathf.Clamp(Ball.position.y, PlayerBoarder.Down, PlayerBoarder.Up));


        }

        rb.MovePosition(Vector2.MoveTowards(rb.position, targetPosition, movementSpeed * Time.fixedDeltaTime));
    }

    public void ResetPosition()
    {
        rb.position = startingPosition;
    }

}



