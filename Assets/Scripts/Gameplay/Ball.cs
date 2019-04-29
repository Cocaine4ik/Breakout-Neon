using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// A ball class
public class Ball : MonoBehaviour {

    private Rigidbody2D rb;

    private Timer deathTimer;
    private Timer startMoveTimer;

    private float angle = 270 * Mathf.Deg2Rad;

    void Start () {

        rb = GetComponent<Rigidbody2D>();

        // run and configure deathTimer
        deathTimer = gameObject.AddComponent<Timer>();
        deathTimer.Duration = ConfigurationUtils.BallLifetime;
        deathTimer.Run();

        //run and configure startMoveTimer
        startMoveTimer = gameObject.AddComponent<Timer>();
        startMoveTimer.Duration = 1f;
        startMoveTimer.Run();

    }

    // set ball direction and sped after collision
    public void SetDirection(Vector2 ballDirection) {

        rb.velocity = ballDirection * ConfigurationUtils.BallImpulseForce * Time.deltaTime;

    }
    private void Update() {
        // if startMoveTimer is finished add force to ball
        if (startMoveTimer.Finished) {

            Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
            rb.AddForce(direction * ConfigurationUtils.BallImpulseForce * Time.deltaTime, ForceMode2D.Impulse);
            startMoveTimer.Stop();
        }

        // if deathTimer is finished spwn new ball and destroy previous
        if (deathTimer.Finished) {         

            Camera.main.GetComponent<BallSpawner>().SpawnBall();
            Destroy(gameObject);
        }
    }

    private void OnBecameInvisible() {

        if (rb.position.y < ScreenUtils.ScreenBottom) {

            Camera.main.GetComponent<BallSpawner>().SpawnBall();
            Destroy(gameObject);

        }
    }
}

