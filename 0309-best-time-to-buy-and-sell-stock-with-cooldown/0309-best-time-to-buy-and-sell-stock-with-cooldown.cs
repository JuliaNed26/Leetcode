public class Solution {
    private int[][] _dp;

    public int MaxProfit(int[] prices) {
        var length = prices.Length;
        _dp = Enumerable.Range(0, length + 2).Select(_ => new int[2]).ToArray();
        for(int i = length - 1; i >= 0; i--)
        {
            // buying allowed
            _dp[i][1] = Math.Max(
                _dp[i + 1][1], // skip
                _dp[i + 1][0] - prices[i] // buy
            );

            // hold
            _dp[i][0] = Math.Max(
                _dp[i + 1][0], // skip
                _dp[i + 2][1] + prices[i] // sell
            );
        }

        return _dp[0][1];
    }
}