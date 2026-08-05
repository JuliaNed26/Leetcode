public class Solution {
    public int MinimumEffortPath(int[][] heights) {
        var width = heights[0].Length;
        var height = heights.Length;

        var pq = new PriorityQueue<(int to, int from), int>();
        var sides = new List<(int x, int y)>() {(1,0), (0,1)};
        for(int i = 0; i < height; i++)
        {
            for(int j = 0; j < width; j++)
            {
                var source = FlattenIdx(j, i, width);
                foreach(var side in sides)
                {
                    var neighX = side.x + j;
                    var neighY = side.y + i;
                    if(neighX >= 0 && neighX < width && neighY >= 0 && neighY < height)
                    {
                        var dest = FlattenIdx(neighX, neighY, width);
                        var effort = Math.Abs(heights[neighY][neighX] - heights[i][j]);
                        pq.Enqueue((source, dest), effort);
                    }
                }
            }
        }

        var dsu = new DSU(height * width);
        var lastNodeIdx = height * width - 1;
        var firstNodeIdx = 0;
        while(pq.Count != 0)
        {
            pq.TryDequeue(out var curEdge, out var effort);
            dsu.Union(curEdge.from, curEdge.to);
            if(dsu.Find(lastNodeIdx) == dsu.Find(firstNodeIdx))
            {
                return effort;
            }
        }

        return 0;
    }

    private int FlattenIdx(int x, int y, int width)
    {
        return y * width + x;
    }
}

public class DSU
{
    int[] _ranks;
    int[] _parents;

    public DSU(int elementsCount)
    {
        _ranks = Enumerable.Repeat(1, elementsCount).ToArray();
        _parents = Enumerable.Range(0, elementsCount).ToArray();
    }

    public bool Union(int first, int second)
    {
        var parFirst = Find(first);
        var parSecond = Find(second);
        if(parFirst == parSecond)
        {
            return false;
        }

        if(_ranks[parFirst] > _ranks[parSecond])
        {
            _parents[parSecond] = parFirst;
            _ranks[parFirst] += _ranks[parSecond];
        }
        else
        {
            _parents[parFirst] = parSecond;
            _ranks[parSecond] += _ranks[parFirst];
        }

        return true;
    }

    public int Find(int element)
    {
        var curParent = _parents[element];
        var curElement = element;
        while(curParent != curElement)
        {
            curElement = curParent;
            curParent = _parents[curParent];
        }

        _parents[element] = curParent;
        return curParent;
    }
}