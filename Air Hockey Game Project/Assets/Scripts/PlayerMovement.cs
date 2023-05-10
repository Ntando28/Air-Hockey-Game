using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    bool wasClicked = true;
    bool canMove;


    public Rigidbody2D rb;
    Vector2 startingPosition;
    public Transform BoarderHolder;
    Boarder playerBoarder;
    public Collider2D playerCollider;

    public string Boarder;

    // Start is called before the first frame update
    void Start()
    {
       
        rb = GetComponent<Rigidbody2D>();
        startingPosition = rb.position;
        playerCollider = GetComponent<Collider2D>();

        playerBoarder = new Boarder(BoarderHolder.GetChild(0).position.y, BoarderHolder.GetChild(1).position.y, BoarderHolder.GetChild(2).position.x, BoarderHolder.GetChild(3).position.x);
    }                               

    // Update is called once per frame
    void Update()
    {
        {
            if (Input.GetMouseButton(0))

            {
                Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                if (wasClicked)
                {
                    wasClicked = false;

                    if(playerCollider.OverlapPoint(mousePos))
                    {
                        canMove = true;
                    }

                    else
                    {
                        canMove = false;
                    }

                }

                if (canMove)
                {
                    Vector2 clampedMousePos = new Vector2(Mathf.Clamp(mousePos.x, playerBoarder.Left, playerBoarder.Right), Mathf.Clamp(mousePos.y, playerBoarder.Down, playerBoarder.Up));
                   
                    rb.MovePosition(clampedMousePos);
                }
            }
            else
            {
                wasClicked = true;
            }
        }

    }

    public void ResetPosition()
    {
        rb.position = startingPosition;
    }
}

    