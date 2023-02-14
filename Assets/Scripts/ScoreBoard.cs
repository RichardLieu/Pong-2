using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreBoard : MonoBehaviour
{
    public TextMeshProUGUI leftPlayer;
    public TextMeshProUGUI rightPlayer;
    public TextMeshProUGUI gameEnd;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        leftPlayer.text = "Player1: " + GameManager.instance.leftPlayerScore;
        rightPlayer.text = "Player2: " + GameManager.instance.rightPlayerScore;
        if(GameManager.instance.hitLeft == true)
        {
            rightPlayer.color = new Color(Random.value, Random.value, Random.value, 1.0f);
            GameManager.instance.hitLeft = false;
        }
        else if(GameManager.instance.hitRight == true)
        {
            leftPlayer.color = new Color(Random.value, Random.value, Random.value, 1.0f);
            GameManager.instance.hitRight = false;
        }
        if(GameManager.instance.leftPlayerScore == 7)
        {
            gameEnd.text = "Player1 Wins!";
            gameEnd.color = new Color(Random.value, Random.value, Random.value, 1.0f);
        }
        else if(GameManager.instance.rightPlayerScore == 7)
        {
            gameEnd.text = "Player2 Wins!";
            gameEnd.color = new Color(Random.value, Random.value, Random.value, 1.0f);
        }
    }
}
