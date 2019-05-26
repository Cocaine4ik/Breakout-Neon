using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// A ball class
public class Ball : MonoBehaviour {

    private Timer deathTimer;
    private Timer startMoveTimer;

    Vector2 direction;
    float originalSpeed;
    Rigidbody2D rb2d;

    private void OnEnable() {
        EventManager.StartListening("SpeedUpEffectActivated", OnSpeedUp);
    }

    private void OnDisable() {
        EventManager.StopListening("SpeedUpEffectActivated", OnSpeedUp);
    }
    void Start () {

        rb2d = GetComponent<Rigidbody2D>();

        // set the initial values
        float angle = -90 * Mathf.Deg2Rad;
        direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
        originalSpeed = ConfigurationUtils.BallImpulseForce;

        // run and configure startMoveTimer
        startMoveTimer = gameObject.AddComponent<Timer>();
        startMoveTimer.Duration = 1f;
        startMoveTimer.Run();

        // run and configure deathTimer
        deathTimer = gameObject.AddComponent<Timer>();
        deathTimer.Duration = ConfigurationUtils.BallLifetime;
        deathTimer.Run();


    }

    private void Update() {
        // move when time is up
        if (startMoveTimer.Finished) {

            startMoveTimer.Stop();
            StartMoving();
        }

        // die when time is up
        if (deathTimer.Finished && GameTypes.IsWacky) {

            // spawn new ball and destroy self
            Camera.main.GetComponent<BallSpawner>().SpawnBall();
            Destroy(gameObject);
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

    void OnSpeedUp(object arg0, object arg1) {

        if(EffectUtils.SpeedUp) {
            StartMoving((float)arg1);
        }
    }
    private void OnBecameInvisible() {

        // death timer destruction is in Update
        if (!deathTimer.Finished) {
            // only spawn a new ball if below screen
            float halfColliderHeight = gameObject.GetComponent<BoxCollider2D>().size.y / 2;
            if (transform.position.y - halfColliderHeight < ScreenUtils.ScreenBottom) {
                Camera.main.GetComponent<BallSpawner>().SpawnBall();
                HUD.RemoveBall();
            }
            Destroy(gameObject);
        }
    }
}

