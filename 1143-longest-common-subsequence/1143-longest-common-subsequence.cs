public class Solution {
    private int[][] _dp;
    
    public int LongestCommonSubsequence(string text1, string text2) {
        _dp = Enumerable.Range(0, text1.Length + 1)
                        .Select(_ => Enumerable.Repeat(0, text2.Length + 1).ToArray())
                        .ToArray();

        for(int i = text1.Length - 1; i >= 0; i--)
        {
            for(int j = text2.Length - 1; j >= 0; j--)    
            {
                _dp[i][j] = text1[i] == text2[j] 
                            ? 1 + _dp[i + 1][j + 1]
                            : Math.Max(_dp[i + 1][j], _dp[i][j + 1]);
            }
        }

        return _dp[0][0];
    }
}