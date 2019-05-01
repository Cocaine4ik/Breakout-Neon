using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour {

    private static GameObject scoresText;
    private static GameObject ballsText;

    private static int scores;
    private static int balls;

    void Start() {

        balls = ConfigurationUtils.BallsPerGame;

        scoresText = GameObject.FindGameObjectWithTag("Score");
        ballsText = GameObject.FindGameObjectWithTag("Balls");
        ballsText.GetComponent<Text>().text = "Balls: " + balls;
    }
    // add points to scroe value
    public static void AddScore(int points) {

        scores += points;
        scoresText.GetComponent<Text>().text = "Score: " + scores.ToString();

    }
    // remove ball from balls per game
    public static void  RemoveBall() {
        balls = balls - 1;
        ballsText.GetComponent<Text>().text = "Balls: " + balls;
    }
}
