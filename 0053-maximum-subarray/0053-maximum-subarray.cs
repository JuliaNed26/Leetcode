public class Solution {
    int[] _nums;

    public int MaxSubArray(int[] nums) {
        _nums = nums;
        return DFS(0, nums.Length - 1);
    }

    private int DFS(int l, int r)
    {
        if(r < l)
        {
            return -10000000;
        }

        var m = l + (r - l) / 2;
        // array includes the middle
        var sum = _nums[m];
        var curSum = 0;
        for(var i = m - 1; i >= l; i--)
        {
            curSum += _nums[i];
            sum = Math.Max(sum, _nums[m] + curSum);
        }
        var prevSum = sum;
        curSum = 0;
        for(var i = m + 1; i <= r; i++)
        {
            curSum += _nums[i];
            sum = Math.Max(sum, prevSum + curSum);
        }

        return Math.Max(sum,
            Math.Max(
                DFS(l, m - 1), // completely on the left
                DFS(m + 1, r) // completely on the right
            )
        );
    }
}