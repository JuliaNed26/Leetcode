public class Solution {
    public int NetworkDelayTime(int[][] times, int n, int k) {
        const int MaxTime = 1000;

        var distMatrix = Enumerable.Range(0, n + 1)
                                    .Select(_ => Enumerable.Repeat(MaxTime, n + 1).ToArray())
                                    .ToArray();

        foreach(var edge in times)
        {
            distMatrix[edge[0]][edge[1]] = edge[2];
        }

        for(int i = 1; i < n + 1; i++)
        {
            distMatrix[i][i] = 0;
        }

        for(int i = 1; i < n + 1; i++)
        {
            for(int x = 1; x < n + 1; x++)
            {
                for(int y = 1; y < n + 1; y++)
                {
                    distMatrix[x][y] = (int)Math.Min(
                                            distMatrix[x][y],
                                            distMatrix[x][i] + distMatrix[i][y]);
                }
            }
        }

        var signalTime = distMatrix[k].Skip(1).Max();
        return signalTime == MaxTime ? -1 : signalTime;
    }
}