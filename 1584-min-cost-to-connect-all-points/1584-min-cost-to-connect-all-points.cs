public class Solution {
    public int MinCostConnectPoints(int[][] points) {
        var pointRecords = points.Select(p => new Point(p[0], p[1]))
                                .ToList();
        var graph = pointRecords.ToDictionary(p => p, _ => new List<Edge>());
        for(int i = 0; i < pointRecords.Count() - 1; i++)
        {
            var curPoint = pointRecords[i];
            for(int k = i + 1; k < pointRecords.Count(); k++)
            {
                var neighbour = pointRecords[k];
                var dist = GetManhattanDist(curPoint, neighbour);
                graph[curPoint].Add(new Edge(neighbour, dist));
                graph[neighbour].Add(new Edge(curPoint, dist));
            }
        }

        var visited = new HashSet<Point>();
        var priorityQueue = new PriorityQueue<Point, int>();
        priorityQueue.Enqueue(pointRecords[0], 0);
        int result = 0;
        while(visited.Count() != pointRecords.Count())
        {
            priorityQueue.TryDequeue(out Point point, out int dist);
            if(visited.Contains(point))
            {
                continue;
            }
            
            visited.Add(point);
            result += dist;
            foreach(var edge in graph[point])
            {
                if(!visited.Contains(edge.P))
                {
                    priorityQueue.Enqueue(edge.P, edge.Dist);
                }
            }
        }

        return result;
    }

    private int GetManhattanDist(Point p1, Point p2)
        => Math.Abs(p1.X - p2.X) + Math.Abs(p1.Y - p2.Y);

    private record struct Point (int X, int Y);

    private record Edge (Point P, int Dist);
}