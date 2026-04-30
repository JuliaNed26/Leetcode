public class Solution {
    const int MaxDist = int.MaxValue;
    private int nodesCount;
    private Dictionary<int, List<int[]>> graph;
    private int threshold;

    public int FindTheCity(int n, int[][] edges, int distanceThreshold) {
        nodesCount = n;
        threshold = distanceThreshold;
        graph = new();
        foreach(var edge in edges)
        {
            if(!graph.ContainsKey(edge[0]))
            {
                graph[edge[0]] = new List<int[]>();
            }
            if(!graph.ContainsKey(edge[1]))
            {
                graph[edge[1]] = new List<int[]>();
            }

            graph[edge[0]].Add([edge[1], edge[2]]);
            graph[edge[1]].Add([edge[0], edge[2]]);
        }

        int result = 0;
        int minReachable = int.MaxValue;
        for(int i = 0; i < n; i++)
        {
            var nodeReachableCount = GetReachableCountDijkstra(i);
            if(minReachable >= nodeReachableCount)
            {
                result = i;
                minReachable = nodeReachableCount;
            }
        }

        return result;
    }

    private int GetReachableCountDijkstra(int node) 
    {
        var dist = Enumerable.Repeat(MaxDist, nodesCount).ToArray();
        dist[node] = 0;
        var minHeap = new PriorityQueue<(int Node, int Parent), int>();
        minHeap.Enqueue((node, node), 0);
        while(minHeap.Count != 0)
        {
            minHeap.TryDequeue(out var nodesPair, out var curDist);
            var parentNode = nodesPair.Parent;
            var curNode = nodesPair.Node;
            if(curDist > dist[curNode])           
            {
                continue;
            }

            if(graph.TryGetValue(curNode, out var nodeEdges))
            {
                foreach(var edge in nodeEdges)
                {
                    var dest = edge[0];
                    var weight = edge[1];
                    var newDist = curDist + weight;
                    if(
                        dest == parentNode 
                        || newDist > dist[dest] 
                        || newDist > threshold)
                    {
                        continue;
                    }

                    dist[dest] = newDist;
                    minHeap.Enqueue((dest, curNode), newDist);
                }
            }
        }

        return dist.Where(d => d <= threshold).Count() - 1;
    }
}
