public class Solution {
    private const int MAX_EFFORT = 1000000;

    public int MinimumEffortPath(int[][] heights) {
        var l = 0;
        var r = MAX_EFFORT;
        
        var res = 0;
        while(l <= r)
        {
            var mid = l + (int)Math.Floor(((decimal)r - l) / 2);
            if(Dfs(heights, mid))
            {
                r = mid - 1;
                res = mid;
            }
            else
            {
                l = mid + 1;
            }
        }

        return res;
    }

    private bool Dfs(int[][] heights, int curHeight)
    {
        var stack = new Stack<(int x, int y)>();
        var visited = Enumerable.Range(0, heights.Length)
                                .Select(_ => new bool[heights[0].Length])
                                .ToArray();
        stack.Push((0,0));
        var sides = new List<(int x, int y)>()
        {
            (0,1),
            (1,0),
            (-1,0),
            (0,-1)
        };
        while(stack.Count != 0)
        {
            var curCell = stack.Pop();
            if(curCell.x == heights[0].Length - 1 && curCell.y == heights.Length - 1)
            {
                return true;
            }
            if(visited[curCell.y][curCell.x])
            {
                continue;
            }

            foreach(var side in sides)
            {
                var neighX = curCell.x + side.x;
                var neighY = curCell.y + side.y;
                if(neighX >= 0 && neighX < heights[0].Length
                    && neighY >= 0 && neighY < heights.Length
                    && !visited[neighY][neighX]
                    && Math.Abs(heights[curCell.y][curCell.x] - heights[neighY][neighX]) <= curHeight)
                {
                    stack.Push((neighX, neighY));
                }
            }

            visited[curCell.y][curCell.x] = true;
        }

        return false;
    }
}
