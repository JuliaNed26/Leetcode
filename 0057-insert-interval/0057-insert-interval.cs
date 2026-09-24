public class Solution {
    private int[][] _intervals;

    public int[][] Insert(int[][] intervals, int[] newInterval) {
        _intervals = intervals;     
        int mergeStart = FindIdx(newInterval[0]);

        mergeStart = mergeStart >= 1 && _intervals[mergeStart - 1][1] >= newInterval[0]
                        ? mergeStart - 1
                        : mergeStart;
        
        var result = new List<int[]>();
        // copy till merge start
        for(int i = 0; i < mergeStart; i++)
        {
            result.Add(_intervals[i]);
        }

        // insert
        var endIdx = mergeStart;
        
        if(mergeStart >= _intervals.Length || _intervals[mergeStart][0] > newInterval[1])
        {
            result.Add(newInterval);
        }
        else
        {
            var leftBorder = Math.Min(newInterval[0], _intervals[mergeStart][0]);
            for(int i = mergeStart; i < _intervals.Length; i++)
            {
                if(_intervals[i][0] > newInterval[1])
                {
                    break;
                }

                endIdx++;
            }
            var rightBorder = endIdx - 1 < _intervals.Length
                                ? Math.Max(_intervals[endIdx - 1][1], newInterval[1])
                                : newInterval[1];
            result.Add([leftBorder, rightBorder]);
        }

        // copy rest
        for(int i = endIdx; i < _intervals.Length; i++)
        {
            result.Add(_intervals[i]);
        }
        
        return result.ToArray();
    }

    private int FindIdx(int num)
    {
        var l = 0;
        var r = _intervals.Length - 1;
        var middle = 0;
        while(l <= r)
        {
            middle = l + (r - l) / 2;
            var leftBorder = _intervals[middle][0];
            var rightBorder = _intervals[middle][1];
            if(num >= leftBorder && num <= rightBorder)
            {
                return middle + 1;
            }
            if(num < leftBorder)
            {
                r = middle - 1;
            }
            else if(num > rightBorder)
            {
                l = middle + 1;
            }
        }

        return l;
    }
}