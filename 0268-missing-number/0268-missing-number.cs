public class Solution {
    public int MissingNumber(int[] nums) {
        // we have duplicates in nums and indexes, but one number is not duplicated
        // it will be our result.
        // since with XOR operation number cancels itself - a XOR a = 0, we are using it
        // and missing number will not be cancelled
        var res = nums.Length;
        for(int i = 0; i < nums.Length; i++)
        {
            res ^= i ^ nums[i];
        }

        return res;
    }
}