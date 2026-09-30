public class Solution {
    public int MaxSubArray(int[] nums) {
        var res = nums[0];
        var curMax = nums[0];
        for(int i = 1; i < nums.Length; i++)
        {
            curMax = Math.Max(curMax + nums[i], nums[i]);
            res = Math.Max(res, curMax);
        }

        return res;
    }
}