public class Solution {
    public int MaxAreaOfIsland(int[][] grid) {
       var width = grid[0].Length;
       var height = grid.Length;
       var dsu = new DSU(width * height);
       bool anyIslands = false;
       for(int i = 0; i < height; i++) 
       {
            for(int k = 0; k < width; k++)
            {
                var curElement = grid[i][k];
                if(curElement == 0)
                {
                    continue;
                }

                anyIslands = true;
                if(k < width - 1 && grid[i][k + 1] == 1)
                {
                    dsu.Union(FlattenIdx(k, i, width), FlattenIdx(k + 1, i, width));
                }
                if(i < height - 1 && grid[i + 1][k] == 1)
                {
                    dsu.Union(FlattenIdx(k, i, width), FlattenIdx(k, i + 1, width));
                }
            }
       }

       return anyIslands ? dsu.GetMaxRank() : 0;
    }

    private int FlattenIdx(int x, int y, int width)
    {
        return x + y * width;
    }
}

public class DSU
{
    private int[] parents;
    private int[] ranks;

    public DSU(int count)
    {
        parents = Enumerable.Range(0, count).ToArray();
        ranks = Enumerable.Repeat(1, count).ToArray();
    }

    public bool Union(int a, int b)
    {
        var parA = Find(a);
        var parB = Find(b);
        if(parA == parB)
        {
            return false;
        }

        if(ranks[parB] > ranks[parA])
        {
            parents[parA] = parB;
            ranks[parB] += ranks[parA];
        }
        else
        {
            parents[parB] = parA;
            ranks[parA] += ranks[parB];
        }

        return true;
    }

    public int Find(int a)
    {
        var curParent = parents[a];
        while(curParent != parents[curParent])
        {
            curParent = parents[curParent];
        }
        parents[a] = curParent;
        return curParent;
    }

    public int GetMaxRank()
    {
        return ranks.Max();
    }
}
