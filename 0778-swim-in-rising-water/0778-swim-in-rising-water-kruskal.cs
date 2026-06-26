public class Solution {
    public int SwimInWater(int[][] grid) {
        var width = grid.Length;
        var pq = new PriorityQueue<(int y, int x), int>();
        for(int y = 0; y < width; y++)
        {
            for(int x = 0; x < width; x++)
            {
                pq.Enqueue((y, x), grid[y][x]);
            }
        }
        var dsu = new DSU(width * width);
        var sides = new List<(int y, int x)>()
        {
            (1,0), (-1,0), (0,1), (0,-1)
        };

        var startFlattened = FlattenIdx(0, 0, width);
        var endFlattened = FlattenIdx(width - 1, width - 1, width);

        while(pq.Count != 0)
        {
            pq.TryDequeue(out var p, out var height);
            foreach(var side in sides)
            {
                var curX = p.x + side.x;
                var curY = p.y + side.y;
                if(curX >= 0 && curX < width && curY >= 0 && curY < width
                    && grid[curY][curX] <= height)
                {
                    var pFlattened = FlattenIdx(p.y, p.x, width);
                    var curFlattened = FlattenIdx(curY, curX, width);

                    dsu.Union(pFlattened, curFlattened);
                    if (dsu.Find(pFlattened) == dsu.Find(startFlattened)
                        && dsu.Find(pFlattened) == dsu.Find(endFlattened))
                    {
                        return height;
                    }
                }
            }
        }
        
        return grid[width - 1][width - 1];
    }

    private int FlattenIdx(int y, int x, int width)
    {
        return y * width + x;
    }
}

public class DSU {

    private int[] ranks;
    private int[] parents;

    public DSU(int count)
    {
        ranks = Enumerable.Repeat(1, count).ToArray();
        parents = Enumerable.Range(0, count).ToArray();
    }

    public bool Union(int a, int b)
    {
        var parentA = Find(a);
        var parentB = Find(b);

        if(parentA == parentB)
        {
            return false;
        }

        if (ranks[parentA] > ranks[parentB])
        {
            parents[parentB] = parentA;
            ranks[parentA] += ranks[parentB];
        }
        else
        {
            parents[parentA] = parentB;
            ranks[parentB] += ranks[parentA];
        }
        return true;
    }

    public int Find(int a)
    {
        var parent = parents[a];
        var cur = a;
        while(cur != parent)
        {
            cur = parent;
            parent = parents[cur];
        }

        parents[a] = parent;
        return parent;
    }
}
