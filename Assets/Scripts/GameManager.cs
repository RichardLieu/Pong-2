using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform ball;
    public Transform leftPaddle;
    public Transform rightPaddle;
    public float startSpeed = 3f;
    public GoalTrigger leftGoalTrigger;
    public GoalTrigger rightGoalTrigger;
    public bool hitLeft = false;
    public bool hitRight = false;

    public int leftPlayerScore = 0;
    public int rightPlayerScore = 0;
    private Vector3 ballStartPos;

    private const int scoreToWin = 7;

    public static GameManager instance;

    public float enlargementAmount = 1.5f;
    public float duration = 5.0f;

    private Vector3 originalScale;

    // Start is called before the first frame update
    void Start()
    {
        ballStartPos = ball.position;
        Rigidbody ballBody = ball.GetComponent<Rigidbody>();
        ballBody.velocity = new Vector3(1f, 0f, 0f) * startSpeed;
    }

    // If the ball entered the goal area, increment the score, check for win, and reset the ball
    public void OnGoalTrigger(GoalTrigger trigger)
    {
        if (trigger == leftGoalTrigger)
        {
            rightPlayerScore++;
            hitLeft = true;
            Debug.Log($"Right player scored: {rightPlayerScore}");
            if (rightPlayerScore == scoreToWin)
            {
                Debug.Log("Right player wins!");
            }
            else
            {
                ResetBall(-1f);
            }
        }
        else if (trigger == rightGoalTrigger)
        {

            leftPlayerScore++;
            hitRight = true;
            Debug.Log($"Left player scored: {leftPlayerScore}");
            if (leftPlayerScore == scoreToWin)
            {
                Debug.Log("Right player wins!");
            }
            else
            {
                ResetBall(1f);
            }
        }
    }

    void ResetBall(float directionSign)
    {
        ball.position = ballStartPos;

        // Start the ball within 20 degrees off-center toward direction indicated by directionSign
        directionSign = Mathf.Sign(directionSign);
        Vector3 newDirection = new Vector3(directionSign, 0f, 0f) * startSpeed;
        newDirection = Quaternion.Euler(0f, Random.Range(-20f, 20f), 0f) * newDirection;

        var rbody = ball.GetComponent<Rigidbody>();
        rbody.velocity = newDirection;
        rbody.angularVelocity = new Vector3();

        // We are warping the ball to a new location, start the trail over
        ball.GetComponent<TrailRenderer>().Clear();
    }

    public void OnLBiggerPaddle(LBiggerPaddle other)
    {
        if(other.gameObject.CompareTag("LBiggerPaddle"))
        {
            other.gameObject.SetActive(false);
            leftPaddle.localScale *= enlargementAmount;
            Invoke("LResetPaddleSize", duration);
        }
    }

    private void LResetPaddleSize()
    {
        leftPaddle.localScale = rightPaddle.localScale;
    }

    public void OnRBiggerPaddle(RBiggerPaddle other)
    {
        if(other.gameObject.CompareTag("RBiggerPaddle"))
        {
            other.gameObject.SetActive(false);
            rightPaddle.localScale *= enlargementAmount;
            Invoke("RResetPaddleSize", duration);
        }
    }

    private void RResetPaddleSize()
    {
        rightPaddle.localScale = leftPaddle.localScale;
    }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }
    }
}
