using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMoveScript : MonoBehaviour {

    public int speed = 10;
    public bool startMove = false;
    public bool startPlan = false;
    public CharacterController controller;

    public List<Vector3> dest;
    public int curIndex = 0;
    private Vector3 curDir;
    private float prevAngle = 0f;
    private float angle = 0f;

    private int rotateTime = 50;
    private int curRotate = 0;
    private int rotSpeed = 5;
    private bool rotating = false;

	// Use this for initialization
	void Start () {
        /**dest = new List<Vector3>();
        dest.Add(new Vector3(-39.335f, -2.375f, 20.206f));
        dest.Add(new Vector3(-1.902f, -2.377f, 21.857f));
        dest.Add(new Vector3(-1.902f, -2.375f, 118.86f));
        dest.Add(new Vector3(-72.972f, -2.375f, 117.15f));**/
        controller = GetComponent<CharacterController>();

        //debug the graph
        //debugGraph();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey("2"))
            startPlan = true;
        if (startPlan)
        {
            Vector3 initialPos = controller.transform.localPosition;
            if (dest != null && dest.Count > 0)
            {
                curDir = Vector3.Normalize(dest[0] - initialPos);
            }
            startMove = true;
            startPlan = false;
        }
        if (startMove)
        {
            //rotating = true;
            //Rotate();
            Move();
        }
	}

    void Rotate()
    {
        if (curDir.x < 0)
            angle = - Vector3.Angle(Vector3.forward, curDir);
        else
            angle = Vector3.Angle(Vector3.forward, curDir);
        //Debug.Log(angle);
        int multiplier;
        if ((prevAngle > angle && prevAngle - angle > 180) || (angle > prevAngle && angle - prevAngle < 180))
            multiplier = 1;
        else
            multiplier = -1;
        if (Mathf.Abs(prevAngle + rotSpeed * multiplier * curRotate - angle) < rotSpeed * 0.55)
        {
            rotating = false;
            controller.transform.Rotate(Vector3.up, angle);
        }
        else
        {
            curRotate++;
            rotating = true;
            controller.transform.Rotate(Vector3.up, prevAngle + rotSpeed * multiplier * curRotate);
        }
    }

    void Move()
    {
        //if (rotating)
        //   return;
        //Debug.Log(controller.transform.localRotation);
        //Debug.Log("Destination: " + dest[curIndex] + ", Index: " + curIndex);
        Vector3 before = controller.transform.localPosition - dest[curIndex];
        controller.Move(curDir * speed * Time.deltaTime);
        Vector3 after = controller.transform.localPosition - dest[curIndex];
        if (Vector3.Dot(before, after) < 0 || before.x * after.x < 0)
        {
            if (curIndex == dest.Count - 1)
            {
                startMove = false;
                curIndex = 0;
            }
            else
            {
                curIndex++;
                prevAngle = angle;
                //rotating = true;
                curDir = Vector3.Normalize(dest[curIndex] - controller.transform.localPosition);
                curRotate = 0;
            }
        }
    }

    void debugGraph()
    {
        Debug.Log("creating vertices");
        Vector3 v1 = new Vector3(0, 0, 0);
        Vector3 v2 = new Vector3(1, 0, 0);
        Vector3 v3 = new Vector3(0, 0, 1);
        Vector3 v4 = new Vector3(1, 0, 1);
        Vector3 v5 = new Vector3(2, 0, 1);
        Vector3 v6 = new Vector3(1, 0, 3);
        Vector3 v7 = new Vector3(2, 0, 2);
        List<Vector3> vertices = new List<Vector3>();
        vertices.AddRange(new Vector3[] { v1, v2, v3, v4, v5, v6, v7 });

        Dictionary<Vector3, List<Vector3>> edges = new Dictionary<Vector3, List<Vector3>>();
        List<Vector3> neighbor = new List<Vector3>();
        neighbor.AddRange(new Vector3[] { v4, v3, v2 });
        edges.Add(v1, neighbor);

        neighbor = new List<Vector3>();
        neighbor.AddRange(new Vector3[] { v1, v4, v5 });
        edges.Add(v2, neighbor);

        neighbor = new List<Vector3>();
        neighbor.AddRange(new Vector3[] { v1, v4, v6 });
        edges.Add(v3, neighbor);

        neighbor = new List<Vector3>();
        neighbor.AddRange(new Vector3[] { v2, v3, v6, v5 });
        edges.Add(v4, neighbor);

        neighbor = new List<Vector3>();
        neighbor.AddRange(new Vector3[] { v7, v4, v2 });
        edges.Add(v5, neighbor);

        neighbor = new List<Vector3>();
        neighbor.AddRange(new Vector3[] { v7, v4, v3 });
        edges.Add(v6, neighbor);

        neighbor = new List<Vector3>();
        neighbor.AddRange(new Vector3[] { v5, v6 });
        edges.Add(v7, neighbor);

        Debug.Log("Dictionary created");

        Graph_t g = new Graph_t(vertices, edges);

        Debug.Log("graph created");

        List<Vector3> result = g.shortestPath(v1, v7);
        Debug.Log("result created");
        foreach (Vector3 v in result)
            Debug.Log("Result: " + v);
    }

}
