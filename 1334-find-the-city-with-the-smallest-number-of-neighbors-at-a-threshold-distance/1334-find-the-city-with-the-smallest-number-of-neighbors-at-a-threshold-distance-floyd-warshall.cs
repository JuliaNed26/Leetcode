public class Solution {
    const int MaxDist = int.MaxValue;

    public int FindTheCity(int n, int[][] edges, int distanceThreshold) {
        var dist = Enumerable.Range(0,n)
                                .Select(x => {
                                    var nodeDist = Enumerable.Repeat(MaxDist, n).ToArray();
                                    nodeDist[x] = 0;
                                    return nodeDist;
                                }).ToArray();

        foreach(var edge in edges)
        {
            dist[edge[0]][edge[1]] = edge[2];
            dist[edge[1]][edge[0]] = edge[2];
        }

        for(int i = 0; i < n; i++)
        {
            for(int y = 0; y < n; y++)
            {
                if(y == i)
                {
                    continue;
                }

                for (int x = y + 1; x < n; x++)
                {
                    if(x == i
                        || dist[y][i] == MaxDist
                        || dist[i][x] == MaxDist)
                    {
                        continue;
                    }

                    var newDist = dist[y][i] + dist[i][x];
                    if (newDist < dist[y][x])
                    {
                        dist[y][x] = newDist;
                        dist[x][y] = newDist; 
                    }
                }
            }
        }

        return dist.Select((x, i) => {
                        var nodesCount = x.Where(d => d <= distanceThreshold)
                                            .ToList()
                                            .Count - 1;
                        return new 
                        {
                            NodesCount = nodesCount,
                            Node = i
                        };
                    }).OrderBy(x => x.NodesCount)
                    .ThenByDescending(x => x.Node)
                    .First().Node;
    }
}
