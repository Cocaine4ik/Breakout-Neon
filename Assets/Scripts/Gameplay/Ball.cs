using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// A ball class
public class Ball : MonoBehaviour {

    #region Fields

    private Timer deathTimer;
    private Timer startMoveTimer;

    Vector2 direction;
    float originalSpeed;
    Rigidbody2D rb2d;

    #endregion

    #region Methods

    private void OnEnable() {
        EventManager.StartListening(EventName.SpeedUpEffectActivated, OnSpeedUp);
        EventManager.StartListening(EventName.TimerFinished, OnDeathTimerFinished);
    }

    private void OnDisable() {
        EventManager.StopListening(EventName.SpeedUpEffectActivated, OnSpeedUp);
        EventManager.StopListening(EventName.TimerFinished, OnDeathTimerFinished);
    }
    void Start () {

        rb2d = GetComponent<Rigidbody2D>();

        // set the initial values
        float angle = -90 * Mathf.Deg2Rad;
        direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
        originalSpeed = ConfigurationUtils.BallImpulseForce;

        // run and configure startMoveTimer
        startMoveTimer = gameObject.AddComponent<Timer>();
        startMoveTimer.SetTimerName("StartMoveTimer");
        startMoveTimer.Duration = 1f;
        startMoveTimer.Run();

        // run and configure deathTimer
        deathTimer = gameObject.AddComponent<Timer>();
        deathTimer.SetTimerName(".DeathTimer");
        deathTimer.Duration = ConfigurationUtils.BallLifetime;
        deathTimer.Run();


    }
    private void Update() {

        if(startMoveTimer.Finished) {
            // move when time is up
            startMoveTimer.Stop();
            StartMoving();
        }
    }
    // set ball direction and sped after collision
    public void SetDirection(Vector2 direction) {

        // get current rigidbody speed
        this.direction = direction;
        StartMoving();

    }
    
    void StartMoving(float speedFactor = 1) {

        // NEW Reset ball velocity in case of any changes
        rb2d.velocity = Vector3.zero;

        // NEW Set the speed of the ball depending on speed up effect 
        float actualSpeed = (EffectUtils.SpeedUp ? originalSpeed * speedFactor : originalSpeed);

        // NEW Get the ball moving
        rb2d.AddForce(direction * actualSpeed);
    }

    void OnSpeedUp(object effectDuration, object speedFactor) {

        if(EffectUtils.SpeedUp) {
            StartMoving((float)speedFactor);
        }
    }
    private void OnBecameInvisible() {

        // death timer destruction is in Update
        if (!deathTimer.Finished) {
            // only spawn a new ball if below screen
            float halfColliderHeight = gameObject.GetComponent<BoxCollider2D>().size.y / 2;
            if (transform.position.y - halfColliderHeight < ScreenUtils.ScreenBottom) {

                EventManager.TriggerEvent(EventName.SpawnBall);

                EventManager.TriggerEvent(EventName.ReduceBallsLeft);
            }
            Destroy(gameObject);
        }
    }

    #endregion

    #region Events

    public void OnDeathTimerFinished(object timerName, object arg1) {

        if (timerName != null) {

            string thisTimerName = timerName.ToString();

                    if (thisTimerName.Equals("DeathTimer") && GameMode.IsWacky) {

                        // spawn new ball and destroy self
                        EventManager.TriggerEvent(EventName.SpawnBall);
                        Destroy(gameObject);

                    }
        }
    }

    #endregion
}

