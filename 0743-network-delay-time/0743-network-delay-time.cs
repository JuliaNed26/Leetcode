public class Solution {
    public int NetworkDelayTime(int[][] times, int n, int k) {
        const int MaxTime = 1000;
        var distMatrix = Enumerable.Range(0, n)
                                    .Select(_ => Enumerable.Repeat(MaxTime, n).ToArray())
                                    .ToArray();
        foreach(var edge in times)
        {
            distMatrix[edge[0] - 1][edge[1] - 1] = edge[2];
        }
        
        var visitedVertexes = new HashSet<int>();
        var minDist = new int[n];
        for(int i = 0; i < n; i++)
        {
            minDist[i] = distMatrix[k-1][i];
        }
        minDist[k-1] = 0;
        visitedVertexes.Add(k - 1);

        while(visitedVertexes.Count != n)
        {
            var curMinDist = MaxTime + 1;
            var nextVertex = -1;
            for(int i = 0; i < n; i++)
            {
                if(!visitedVertexes.Contains(i) && minDist[i] < curMinDist)
                {
                    nextVertex = i;
                    curMinDist = minDist[i];
                }
            }
            
            visitedVertexes.Add(nextVertex);

            for(int i = 0; i < n; i++)
            {
                if(!visitedVertexes.Contains(i))
                {
                    minDist[i] = (int)Math.Min(
                                        minDist[i],
                                        minDist[nextVertex]+ distMatrix[nextVertex][i]);
                }
            }
        }

        var signalTime = minDist.Max();
        return signalTime == MaxTime ? -1 : signalTime;
    }
}