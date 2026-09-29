public class Solution {
    public int EraseOverlapIntervals(int[][] intervals) {
        intervals = intervals.OrderBy(i => i[1]).ThenBy(i => i[0]).ToArray();
        int removeCount = 0;
        var toCompare = 0;
        for(int i = 1; i < intervals.Length; i++)
        {
            if(intervals[i][0] < intervals[toCompare][1])
            {
                removeCount++;
            }
            else
            {
                toCompare = i;
            }
        }

        return removeCount;
    }
}
