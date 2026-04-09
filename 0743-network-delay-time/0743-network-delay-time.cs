public class Solution {
    public int NetworkDelayTime(int[][] times, int n, int k) {
        const int MaxTime = 1000;
        var dist = Enumerable.Repeat(MaxTime, n).ToArray();
        dist[k - 1] = 0;
        for(int i = 0; i < n; i++)
        {
            var anyRelaxed = false;
            foreach(var edge in times)
            {
                var newDist = dist[edge[0] - 1] + edge[2];
                if(dist[edge[1] - 1] > newDist)
                {
                    anyRelaxed = true;
                    dist[edge[1] - 1] = newDist;
                }
            }
            if(!anyRelaxed)
            {
                break;
            }
        }

        var signalTime = dist.Max();
        return signalTime == MaxTime ? -1 : signalTime;
    }
}