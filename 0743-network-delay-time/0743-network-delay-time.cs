public class Solution {
    private const int MAX_TIME_VALUE = 20000;

    public int NetworkDelayTime(int[][] times, int n, int k) {
        Dictionary<int, List<(int Neighbour, int Time)>> graph = times.GroupBy(t => t[0])
                        .ToDictionary(x => x.Key, x => x.Select(t => (t[1],t[2])).ToList());
        var distances = Enumerable.Repeat(MAX_TIME_VALUE, n + 1).ToArray();
        var pq = new PriorityQueue<int, int>();
        var visited = new HashSet<int>();
        pq.Enqueue(k, 0);
        distances[k] = 0;
        while(pq.Count > 0)
        {
            var curElement = pq.Dequeue();
            if(visited.Contains(curElement))
            {
                continue;
            }
            if(graph.TryGetValue(curElement, out var neighbours))
            {
                foreach(var neighbour in neighbours)
                {
                    var newDist = distances[curElement] + neighbour.Time;
                    if(!visited.Contains(neighbour.Neighbour) && distances[neighbour.Neighbour] > newDist)
                    {
                        distances[neighbour.Neighbour] = newDist;
                        pq.Enqueue(neighbour.Neighbour, newDist);
                    }
                }
            }
            visited.Add(curElement);
        }

        var result = distances.Skip(1).Max();
        return result == MAX_TIME_VALUE ? -1 : result;
    }
}