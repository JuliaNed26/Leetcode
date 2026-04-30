public class Solution {
    const int MaxDist = int.MaxValue;
    private int nodesCount;
    private int[][] graph;
    private int threshold;

    public int FindTheCity(int n, int[][] edges, int distanceThreshold) {
        nodesCount = n;
        threshold = distanceThreshold;
        graph = edges;

        int result = 0;
        int minReachable = int.MaxValue;
        
        for(int i = 0; i < n; i++)
        {
            var nodeReachableCount = GetReachableCountBellmanFord(i);
            if(minReachable >= nodeReachableCount)
            {
                result = i;
                minReachable = nodeReachableCount;
            }
        }

        return result;
    }

    private int GetReachableCountBellmanFord(int node) 
    {
        var dist = Enumerable.Repeat(MaxDist, nodesCount).ToArray();
        dist[node] = 0;
        for(int i = 0; i < nodesCount - 1; i++)
        {
            bool anyImprovements = false;
            foreach(var edge in graph)
            {
                var newDistFirstEdge = dist[edge[0]] + edge[2];
                if(dist[edge[0]] != MaxDist && dist[edge[1]] > newDistFirstEdge)               
                {
                    dist[edge[1]] = newDistFirstEdge;
                    anyImprovements = true;
                }

                var newDistSecondEdge = dist[edge[1]] + edge[2];
                if(dist[edge[1]] != MaxDist
                    && dist[edge[0]] > newDistSecondEdge)               
                {
                    dist[edge[0]] = newDistSecondEdge;
                    anyImprovements = true;
                }
            }

            if(!anyImprovements)
            {
                break;
            }
        }

        return dist.Where(d => d <= threshold).Count() - 1;
    }
}
