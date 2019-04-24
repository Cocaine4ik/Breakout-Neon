using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

    Rigidbody2D rb;
    BoxCollider2D bc;
    float halfColliderWidth = 0;
    float halfColliderHeight = 0;

    const float BounceAngleHalfRange = 180 * Mathf.Deg2Rad;
    // Use this for initialization
    void Start () {

        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();

        halfColliderWidth = bc.size.x / 2;
        halfColliderHeight = bc.size.y / 2;

    }

    private void FixedUpdate() {

       if (Input.GetAxis("Horizontal") != 0) {

            Vector3 position = new Vector3(transform.position.x + Input.GetAxis("Horizontal") *
                ConfigurationUtils.PaddleMoveUnitsPerSecond, transform.position.y);

            position.x = CalculateClampedX(position.x);

            rb.MovePosition(position);

        }
    }

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

        if (coll.gameObject.CompareTag("Ball") /*&& IsTopCollision(coll) == true*/) {
         
            // calculate new ball direction
            // Отступ от  центр весла до точки столкнвоения мяча
            float ballOffsetFromPaddleCenter = transform.position.x -
                coll.transform.position.x;
            float normalizedBallOffset = ballOffsetFromPaddleCenter /
                halfColliderWidth;
            float angleOffset = normalizedBallOffset * BounceAngleHalfRange;
            float angle = Mathf.PI / 2 + angleOffset;
            Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));

            Vector2 contact = coll.contacts[0].point;

            Debug.Log(contact);
            

            // tell ball to set direction to new direction
            Ball ballScript = coll.gameObject.GetComponent<Ball>();
            ballScript.SetDirection(direction);
        }
    }
    bool IsTopCollision(Collision2D coll) {

        if ((coll.contacts[0].point.y - coll.transform.position.y) / halfColliderHeight <= 0.05f ) {
            return true;
        } 
        else return false;
    }
}
