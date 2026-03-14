public class Solution {
    public int LastStoneWeight(int[] stones) {
        var maxWeight = stones.Max();
        var bucket = new int[maxWeight + 1];
        foreach(var stone in stones)
        {
            bucket[stone]++;
        }

        int r = bucket.Length - 1;
        int l = bucket.Length - 1;
        while(true)
        {
            while (r >= 0 && bucket[r] == 0)
            {
                r--;
            }

            if (r < 0)
            {
                break;
            }

            if (bucket[r] % 2 == 0)
            {
                bucket[r] = 0;
                continue;
            }

            bucket[r] = 1;
            l = r - 1;

            while (l >= 0 && bucket[l] == 0)
            {
                l--;
            }

            if (l < 0)
            {
                break;
            }

            bucket[r]--;
            bucket[l]--;
            bucket[r - l]++;
        }

        return r > 0 ? r : 0;
    }
}