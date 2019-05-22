using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour {

    [SerializeField] public GameObject frostEffect;

    private static GameObject scoresText;
    private static GameObject ballsText;

    private static int scores;
    private static int balls;

    private void OnEnable() {
        EventManager.StartListening("FreezeEffectActivated", OnFreezeEffect);
        EventManager.StartListening("FreezeEffectDeactivated", OffFreezeEffect);
    }

    private void OnDisable() {
        EventManager.StopListening("FreezeEffectActivated", OnFreezeEffect);
        EventManager.StopListening("FreezeEffectDeactivated", OffFreezeEffect);
    }

    private void Awake() {

        frostEffect.gameObject.SetActive(false);

    }
    void Start() {

        balls = ConfigurationUtils.BallsPerGame;

        scoresText = GameObject.FindGameObjectWithTag("Score");
        ballsText = GameObject.FindGameObjectWithTag("Balls");
        ballsText.GetComponent<Text>().text = "Balls: " + balls;
    }

    void OnFreezeEffect(object arg0, object arg1) {
        frostEffect.gameObject.SetActive(true);
    }

    void OffFreezeEffect(object arg0, object arg1) {
        frostEffect.gameObject.SetActive(false);
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
