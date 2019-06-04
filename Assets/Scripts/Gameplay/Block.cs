using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

    protected int points;

    protected virtual void OnCollisionEnter2D(Collision2D coll) {

        if(coll.gameObject.CompareTag("Ball")) {

            Destroy(gameObject);
            EventManager.TriggerEvent(EventName.AddScore, points);
        }
    }
}
