using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// A ball class
public class Ball : MonoBehaviour {

    private Timer deathTimer;
    private Timer startMoveTimer;
    private Timer speedUpTimer;

    private bool isSpeedUp = false;

    private void OnEnable() {
        EventManager.StartListening("SpeedUpEffectActivated", OnSpeedUp);
    }

    private void OnDisable() {
        EventManager.StopListening("SpeedUpEffectActivated", OnSpeedUp);
    }
    void Start () {

        //run and configure startMoveTimer
        startMoveTimer = gameObject.AddComponent<Timer>();
        startMoveTimer.Duration = 1f;
        startMoveTimer.Run();

        // run and configure deathTimer
        deathTimer = gameObject.AddComponent<Timer>();
        deathTimer.Duration = ConfigurationUtils.BallLifetime;
        deathTimer.Run();

        speedUpTimer = gameObject.AddComponent<Timer>();
    }

    private void Update() {
        // move when time is up
        if (startMoveTimer.Finished) {

            startMoveTimer.Stop();
            StartMoving();
        }

        // die when time is up
        if (deathTimer.Finished) {

            // spawn new ball and destroy self
            Camera.main.GetComponent<BallSpawner>().SpawnBall();
            Destroy(gameObject);
        }
    }

    // set ball direction and sped after collision
    public void SetDirection(Vector2 direction) {

        // get current rigidbody speed
        Rigidbody2D rb2d = GetComponent<Rigidbody2D>();
        float speed = rb2d.velocity.magnitude;
        rb2d.velocity = direction * speed;

    }

    void StartMoving() {

        // get the ball moving
        float angle = -90 * Mathf.Deg2Rad;
        Vector2 force = new Vector2(
            ConfigurationUtils.BallImpulseForce * Mathf.Cos(angle),
            ConfigurationUtils.BallImpulseForce * Mathf.Sin(angle));
        GetComponent<Rigidbody2D>().AddForce(force);
    }

    void OnSpeedUp(object arg0, object arg1) {

        speedUpTimer.Duration = (float)arg0;
        speedUpTimer.Run();
        isSpeedUp = true;
        GetComponent<Rigidbody2D>().velocity *= (float)arg1;
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

