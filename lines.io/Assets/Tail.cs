using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
[RequireComponent(typeof(EdgeCollider2D))]
public class Tail : MonoBehaviour {

    public float pointSpacing = .1f;

    List<Vector2> points;
    public Transform snake;
    LineRenderer line;
    EdgeCollider2D col;
   

	// Use this for initialization
	void Start () {
        line = GetComponent<LineRenderer>();
        col = GetComponent<EdgeCollider2D>();

        points = new List<Vector2>();

        SetPoint();
	}
	
	// Update is called once per frame
	void Update () {

        if (Vector3.Distance(points.Last(), snake.position) > pointSpacing)
            SetPoint();

	}

    void SetPoint()
    {
        if (points.Count > 1)
            col.points = points.ToArray<Vector2>();

        points.Add(snake.position);

        line.numPositions = points.Count();
        line.SetPosition(points.Count() - 1, snake.position);


    }
}
