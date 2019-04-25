using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {


	// Use this for initialization
	void Start () {

    }

    private void OnCollisionEnter2D(Collision2D coll) {

        if(coll.gameObject.CompareTag("Ball")) {
            Destroy(gameObject);
            
        }
    }
}
