public class Solution {
    public int NumIslands(char[][] grid) {
        int width = grid[0].Length;
        int height = grid.Length;
        var islandCount = width * height;
        var dsu = new DSU(islandCount);

        for(int i = 0; i < height; i++)
        {
            for(int j = 0; j < width; j++)
            {
                var curValue = grid[i][j];
                if(curValue == '0')
                {
                    islandCount--;
                    continue;
                }

                if(j + 1 < width
                    && grid[i][j + 1] != '0'
                    && dsu.Union(FlattenIndex(j, i), FlattenIndex(j + 1, i)))
                {
                    islandCount--;
                }

                if(i + 1 < height
                    && grid[i + 1][j] != '0'
                    && dsu.Union(FlattenIndex(j, i), FlattenIndex(j, i + 1)))
                {
                    islandCount--;
                }
            }
        }

        return islandCount;

        int FlattenIndex(int x, int y)
        {
            return y * width + x;
        }
    }

    class DSU
    {
        private int[] parents;
        private int[] sizes;

        public DSU(int count)
        {
            parents = new int[count];
            for(int i = 0; i < count; i++)
            {
                parents[i] = i;
            }

            sizes = new int[count];
            Array.Fill(sizes, 1);
        }

        public bool Union(int a, int b)
        {
            var parA = Find(a);
            var parB = Find(b);

            if(parA == parB)
            {
                return false;
            }

            if(sizes[parA] > sizes[parB])
            {
                parents[parB] = parA;
                sizes[parA] += sizes[parB];
                return true;
            }

            parents[parA] = parB;
            sizes[parB] += sizes[parA];
            return true;
        }

        public int Find(int a)
        {
            if(parents[a] == a)
            {
                return a;
            }

            var parent = Find(parents[a]);
            parents[a] = parent;
            return parent;
        }
    }
}
