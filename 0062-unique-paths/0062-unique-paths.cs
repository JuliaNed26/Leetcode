public class Solution {
    public int UniquePaths(int m, int n) {
        var pathsArr = Enumerable.Range(0, m)
                                .Select(_ => Enumerable.Repeat(-1, n).ToArray())
                                .ToArray();

        var sides = new List<(int x, int y)>()
        {
            (1,0), (0,1)
        };

        pathsArr[m-1][n-1] = 1;
        return Dfs(0,0);

        int Dfs(int x, int y)
        {
            if(x == n - 1 && y == m - 1)
            {
                return 1;
            }

            var result = 0;
            foreach(var side in sides)
            {
                var curX = side.x + x;
                var curY = side.y + y;
                if(curX >= 0 && curX < n && curY >= 0 && curY < m)
                {
                    result += pathsArr[curY][curX] != -1
                                ? pathsArr[curY][curX]
                                : Dfs(curX, curY);
                }
            }

            pathsArr[y][x] = result;
            return result;
        }
    }
}