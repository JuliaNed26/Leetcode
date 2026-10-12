public class Solution {
    public bool CanJump(int[] nums) {
        bool[] dp = new bool[nums.Length];
        dp[nums.Length - 1] = true;
        for(int i = nums.Length - 2; i >= 0; i--)
        {
            var stepsToTheEnd = nums.Length - i - 1;
            if(nums[i] >= stepsToTheEnd)
            {
                dp[i] = true;
            }
            else
            {
                for(int j = i + 1; j <= i + nums[i]; j++)
                {
                    if(dp[j])
                    {
                        dp[i] = true;
                        break;
                    }
                }
            }
        }

        return dp[0];
    }
}
