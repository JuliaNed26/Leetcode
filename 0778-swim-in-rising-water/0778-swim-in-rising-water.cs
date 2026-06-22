public class Solution {
    public int SwimInWater(int[][] grid) {
        var count = grid.Length;
        var firstCellDepth = grid[0][0];
        var depths = grid.SelectMany(g => g.Where(x => x >= firstCellDepth))
                        .Distinct()
                        .OrderBy(x => x);
        var stack = new Stack<(int y, int x)>();
        var result = int.MaxValue;
        var resultFound = false;
        foreach(var depth in depths)
        {
            var visited = new bool[count * count];
            stack.Push((0,0));
            while(stack.Count != 0)
            {
                (int y, int x) = stack.Pop();
                var flattened = FlattenIdx(x, y, count);
                if(visited[flattened])
                {
                    continue;
                }
                if(x == count - 1 && y == count - 1)
                {
                    resultFound = true;
                    result = depth;
                }
                var pointsToPush = new List<(int y, int x)>()
                {
                    (y + 1, x), (y - 1, x), (y, x + 1), (y, x - 1)
                };
                foreach(var p in pointsToPush)
                {
                    var pFlattened = FlattenIdx(p.x, p.y, count);
                    if(p.x < 0 || p.y < 0 || p.x >= count || p.y >= count
                        || visited[pFlattened] || grid[p.y][p.x] > depth)
                    {
                        continue;
                    }
                    stack.Push((p.y, p.x));
                }

                visited[flattened] = true;
            }

            if(resultFound)
            {
                break;
            }
        }

        return result;
    }

    private int FlattenIdx(int x, int y, int width)
    {
        return y * width + x;
    }
}