public class Solution {
    public int NetworkDelayTime(int[][] times, int n, int k) {
        const int MaxTime = 1000;
        var dist = Enumerable.Repeat(MaxTime, n).ToArray();
        dist[k - 1] = 0;
        var graph = times.GroupBy(t => t[0])
                         .ToDictionary(
                            g => g.Key - 1,
                            g => g.Select(i => new List<int>(2) {i[1] - 1, i[2]})
                         );
        var queue = new Queue<(int Node, int Time)>();
        queue.Enqueue((k - 1, 0));
        while(queue.Count != 0)
        {
            (int curNode, int curTime) = queue.Dequeue();
            if(dist[curNode] < curTime)
            {
                continue;
            }

            if(graph.TryGetValue(curNode, out var neighbours))
            {
                foreach(var neighbour in neighbours)
                {
                    var newTime = dist[curNode] + neighbour[1];
                    var neighNode = neighbour[0];
                    if(newTime < dist[neighNode])
                    {
                        queue.Enqueue((neighNode, newTime));
                        dist[neighNode] = newTime;
                    }
                }
            }
        }

        var signalTime = dist.Max();
        return signalTime == MaxTime ? -1 : signalTime;
    }
}
