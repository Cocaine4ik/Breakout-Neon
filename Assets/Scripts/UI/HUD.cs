using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour {

    [SerializeField] public GameObject frostEffect;
    [SerializeField] public GameObject speedUpEffect;

    private static GameObject scoresText;
    private static GameObject ballsText;

    private static int scores;
    private static int balls;

    private void OnEnable() {
        EventManager.StartListening(EventName.FreezeEffectActivated, OnFreezeEffect);
        EventManager.StartListening(EventName.FreezeEffectDeactivated, OffFreezeEffect);
        EventManager.StartListening(EventName.AddScore, OnAddScore);
        EventManager.StopListening(EventName.ReduceBallsLeft, OnReduceBallsLeft);
    }

    private void OnDisable() {
        EventManager.StopListening(EventName.FreezeEffectActivated, OnFreezeEffect);
        EventManager.StopListening(EventName.FreezeEffectDeactivated, OffFreezeEffect);
        EventManager.StopListening(EventName.AddScore, OnAddScore);
        EventManager.StopListening(EventName.ReduceBallsLeft, OnReduceBallsLeft);
    }

    private void Awake() {

        frostEffect.gameObject.SetActive(false);
        speedUpEffect.gameObject.SetActive(false);

    }
    void Start() {

        balls = ConfigurationUtils.BallsPerGame;

        scoresText = GameObject.FindGameObjectWithTag("Score");
        ballsText = GameObject.FindGameObjectWithTag("Balls");
        ballsText.GetComponent<Text>().text = "Balls: " + balls;
    }

    private void Update() {
        
        if(balls <= 0) {

            EventManager.TriggerEvent(EventName.GameOver);

        }

    }
    void OnFreezeEffect(object arg0, object arg1) {
        frostEffect.gameObject.SetActive(true);
    }

    void OffFreezeEffect(object arg0, object arg1) {
        frostEffect.gameObject.SetActive(false);
    }

    // add points to scroe value
    void OnAddScore(object points, object arg1) {

        scores += (int)points;
        scoresText.GetComponent<Text>().text = "Score: " + scores.ToString();

    }
    // remove ball from balls per game
    void OnReduceBallsLeft(object arg0, object arg1) {
        balls = balls - 1;
        ballsText.GetComponent<Text>().text = "Balls: " + balls;
    }
}
