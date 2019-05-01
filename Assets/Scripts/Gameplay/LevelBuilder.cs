using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBuilder : MonoBehaviour {

    [SerializeField] GameObject paddlePrefab;

    [SerializeField] GameObject[] blockPrefabs = new GameObject[4];

    float rowsNumber = 3;
    
	void Start () {

        float outsetX = 1f;
        float outsetY = 4f;

        float startSpawnPointX = ScreenUtils.ScreenLeft + outsetX;
        float endSpawnPointX = ScreenUtils.ScreenRight - outsetX;

        float startSpawnPointY = ScreenUtils.ScreenTop - outsetY;

        // build rown with blocks
        for (float j = 0; j < rowsNumber; j++) {

            for (float i = startSpawnPointX; i < endSpawnPointX; i += outsetX) {

                Instantiate(blockPrefabs[Random.Range(0,4)], new Vector2(i, startSpawnPointY + j), Quaternion.identity);

            }
        }
        Instantiate(paddlePrefab);
	}
}
