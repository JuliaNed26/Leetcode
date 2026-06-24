public class Solution {
    public int SwimInWater(int[][] grid) {
        var width = grid.Length;
        var dist = Enumerable.Repeat(int.MaxValue, width * width).ToArray();

        var sides = new List<(int x, int y)>()
        {
            (1, 0), (0, 1), (-1, 0), (0, -1)
        };
        var pq = new PriorityQueue<(int y, int x), int>();
        pq.Enqueue((0,0), grid[0][0]);
        while(pq.Count != 0)
        {
            pq.TryDequeue(out var p, out var distance);
            var flattenedIdx = FlattenIdx(p.x, p.y, width);
            if(dist[flattenedIdx] <= distance)
            {
                continue;
            }

            dist[flattenedIdx] = distance;
            foreach(var side in sides)
            {
                var curX = p.x + side.x;
                var curY = p.y + side.y;
                if(curX < 0 || curX >= width || curY < 0 || curY >= width)
                {
                    continue;
                }

                var curFlattened = FlattenIdx(curX, curY, width);
                var curDist = Math.Max(distance, grid[curY][curX]);

                if (curDist < dist[curFlattened])
                {
                    pq.Enqueue((curY, curX), curDist);
                }
            }
        }

        return dist.Last();
    }

    private int FlattenIdx(int x, int y, int width)
    {
        return y * width + x;
    }
}