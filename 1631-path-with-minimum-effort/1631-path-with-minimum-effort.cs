public class Solution {
    public int MinimumEffortPath(int[][] heights) {
        var height = heights.Length;
        var width = heights[0].Length;

        var pq = new PriorityQueue<(int x, int y), int>();
        var sides = new List<(int x, int y)> {
            (1, 0),
            (0, 1),
            (-1, 0),
            (0, -1)
        };
        pq.Enqueue((0,0), 0);
        var efforts = Enumerable.Range(0, height)
                                .Select(_ => Enumerable.Repeat(int.MaxValue, width).ToArray())
                                .ToArray();
        while(pq.Count > 0)
        {
            pq.TryDequeue(out var curCell, out var curHeight);

            if(curCell.x == width - 1 && curCell.y == height - 1)
            {
                return curHeight;
            }
            if(curHeight < efforts[curCell.y][curCell.x])
            {
                efforts[curCell.y][curCell.x] = curHeight;
            }

            foreach(var side in sides)
            {
                var neighX = side.x + curCell.x;
                var neighY = side.y + curCell.y;
                if(neighX >= 0 && neighX < width && neighY >= 0 && neighY < height)
                {
                    var diff = Math.Abs(heights[curCell.y][curCell.x] - heights[neighY][neighX]);
                    var effort = Math.Max(diff, curHeight);
                    if(efforts[neighY][neighX] > effort)
                    {
                        pq.Enqueue((neighX, neighY), effort);
                    }
                } 
            }
        }

        return efforts[height - 1][width - 1];
    }
}