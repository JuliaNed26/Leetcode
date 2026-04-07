public class Solution {
    public int NetworkDelayTime(int[][] times, int n, int k) {
        const int MaxTime = 1000;
        var edges = times.GroupBy(t => t[0])
                            .ToDictionary(
                                g => g.Key - 1,
                                g => g.Select(edge => new List<int>(2) {edge[1] - 1, edge[2]}).ToList());
        var dist = Enumerable.Repeat(MaxTime, n).ToArray();
        dist[k - 1] = 0;
        var pq = new PriorityQueue<int, int>();
        pq.Enqueue(k-1, 0);
        while(pq.Count != 0)
        {
            if(pq.TryDequeue(out var node, out var minDist))
            {
                // to get rid of stale dist, cause we add new dist to pq every time it is updated
                if(minDist > dist[node])
                {
                    continue;
                }

                if(edges.TryGetValue(node, out var neighbours))
                {
                    foreach(var edge in neighbours)
                    {
                        var weight = edge[1];
                        var neighNode = edge[0];
                        var nextDist = dist[node] + weight;
                        if(dist[neighNode] > nextDist)
                        {
                            dist[neighNode] = nextDist;
                            pq.Enqueue(neighNode, nextDist);
                        }
                    }
                }
            }
        }

        var signalTime = dist.Max();
        return signalTime == MaxTime ? -1 : signalTime;
    }
}