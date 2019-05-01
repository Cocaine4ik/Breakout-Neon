using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallSpawner : MonoBehaviour {

    [SerializeField] GameObject ballPrefab;

    Timer spawnTimer;

    Vector2 spawnLocationMin;
    Vector2 spawnLocationMax;

    private void Start() {

        // init and run spawn timer
        spawnTimer = gameObject.AddComponent<Timer>();
        spawnTimer.Duration = Random.Range(ConfigurationUtils.MinSpawnTime, ConfigurationUtils.MaxSpawnTime);
        spawnTimer.Run();

        GameObject tempBall = Instantiate<GameObject>(ballPrefab);
        BoxCollider2D collider = tempBall.GetComponent<BoxCollider2D>();
        float ballColliderHalfWidth = collider.size.x / 2;
        float ballColliderHalfHeight = collider.size.y / 2;
        spawnLocationMin = new Vector2(
            tempBall.transform.position.x - ballColliderHalfWidth,
            tempBall.transform.position.y - ballColliderHalfHeight);
        spawnLocationMax = new Vector2(
            tempBall.transform.position.x + ballColliderHalfWidth,
            tempBall.transform.position.y + ballColliderHalfHeight);
        Destroy(tempBall);

    }

    private void Update() {
        if(spawnTimer.Finished) {

            spawnTimer.Run();
            SpawnBall();
        }
    }

    private void OnEnable() {

        Instantiate(ballPrefab);
    }

    // spawn ball
    public void SpawnBall() {

            if (Physics2D.OverlapArea(spawnLocationMin, spawnLocationMax) == null) {

                Instantiate(ballPrefab);
            }
    }
}
