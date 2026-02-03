public class Solution {
    public IList<IList<int>> PacificAtlantic(int[][] heights) 
    {
        var toPacific = GetReachPacific();
        var toAtlantic = GetReachAtlantic();

        List<IList<int>> result = [];
        foreach(var point in toPacific.Intersect(toAtlantic))
        {
            result.Add([point.y, point.x]);
        }

        return result;

        HashSet<(int x, int y)> GetReachPacific()
        {
            Queue<(int x, int y)> queue = [];

            for(int i = 0; i < heights.Length; i++) 
            {
                queue.Enqueue((0, i));
            }

            for(int i = 0; i < heights[0].Length; i++) 
            {
                queue.Enqueue((i, 0));
            }

            return Bfs(queue, heights);
        }

        HashSet<(int x, int y)> GetReachAtlantic()
        {
            Queue<(int x, int y)> queue = [];

            for(int i = 0; i < heights.Length; i++) 
            {
                queue.Enqueue((heights[0].Length - 1, i));
            }

            for(int i = 0; i < heights[0].Length; i++) 
            {
                queue.Enqueue((i, heights.Length - 1));
            }

            return Bfs(queue, heights);
        }
    }

    private HashSet<(int x, int y)> Bfs(Queue<(int x, int y)> queue, int[][] heights)
    {
        var visited = new HashSet<(int x, int y)>();

        while(queue.Count > 0)
        {
            var curPoint = queue.Dequeue();
            if(visited.Contains(curPoint))
            {
                continue;
            }

            if(curPoint.x > 0 
                && heights[curPoint.y][curPoint.x - 1] >= heights[curPoint.y][curPoint.x])
            {
                queue.Enqueue((curPoint.x - 1, curPoint.y));
            }
            if(curPoint.y > 0 
                && heights[curPoint.y - 1][curPoint.x] >= heights[curPoint.y][curPoint.x])
            {
                queue.Enqueue((curPoint.x, curPoint.y - 1));
            }
            if(curPoint.x < heights[0].Length - 1
                && heights[curPoint.y][curPoint.x + 1] >= heights[curPoint.y][curPoint.x])
            {
                queue.Enqueue((curPoint.x + 1, curPoint.y));
            }
            if(curPoint.y < heights.Length - 1
                && heights[curPoint.y + 1][curPoint.x] >= heights[curPoint.y][curPoint.x])
            {
                queue.Enqueue((curPoint.x, curPoint.y + 1));
            }

            visited.Add(curPoint);
        }

        return visited;
    }
}