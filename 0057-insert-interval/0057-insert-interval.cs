public class Solution {
    public int[][] Insert(int[][] intervals, int[] newInterval) {
        var result = new List<int[]>();
        
        for(int i = 0; i < intervals.Length; i++) 
        {
            var interval = intervals[i];
            if(i == intervals.Length || interval[0] > newInterval[1])
            {
                result.Add(newInterval);
                result.AddRange(intervals.AsEnumerable().Skip(i).ToArray());
                return result.ToArray();
            }
            else if(interval[1] < newInterval[0])
            {
                result.Add(interval);
                continue;
            }
            else
            {
                newInterval[0] = Math.Min(newInterval[0], interval[0]);
                newInterval[1] = Math.Max(newInterval[1], interval[1]);
                continue;
            }
        }

        result.Add(newInterval);
        return result.ToArray();
    }
}