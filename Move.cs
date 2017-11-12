using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

    public TestMoveScript move;
    CharacterController controller;
    Graph_t map;
    Dictionary<Vector3, string> buildingName;
    // Default value = -1. Drama (v4) = 3, CFA (v13) = 11, HL (v10) = 9, SportsField (v23) = 16,
    // Hamerschlag (v30) = 22.
    public int destination = -1;

    int maxDistance = 20;

    // Use this for initialization
    void Start () {
        controller = GetComponent<CharacterController>();
        move = controller.GetComponent<TestMoveScript>();
        loadMapData();
	}

    void loadMapData()
    {
        Vector3 v1 = new Vector3(-39.335f, -2.375f, 20.206f);
        Vector3 v2 = new Vector3(-1.902f, -2.375f, 21.857f);
        Vector3 v3 = new Vector3(57.334f, -2.375f, 13.971f);
        Vector3 v4 = new Vector3(84.023f, -2.375f, 15.629f);
        Vector3 v5 = new Vector3(-1.902f, -2.375f, 118.86f);
        Vector3 v6 = new Vector3(58.753f, -2.375f, 113.31f);
        Vector3 v7 = new Vector3(-42.69f, -2.375f, 118.85f);
        Vector3 v8 = new Vector3(61.544f, -2.375f, 123.32f);
        Vector3 v9 = new Vector3(-5.0148f, -2.375f, 160.66f);
        Vector3 v10 = new Vector3(60.785f, -2.375f, 157.70f);
        Vector3 v11 = new Vector3(1.6298f, -2.375f, 183.91f);
        Vector3 v13 = new Vector3(-47.08f, -2.375f, 132.09f);
        Vector3 v14 = new Vector3(-72.972f, -2.375f, 117.15f);
        Vector3 v17 = new Vector3(-95.03f, -2.375f, 196.61f);
        Vector3 v20 = new Vector3(-89.61f, -2.375f, 278.92f);
        Vector3 v22 = new Vector3(-40.49f, -2.375f, 184.08f);
        Vector3 v23 = new Vector3(-38.86f, -2.375f, 230.62f);
        Vector3 v24 = new Vector3(82.221f, -2.375f, 126.38f);
        Vector3 v26 = new Vector3(145.92f, -2.375f, 125.90f);
        Vector3 v27 = new Vector3(143.68f, -2.375f, 162.46f);
        Vector3 v28 = new Vector3(145.77f, -2.375f, 195.80f);
        Vector3 v29 = new Vector3(174.03f, -1.383f, 191.55f);
        Vector3 v30 = new Vector3(172.63f, -1.383f, 155.74f);

        List<Vector3> vertices = new List<Vector3>();
        vertices.AddRange(new Vector3[] { v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v13, v14, v17, v20,
            v22, v23, v24, v26, v27, v28, v29, v30});

        Dictionary<Vector3, List<Vector3>> edges = new Dictionary<Vector3, List<Vector3>>();
        List<Vector3> neighbor = new List<Vector3>();
        neighbor.AddRange(new Vector3[] { v2 });
        edges.Add(v1, neighbor);

        neighbor = new List<Vector3>();
        neighbor.AddRange(new Vector3[] { v1, v3, v5 });
        edges.Add(v2, neighbor);

        neighbor = new List<Vector3>();
        neighbor.AddRange(new Vector3[] { v2, v4, v6 });
        edges.Add(v3, neighbor);

        neighbor = new List<Vector3>();
        neighbor.AddRange(new Vector3[] { v3 });
        edges.Add(v4, neighbor);

        neighbor = new List<Vector3>();
        neighbor.AddRange(new Vector3[] { v2, v7, v6, v9 });
        edges.Add(v5, neighbor);

        neighbor = new List<Vector3>();
        neighbor.AddRange(new Vector3[] { v3, v5, v8 });
        edges.Add(v6, neighbor);

        neighbor = new List<Vector3>();
        neighbor.AddRange(new Vector3[] { v5, v13, v14 });
        edges.Add(v7, neighbor);

        neighbor = new List<Vector3>();
        neighbor.AddRange(new Vector3[] { v6, v10, v24 });
        edges.Add(v8, neighbor);

        neighbor = new List<Vector3>();
        neighbor.AddRange(new Vector3[] { v5, v10, v11 });
        edges.Add(v9, neighbor);

        neighbor = new List<Vector3>();
        neighbor.AddRange(new Vector3[] { v8, v9, v24, v27 });
        edges.Add(v10, neighbor);

        neighbor = new List<Vector3>();
        neighbor.AddRange(new Vector3[] { v9, v22 });
        edges.Add(v11, neighbor);

        neighbor = new List<Vector3>();
        neighbor.AddRange(new Vector3[] { v7 });
        edges.Add(v13, neighbor);

        neighbor = new List<Vector3>();
        neighbor.AddRange(new Vector3[] { v7, v17 });
        edges.Add(v14, neighbor);

        neighbor = new List<Vector3>();
        neighbor.AddRange(new Vector3[] { v14, v20, v22 });
        edges.Add(v17, neighbor);

        neighbor = new List<Vector3>();
        neighbor.AddRange(new Vector3[] { v17 });
        edges.Add(v20, neighbor);

        neighbor = new List<Vector3>();
        neighbor.AddRange(new Vector3[] { v11, v17, v23 });
        edges.Add(v22, neighbor);

        neighbor = new List<Vector3>();
        neighbor.AddRange(new Vector3[] { v22 });
        edges.Add(v23, neighbor);

        neighbor = new List<Vector3>();
        neighbor.AddRange(new Vector3[] { v8, v10, v26 });
        edges.Add(v24, neighbor);

        neighbor = new List<Vector3>();
        neighbor.AddRange(new Vector3[] { v24, v27 });
        edges.Add(v26, neighbor);

        neighbor = new List<Vector3>();
        neighbor.AddRange(new Vector3[] { v10, v26, v28 });
        edges.Add(v27, neighbor);

        neighbor = new List<Vector3>();
        neighbor.AddRange(new Vector3[] { v27, v29 });
        edges.Add(v28, neighbor);

        neighbor = new List<Vector3>();
        neighbor.AddRange(new Vector3[] { v28, v30 });
        edges.Add(v29, neighbor);

        neighbor = new List<Vector3>();
        neighbor.AddRange(new Vector3[] { v29 });
        edges.Add(v30, neighbor);

        map = new Graph_t(vertices, edges);

        buildingName = new Dictionary<Vector3, string>();
        buildingName.Add(v4, "Drama");
        buildingName.Add(v13, "CFA");
        buildingName.Add(v10, "Hunt Library");
    }

    Vector3 getNearestPoint(Vector3 cur)
    {
        Vector3 best = new Vector3(0, 0, 0);
        float smallest = 10000f;
        foreach (Vector3 vec in map.vertices)
        {
            if (Vector3.Distance(cur, vec) < smallest)
            {
                smallest = Vector3.Distance(cur, vec);
                best = vec;
            }
        }
        return best;
    }

    List<Vector3> getPath(Vector3 goal)
    {
        Vector3 init = getNearestPoint(controller.transform.localPosition);
        if (!map.vertices.Contains(goal))
            return null;
        List<Vector3> result = map.shortestPath(init, goal);
        if (init == controller.transform.localPosition)
            result.Remove(init);
        return result;
    }

    public string getNearestBuilding()
    {
        Vector3 cur = controller.transform.localPosition;
        float nearest = 10000f;
        Vector3 best = new Vector3(0, 0, 0);
        foreach (Vector3 vec in buildingName.Keys)
        {
            if (Vector3.Distance(vec, cur) < nearest)
            {
                best = vec;
                nearest = Vector3.Distance(vec, cur);
            }
        }
        if (nearest > maxDistance)
            return null;
        else
            return buildingName[best];
    }
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey("d"))
        {
            destination = 3; //drama
        }
        if (Input.GetKey("s"))
        {
            destination = 16; //sports field
        }
        if (Input.GetKey("c"))
        {
            destination = 11; //cfa
        }
        if (Input.GetKey("l"))
        {
            destination = 9; //hunt library
        }
        if (Input.GetKey("h"))
        {
            destination = 22; //hamerschlag classroom
        }
        if (Input.GetKey("x"))
        {
            stop();
        }

        if (Input.GetKey("i"))
        {
            Debug.Log(getNearestBuilding());
        }
        if (destination != -1)
        {
            Start();
            move.dest = getPath(map.vertices[destination]);
            move.curIndex = 0;
            move.startPlan = true;
            destination = -1;
        }

	}

    public void stop()
    {
        destination = -1;
        move.startMove = false;
    }
}
