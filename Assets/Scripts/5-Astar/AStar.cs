using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Tilemaps;
using System;


    /// <summary>
    /// A* search based off Amit Patel's implementation.
    /// </summary>
    /// <remarks>
    /// Patel's implementation is different than what you see in most algorithms and AI textbooks.
    /// https://www.redblobgames.com/pathfinding/a-star/implementation.html
    /// </remarks>
    public class AStar
    {
         public static List<Vector3Int> FindPath(IGraph<Vector3Int> graph, Vector3Int start, Vector3Int goal)
        {
            PriorityQueue<Vector3Int> open = new PriorityQueue<Vector3Int>();
            open.Enqueue(start, 0);
            

            Dictionary<Vector3Int, Vector3Int> cameFrom = new Dictionary<Vector3Int, Vector3Int>();
            cameFrom[start] = start;

            Dictionary<Vector3Int, float> costSoFar = new Dictionary<Vector3Int, float>();
            costSoFar[start] = 0;

            while (open.Count > 0)
            {
                Vector3Int current = open.Dequeue();

                if (current == goal)
                {
                    break;
                }

                foreach (Vector3Int next in graph.Neighbors(current))
                {
                    float newCost = costSoFar[current] + graph.Cost(current, next);

                    if (!costSoFar.ContainsKey(next) || newCost < costSoFar[next])
                    {
                        costSoFar[next] = newCost;
                        float priority = newCost + Heuristic.ManhattanDist(next, goal);
                        open.Enqueue(next, priority);
                        cameFrom[next] = current;
                    }
                }
            }

            List<Vector3Int> path = null;

            if (cameFrom.ContainsKey(goal))
            {
                path = new List<Vector3Int>();

                Vector3Int v = goal;

                while (v != start)
                {
                    RemoveDuplicates(path, v);
                    path.Add(v);
                    v = cameFrom[v];
                }

                RemoveDuplicates(path, start);
                path.Add(start);

                path.Reverse();
            }

            return path;
        }
          static void RemoveDuplicates(List<Vector3Int> path, Vector3Int v)
        {
            if (path.Count >= 2)
            {
                Vector3Int last = path[path.Count - 1];
                Vector3Int secondLast = path[path.Count - 2];

                Vector3Int dir1 = last - secondLast;
                dir1.Clamp(Vector3Int.one * -1, Vector3Int.one);

                Vector3Int dir2 = v - last;
                dir2.Clamp(Vector3Int.one * -1, Vector3Int.one);

                if (dir1 == dir2)
                {
                    path.RemoveAt(path.Count - 1);
                }
            }
        }
 static HashSet<Vector3Int> OpenCells(Tilemap map, Vector3Int start, Vector3Int goal)
        {
            Dictionary<Vector3Int, int> counts = new Dictionary<Vector3Int, int>();
            counts.Add(goal, 0);

            HashSet<Vector3Int> openCells = new HashSet<Vector3Int>();

            float minDist = Mathf.Infinity;
            int minCount = int.MaxValue;

            map.BreadthFirstTraversal(goal, Utils.FourDirections, (current, next) =>
            {
                float dist = Vector3Int.Distance(goal, next);
                int count = counts[current] + 1;
                counts[next] = count;

                if ((map.IsCellEmpty(next) || next == start) && dist <= minDist)
                {
                    minDist = dist;
                    minCount = count;
                    openCells.Add(next);
                }

                return count <= minCount && map.IsInBounds(next);
            });

            return openCells;
        }

        static Vector3Int ClosestCell(HashSet<Vector3Int> openCells, Vector3Int start, Vector3Int goal)
        {
            Vector3Int closest = goal;
            float minDist = Mathf.Infinity;

            foreach (Vector3Int c in openCells)
            {
                float dist = Vector3Int.Distance(start, c);

                if (dist < minDist)
                {
                    minDist = dist;
                    closest = c;
                }
            }

            return closest;
        }
      
    }

     
    