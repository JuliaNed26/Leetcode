/**
 * Definition of Interval:
 * public class Interval {
 *     public int start, end;
 *     public Interval(int start, int end) {
 *         this.start = start;
 *         this.end = end;
 *     }
 * }
 */

public class Solution {
    public int MinMeetingRooms(List<Interval> intervals) {
        intervals = intervals.OrderBy(i => i.start).ToList();
        var minHeap = new PriorityQueue<int, int>();
        for(int i = 0; i < intervals.Count; i++)
        {
            if(minHeap.Count != 0 && minHeap.Peek() <= intervals[i].start)
            {
                minHeap.Dequeue();
            }

            minHeap.Enqueue(intervals[i].end, intervals[i].end);
        }

        return minHeap.Count;
    }
}
