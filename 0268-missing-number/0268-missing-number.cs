public class Solution {
    public int MissingNumber(int[] nums) {
        int sum = Enumerable.Range(0, nums.Length + 1).Sum();
        foreach(var num in nums)
        {
            sum -= num;
        }

        return sum;
    }
}