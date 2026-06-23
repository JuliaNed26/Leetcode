public class Solution {
    public int SwimInWater(int[][] grid) {
        var count = grid.Length;
        var firstCellDepth = grid[0][0];
        var depths = grid.SelectMany(g => g.Where(x => x >= firstCellDepth))
                        .Distinct()
                        .OrderBy(x => x)
                        .ToList();;
        var stack = new Stack<(int y, int x)>();
        var result = int.MaxValue;
        var resultFound = false;

        var l = 0;
        int r = depths.Count - 1;
        while(l <= r)
        {
            var mid = l + (r - l) / 2;
            var depth = depths[mid];

            var visited = new bool[count * count];
            var reachable = false;
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
                    result = depth;
                    r = mid - 1;
                    reachable = true;
                    continue;
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
            if(!reachable)
            {
                l = mid + 1;
            }
        }

        return result;
    }

    private int FlattenIdx(int x, int y, int width)
    {
        return y * width + x;
    }
}
