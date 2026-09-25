public class Solution {
    public int[][] Merge(int[][] intervals) {
        var map = new SortedDictionary<int,int>();
        foreach(var curInterval in intervals)
        {
            map[curInterval[0]] = map.ContainsKey(curInterval[0]) ? map[curInterval[0]] + 1 : 1;
            map[curInterval[1]] = map.ContainsKey(curInterval[1]) ? map[curInterval[1]] - 1 : -1;
        }

        var result = new List<int[]>();

        var overlappingCount = 0;
        var interval = new int[2];
        foreach(var pointWithOverlapsCount in map)
        {
            if(overlappingCount == 0)
            {
                interval[0] = pointWithOverlapsCount.Key;
            }
            overlappingCount += pointWithOverlapsCount.Value;
            if(overlappingCount == 0)
            {
                interval[1] = pointWithOverlapsCount.Key;
                result.Add(interval);
                interval = new int[2];
            }
        }

        return result.ToArray(); 
    }
}
