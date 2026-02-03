public class Solution {
    public IList<IList<int>> PacificAtlantic(int[][] heights) {
        HashSet<(int x, int y)> toPacific = [];
        HashSet<(int x, int y)> toAtlantic = [];
        for(int x = 0; x < heights[0].Length; x++)
        {
            Bfs(x, 0, toPacific);
        }
        for(int y = 0; y < heights.Length; y++)
        {
            Bfs(0, y, toPacific);
        }
        for(int x = 0; x < heights[0].Length; x++)
        {
            Bfs(x, heights.Length - 1, toAtlantic);
        }
        for(int y = 0; y < heights.Length; y++)
        {
            Bfs(heights[0].Length - 1, y, toAtlantic);
        }

        var resultPoints = toPacific.Intersect(toAtlantic).ToList();
        List<IList<int>> result = [];
        foreach(var point in resultPoints)
        {
            result.Add([point.y, point.x]);
        }
        return result;


        void Bfs(int x, int y, HashSet<(int x, int y)> toOcean)
        {
            HashSet<(int x, int y)> seen = [];
            var queue = new Queue<(int x, int y)>();
            queue.Enqueue((x,y));
            while(queue.Count != 0)
            {
                var curPoint = queue.Dequeue();
                if (seen.Contains(curPoint))
                {
                    continue;
                }
                toOcean.Add(curPoint);
                if (curPoint.x > 0
                    && heights[curPoint.y][curPoint.x] <= heights[curPoint.y][curPoint.x-1])
                {
                    queue.Enqueue((curPoint.x - 1, curPoint.y));
                }
                if (curPoint.y > 0
                    && heights[curPoint.y][curPoint.x] <= heights[curPoint.y - 1][curPoint.x])
                {
                    queue.Enqueue((curPoint.x, curPoint.y - 1));
                }
                if (curPoint.x < heights[0].Length - 1
                    && heights[curPoint.y][curPoint.x] <= heights[curPoint.y][curPoint.x+1])
                {
                    queue.Enqueue((curPoint.x + 1, curPoint.y));
                }
                if (curPoint.y < heights.Length - 1
                    && heights[curPoint.y][curPoint.x] <= heights[curPoint.y + 1][curPoint.x])
                {
                    queue.Enqueue((curPoint.x, curPoint.y + 1));
                }
                seen.Add(curPoint);
            }
        }
    }
}