using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    private Rigidbody2D rb;
    private float angle = 270 * Mathf.Deg2Rad;

    // Use this for initialization
    void Start () {

        rb = GetComponent<Rigidbody2D>();
         

        Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
        Debug.Log(direction);

        rb.AddForce(direction * ConfigurationUtils.BallImpulseForce * Time.deltaTime, ForceMode2D.Impulse);

        //rb.constraints = RigidbodyConstraints2D.FreezeRotation;

    }

    public void SetDirection(Vector2 ballDirection) {

        rb.velocity = ballDirection * ConfigurationUtils.BallImpulseForce * Time.deltaTime;
    }
}

