public class Solution {
    private int[] _prices;
    private Dictionary<(int idx, bool canBuy), int> _dp;

    public int MaxProfit(int[] prices) {
        _prices = prices;
        _dp = new Dictionary<(int idx, bool canBuy), int>(); 
        return Dfs(0, true); 
    }

    private int Dfs(int idx, bool canBuy)
    {
        if(idx >= _prices.Length)
        {
            return 0;
        }
        if(_dp.TryGetValue((idx, canBuy), out var curProfit))
        {
            return curProfit;
        }

        var cooldown = Dfs(idx + 1, canBuy);
        if(canBuy)
        {
            var buy = Dfs(idx + 1, false) - _prices[idx];
            curProfit = Math.Max(buy, cooldown);
        }
        else
        {
            var sell = Dfs(idx + 2, true) + _prices[idx];
            curProfit = Math.Max(sell, cooldown);
        }
        _dp[(idx, canBuy)] = curProfit;
        return curProfit;
    }
}