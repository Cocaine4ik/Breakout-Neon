﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BallSpawner : MonoBehaviour {

    [SerializeField]GameObject prefabBall;

    // spawn support
    Vector2 spawnLocation = new Vector2(0, -1.5f);
    Timer spawnTimer;
    float spawnRange;

    // collision-free support
    bool retrySpawn = false;
    Vector2 spawnLocationMin;
    Vector2 spawnLocationMax;

    private bool stopSpawn = false;

    public bool StopSpawn {
        get { return stopSpawn; }
    }

    private void OnEnable() {
        EventManager.StartListening(EventName.SpawnBall, OnSpawnBall);
        EventManager.StartListening(EventName.TimerFinished, OnSpawnTimerFinished);
    }

    private void OnDisable() {
        EventManager.StopListening(EventName.SpawnBall, OnSpawnBall);
        EventManager.StopListening(EventName.TimerFinished, OnSpawnTimerFinished);
    }
    void Start() {
        // spawn and destroy ball to calculate
        // spawn location min and max
        GameObject tempBall = Instantiate<GameObject>(prefabBall);
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

        // initialize and start spawn timer
        spawnRange = ConfigurationUtils.MaxSpawnTime -
            ConfigurationUtils.MinSpawnTime;
        spawnTimer = gameObject.AddComponent<Timer>();

        spawnTimer.Duration = GetSpawnDelay();
        spawnTimer.Run();

        // spwan first ball in game
        SpawnBall();
    }

    void Update() {

        Debug.Log("GameType" + GameTypes.IsWacky);
        // spawn ball and restart timer as appropriate
        if (spawnTimer.Finished && GameTypes.IsWacky) {
            // don't stack with a spawn still pending
            retrySpawn = false;
            SpawnBall();
            spawnTimer.Duration = GetSpawnDelay();
            spawnTimer.Run();
        }

        // try again if spawn still pending
        if (retrySpawn && GameTypes.IsWacky) {
            SpawnBall();
        }
    }
    private void OnApplicationQuit() {
        stopSpawn = true;
    }

    public void OnSpawnTimerFinished(object timerName, object arg1) {
        Debug.Log(timerName);
    }

    // on SpawnBall Event
    public void OnSpawnBall(object arg0, object arg1) {

        SpawnBall();

    }
    /// Spawns a ball
    private void SpawnBall() {
        // make sure we don't spawn into a collision
        if (Physics2D.OverlapArea(spawnLocationMin, spawnLocationMax) == null && !stopSpawn) {
            retrySpawn = false;
            Instantiate(prefabBall);
        }
        else {
            retrySpawn = true;
        }
    }

    /// Gets the spawn delay in seconds for the next ball spawn
    float GetSpawnDelay() {
        return ConfigurationUtils.MinSpawnTime +
            Random.value * spawnRange;
    }
}
