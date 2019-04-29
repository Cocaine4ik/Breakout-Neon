using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour {

    [SerializeField] GameObject ballPrefab;

    // spawn ball
    public void SpawnBall() {
        Instantiate(ballPrefab);
    }
}
