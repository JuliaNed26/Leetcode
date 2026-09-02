public class Solution {

    public int Change(int amount, int[] coins) {
        Array.Sort(coins);
        var dp = Enumerable.Range(0, amount + 1).Select(_ => new int[coins.Length]).ToArray();
        for(int i = 0; i < coins.Length; i++)
        {
            dp[0][i] = 1;
        }

        for(int y = 1; y <= amount; y++)
        {
            int prevRes = 0;
            for(int x = coins.Length - 1; x >= 0; x--)
            {
                if(coins[x] > y)
                {
                    continue;
                }

                dp[y][x] = dp[y - coins[x]][x] + prevRes;
                prevRes = dp[y][x];
            }
        }

        return dp[amount][0];
    }
}
