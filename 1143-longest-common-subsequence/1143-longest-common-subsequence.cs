public class Solution {
    private int[] _dp;
    
    public int LongestCommonSubsequence(string text1, string text2) {
        _dp = Enumerable.Repeat(0, text2.Length + 1).ToArray();

        for(int i = text1.Length - 1; i >= 0; i--)
        {
            var prevValue = 0;
            for(int j = text2.Length - 1; j >= 0; j--)    
            {
                var temp = _dp[j];
                _dp[j] = text1[i] == text2[j] 
                            ? 1 + prevValue
                            : Math.Max(_dp[j], _dp[j + 1]);
                prevValue = temp;
            }
        }

        return _dp[0];
    }
}