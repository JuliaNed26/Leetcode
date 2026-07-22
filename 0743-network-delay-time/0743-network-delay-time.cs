public class Solution {
    private const int MAX_TIME_VALUE = 20000;

    public int NetworkDelayTime(int[][] times, int n, int k) {
        var graph = Enumerable.Range(0, n + 1).Select(_ =>
                Enumerable.Repeat(MAX_TIME_VALUE, n + 1).ToArray())
            .ToArray();

        foreach(var time in times) 
        {
            graph[time[0]][time[1]] = time[2];
        }

        for(int i = 1; i <= n; i++)
        {
            graph[i][i] = 0;
        }

        for(int i = 1; i <= n; i++)
        {
            for(int y = 1; y <= n; y++)
            {
                if(y == i)
                {
                    continue;
                }

                for(int x = 1; x <= n; x++)
                {
                    if(y == x || x == i)
                    {
                        continue;
                    }

                    var curTime = graph[y][i] + graph[i][x];
                    if(curTime < graph[y][x])
                    {
                        graph[y][x] = curTime;
                    }
                }
            }
        }

        var maxSignalTime = graph[k].Skip(1).Max();
        return maxSignalTime == MAX_TIME_VALUE ? -1 : maxSignalTime;
    }
}