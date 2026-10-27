public class Solution {
    public int[] CountBits(int n) {
        var results = new int[n + 1];
        results[0] = 0;
        for(int i = 1; i <= n; i++)
        {
            int mask = 1;
            var curRes = results[i - 1];
            while((i - 1 & mask) != 0)
            {
                curRes--;
                mask = mask << 1;
            }
            results[i] = curRes + 1;
        }

        return results;
    }
}