using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

    Rigidbody2D rb;
    BoxCollider2D bc;

    Timer freezeTimer;

    float halfColliderWidth = 0;
    float halfColliderHeight = 0;


    bool isFrozen = false;

    const float BounceAngleHalfRange = 60 * Mathf.Deg2Rad;

    private void OnEnable() {
        EventManager.StartListening(EventName.FreezeEffectActivated, OnFreezePaddle);
    }
    private void OnDisable() {
        EventManager.StopListening(EventName.FreezeEffectDeactivated, OnFreezePaddle);
    }
    void Start () {

        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();

        halfColliderWidth = bc.size.x / 2;
        halfColliderHeight = bc.size.y / 2;

        freezeTimer = gameObject.AddComponent<Timer>();

    }
    private void Update() {

        if (freezeTimer.Finished) {

            isFrozen = false;

            EventManager.TriggerEvent(EventName.FreezeEffectDeactivated);
        }
    }
    private void FixedUpdate() {

        if(!isFrozen) {
            if (Input.GetAxis("Horizontal") != 0) {

                Vector2 position = rb.position;

                position.x += Input.GetAxis("Horizontal") *
                ConfigurationUtils.PaddleMoveUnitsPerSecond * Time.deltaTime;

                position.x = CalculateClampedX(position.x);

                rb.MovePosition(position);

            }
        }

    }
    
    // clampe paddle in to screen
    float CalculateClampedX(float positionX) {

        if (positionX  <= ScreenUtils.ScreenLeft + halfColliderWidth) {

            return positionX + halfColliderWidth;
        }
        else if (positionX >= ScreenUtils.ScreenRight - halfColliderWidth) {

            return positionX - halfColliderWidth;
        }

        return positionX;
    }

    void OnCollisionEnter2D(Collision2D coll) {

        if (coll.gameObject.CompareTag("Ball")) {
         
            // calculate new ball direction
            float ballOffsetFromPaddleCenter = transform.position.x -
                coll.transform.position.x;
            float normalizedBallOffset = ballOffsetFromPaddleCenter /
                halfColliderWidth;
            float angleOffset = normalizedBallOffset * BounceAngleHalfRange;
            float angle = Mathf.PI / 2 + angleOffset;
            Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));

            // tell ball to set direction to new direction
            Ball ballScript = coll.gameObject.GetComponent<Ball>();
            ballScript.SetDirection(direction);
        }
    }

     void OnFreezePaddle(object effectDuration, object arg1){

        freezeTimer.Duration = (float)effectDuration;
        freezeTimer.Run();
        isFrozen = true;

    } 
}
