public class Solution {
    int[] _coins;
    Dictionary<(int left, int lastIdx), int> _dp;

    public int Change(int amount, int[] coins) {
        _coins = coins;
        Array.Sort(_coins);
        _dp = new Dictionary<(int left, int lastIdx), int>();
        
        return Dfs(amount, 0);
    }

    private int Dfs(int left, int idx)
    {
        if(left == 0)
        {
            return 1;
        }

        if(idx >= _coins.Length || left < 0)
        {
            return 0;
        }

        if(_dp.TryGetValue((left, idx), out var result))
        {
            return result;
        }

        _dp[(left, idx)] = Dfs(left - _coins[idx], idx) + Dfs(left, idx + 1);
        return _dp[(left, idx)];
    }
}