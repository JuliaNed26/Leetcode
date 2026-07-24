public class Solution {
    private const int MAX_TIME_VALUE = 20000;

    public int NetworkDelayTime(int[][] times, int n, int k) {
        var distances = Enumerable.Repeat(MAX_TIME_VALUE, n + 1).ToArray();
        distances[k] = 0;
        for(int i = 0; i < n; i++)
        {
            var updated = false;
            foreach(var time in times)
            {
                var newDist = distances[time[0]] + time[2];
                if(newDist < distances[time[1]])
                {
                    distances[time[1]] = newDist;
                    updated = true;
                }
            }
            if(!updated)
            {
                break;
            }
        }

        var result = distances.Skip(1).Max();
        return result == MAX_TIME_VALUE ? -1 : result;
    }
}