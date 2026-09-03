public class Solution {

    public int Change(int amount, int[] coins) {
        Array.Sort(coins);
        var dp = Enumerable.Range(0,2).Select(_ => new int[amount + 1]).ToArray();
        for(int i = 0; i < 2; i++)
        {
            dp[i][0] = 1;
        }

        for(int i = coins.Length - 1; i >= 0; i--)
        {
            for(int k = 1; k <= amount; k++)
            {
                dp[0][k] = k < coins[i]
                            ? 0
                            : dp[1][k] + dp[0][k - coins[i]];
            }

            dp[0].CopyTo(dp[1], 0);
        }

        return dp[0][amount];
    }
}