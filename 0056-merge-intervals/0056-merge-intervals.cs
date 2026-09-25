public class Solution {
    public int[][] Merge(int[][] intervals) {
        intervals = intervals.OrderBy(i => i[0]).ThenBy(i => i[1]).ToArray();
        var result = new List<int[]>();
        result.Add(intervals[0]);
        for(int i = 1; i < intervals.Length; i++)
        {
            var prevInterval = result.Last();
            if(intervals[i][0] > prevInterval[1])
            {
                result.Add(intervals[i]);
            }
            else
            {
                var leftBound = Math.Min(intervals[i][0], prevInterval[0]);
                var rightBound = Math.Max(intervals[i][1], prevInterval[1]);
                result[result.Count - 1] = [leftBound, rightBound];
            }
        }

        return result.ToArray(); 
    }
}