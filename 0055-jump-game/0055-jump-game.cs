public class Solution {
    public bool CanJump(int[] nums) {
        var maxSteps = 0;
        for(int i = 0; i < nums.Length; i++)
        {
            if(maxSteps < i)
            {
                return false;
            }
            if(maxSteps >= nums.Length - 1)
            {
                return true;
            }

            maxSteps = Math.Max(maxSteps, i + nums[i]);
        }

        return true;
    }
}