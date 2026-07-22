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
            graph[0][i] = -1;
            graph[i][0] = -1;
        }

        for(int i = 1; i <= n; i++)
        {
            var curIteration = CopyPreviousResult(graph);
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
                        curIteration[y][x] = curTime;
                    }
                }
            }

            graph = curIteration;
        }

        var maxSignalTime = graph[k].Max();
        return maxSignalTime == MAX_TIME_VALUE ? -1 : maxSignalTime;
    }

    private int[][] CopyPreviousResult(int[][] previousArr) =>
        previousArr.Select(arr => {
                var copiedArr = new int[arr.Length];
                arr.CopyTo(copiedArr, 0);
                return copiedArr;
            }).ToArray();
}