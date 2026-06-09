public class Solution {
    public int MinCostConnectPoints(int[][] points) {
        var pL = points.Length;
        var edges = new List<Edge>((pL + 1) / 2 * pL);
        for(int i = 0; i < pL - 1; i++)
        {
            var p1 = new Point(points[i][0], points[i][1]);
            for(int k = i + 1; k < pL; k++)
            {
                var p2 = new Point(points[k][0], points[k][1]);
                edges.Add(new Edge(p1, p2, GetManhattanDist(p1, p2)));
            }
        }
        edges = edges.OrderBy(e => e.Dist).ToList();
        var dsu = new DSU(points);
        var result = 0;

        foreach(var edge in edges)
        {
            if(dsu.Union(edge.P1, edge.P2))
            {
                result += edge.Dist;
            }
        }

        return result;
    }

    private int GetManhattanDist(Point p1, Point p2)
        => Math.Abs(p1.X - p2.X) + Math.Abs(p1.Y - p2.Y);

    private record struct Point (int X, int Y);

    private record Edge (Point P1, Point P2, int Dist);

    private class DSU
    {
        private Dictionary<Point, Point> parents;
        private Dictionary<Point, int> ranks;

        public DSU(int[][] points)
        {
            var pointsArray = points.Select(p => new Point(p[0], p[1])).ToArray();
            parents = pointsArray.ToDictionary(p => p, p => p);
            ranks = pointsArray.ToDictionary(p => p, _ => 1);
        }

        public bool Union (Point p1, Point p2)
        {
            var parentP1 = Find(p1);
            var parentP2 = Find(p2);

            if(parentP1 == parentP2)
            {
                return false;
            }

            if(ranks[parentP1] > ranks[parentP2])
            {
                parents[parentP2] = parentP1;
                ranks[parentP1] += ranks[parentP2];
            }
            else
            {
                parents[parentP1] = parentP2;
                ranks[parentP2] += ranks[parentP1];
            }
            return true;
        }

        public Point Find(Point child)
        {
            var curParent = parents[child];
            while(curParent != child)
            {
                child = curParent;
                curParent = parents[child];
            }

            return curParent;
        }
    }
}