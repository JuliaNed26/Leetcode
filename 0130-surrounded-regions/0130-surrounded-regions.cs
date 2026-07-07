public class Solution {
    public void Solve(char[][] board) {
        const char WATER = 'X';
        const char LAND = 'O';

        var width = board[0].Length;
        var height = board.Length;

        int dummyNode = width * height; 
        var dsu = new DSU(width * height + 1);

        var sides = new (int y, int x)[] {(1,0), (0,1), (-1,0), (0,-1)};
        for(int i = 0; i < height; i++)
        {
            for(int j = 0; j < width; j++)
            {
                if(board[i][j] == LAND)
                {
                    foreach(var side in sides)
                    {
                        var curX = j + side.x;
                        var curY = i + side.y;
                        var flattenedCell = FlattenIdx(i, j);
                        var flattenedNeighbour =FlattenIdx(curY, curX);

                        if(curX < 0 || curY < 0 || curX >= width || curY >= height)
                        {
                            dsu.Union(flattenedCell, dummyNode);
                        }
                        else if(board[curY][curX] == LAND)
                        {
                            dsu.Union(flattenedCell, flattenedNeighbour);
                        }
                    }
                }
            }
        }

        for(int i = 0; i < height; i++)
        {
            for(int j = 0; j < width; j++)
            {
                if(board[i][j] == LAND)
                {
                    var flattenedCell = FlattenIdx(i, j);
                    if(dsu.Find(dummyNode) != dsu.Find(flattenedCell))
                    {
                        board[i][j] = WATER;
                    }
                }
            }
        }

        int FlattenIdx(int y, int x)
        {
            return y * width + x;
        }
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
}