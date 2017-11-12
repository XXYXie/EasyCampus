using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal class Graph_t
{
    public List<Vector3> vertices;
    public Dictionary<Vector3, List<Vector3>> edges;
    private Dictionary<Vector3, bool> check;

    public List<Vector3> prevList;
    public List<Vector3> nextList;
    public List<Vector3> resultList;
    public Dictionary<Vector3, List<Vector3>> searchGraph;
    public Dictionary<Vector3, float> score;

    public Graph_t(List<Vector3> vertices, Dictionary<Vector3, List<Vector3>> edges)
    {
        this.vertices = vertices;
        this.edges = edges;
        check = new Dictionary<Vector3, bool>();
        prevList = new List<Vector3>();
        nextList = new List<Vector3>();
        resultList = new List<Vector3>();
        searchGraph = new Dictionary<Vector3, List<Vector3>>();
        score = new Dictionary<Vector3, float>();
        foreach (Vector3 v in vertices)
        {
            check.Add(v, false);
            score.Add(v, float.MaxValue);
            searchGraph.Add(v, null);
        }
    }

    public List<Vector3> shortestPath(Vector3 src, Vector3 dest)
    {
        prevList.Add(src);
        if (src == dest)
            return prevList;

        List<Vector3> cur = new List<Vector3>();
        cur.Add(src);
        searchGraph[src] = cur;
        check[src] = true;
        score[src] = 0f;
        int count = 0;
        while (true)
        {
            foreach (Vector3 v in prevList)
            {
                foreach (Vector3 next in edges[v])
                {
                    if (check[next])
                        continue;
                    nextList.Add(next);

                    if (searchGraph[next] == null)
                    {
                        List<Vector3> l = new List<Vector3>();
                        foreach (Vector3 vec in searchGraph[v])
                            l.Add(vec);
                        l.Add(next);
                        searchGraph[next] = l;
                        nextList.Add(next);
                        score[next] = score[v] + Vector3.Distance(next, v);
                        count++;
                    }
                    else
                    {
                        float tempScore = score[v] + Vector3.Distance(next, v);
                        if (tempScore < score[next])
                        {
                            List<Vector3> l = new List<Vector3>();
                            foreach (Vector3 vec in searchGraph[v])
                                l.Add(vec);
                            l.Add(next);
                            searchGraph[next] = l;
                            score[next] = tempScore;
                        }
                    }

                    if (count > vertices.Count)
                        return null;
                }
            }
            if (nextList.Contains(dest))
                return searchGraph[dest];
            foreach (Vector3 v in nextList)
                check[v] = true;
            prevList = nextList;
            nextList = new List<Vector3>();
        }
    }
}