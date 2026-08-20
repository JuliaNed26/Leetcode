public class Solution {
    private int[][] _dp;
    
    public int LongestCommonSubsequence(string text1, string text2) {
        _dp = Enumerable.Range(0, text1.Length)
                        .Select(_ => Enumerable.Repeat(-1, text2.Length).ToArray())
                        .ToArray();

        return Dfs(text1, text2, 0, 0);
    }

    private int Dfs(string text1, string text2, int i, int j) {
        if (i == text1.Length || j == text2.Length) {
            return 0;
        }
        if(_dp[i][j] != -1)
        {
            return _dp[i][j];
        }

        _dp[i][j] = text1[i] == text2[j]
                    ? 1 + Dfs(text1, text2, i + 1, j + 1)
                    : Math.Max(Dfs(text1, text2, i + 1, j),
                        Dfs(text1, text2, i, j + 1)); 

        return _dp[i][j];
    }
}
