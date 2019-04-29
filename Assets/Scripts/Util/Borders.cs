using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Borders : MonoBehaviour {

    public List<Vector2> points = new List<Vector2>();
    private EdgeCollider2D ec;
    
	// Use this for initialization
	void Start () {

        ec = GetComponent<EdgeCollider2D>();

        points.Add(new Vector2(ScreenUtils.ScreenLeft, ScreenUtils.ScreenBottom));
        points.Add(new Vector2(ScreenUtils.ScreenLeft, ScreenUtils.ScreenTop));
        points.Add(new Vector2(ScreenUtils.ScreenRight, ScreenUtils.ScreenTop));
        points.Add(new Vector2(ScreenUtils.ScreenRight, ScreenUtils.ScreenBottom));

        ec.points = points.ToArray();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
