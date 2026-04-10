public class Solution {
    public int NetworkDelayTime(int[][] times, int n, int k) {
        const int MaxTime = 1000;
        var dist = Enumerable.Repeat(MaxTime, n).ToArray();
        var graph = times.GroupBy(t => t[0])
                         .ToDictionary(
                            g => g.Key - 1, 
                            g => g.Select(i => new List<int>(2) {i[1] - 1, i[2]}).ToList());
        DFS(k-1, 0);

        var signalTime = dist.Max();
        return signalTime == MaxTime ? -1 : signalTime;

        void DFS(int node, int distance)
        {
            if(distance >= dist[node])
            {
                return;
            }

            dist[node] = distance;
            if(graph.TryGetValue(node, out var neighbours))
            {
                foreach(var neighbour in neighbours)
                {
                    DFS(neighbour[0], dist[node] + neighbour[1]);
                }
            }
        }
    }
}
