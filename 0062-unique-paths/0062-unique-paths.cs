public class Solution {
    public int UniquePaths(int m, int n) {
        var pathsArr = Enumerable.Range(0, m)
                                .Select(_ => new int[n])
                                .ToArray();
        var greaterLength = Math.Max(m, n);
        for(int i = 0; i < greaterLength; i++) 
        {
            if(i < m)
            {
                pathsArr[i][0] = 1;
            }
            if(i < n)
            {
                pathsArr[0][i] = 1;
            }
        }

        for(int y = 1; y < m; y++)
        {
            for(int x = 1; x < n; x++)
            {
                pathsArr[y][x] = pathsArr[y-1][x] + pathsArr[y][x-1];
            }
        }

        return pathsArr[m-1][n-1];
    }
}