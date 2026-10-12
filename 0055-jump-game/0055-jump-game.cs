public class Solution {
    public bool CanJump(int[] nums) {
        var maxSteps = 0;
        for(int i = 0; i < nums.Length; i++)
        {
            if(maxSteps < i)
            {
                return false;
            }

            maxSteps = Math.Max(maxSteps, i + nums[i]);
        }

        return true;
    }
}