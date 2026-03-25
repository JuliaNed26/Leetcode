public class Solution {
    public int[] FindRedundantConnection(int[][] edges) {
        var adjList = new List<int>[edges.Length + 1];
        var degree = new int[edges.Length + 1];
        foreach(var edge in edges)
        {
            degree[edge[0]]++;
            degree[edge[1]]++;
            adjList[edge[0]] ??= new List<int>();
            adjList[edge[1]] ??= new List<int>();
            adjList[edge[0]].Add(edge[1]);
            adjList[edge[1]].Add(edge[0]);
        }

        var cycleNodes = GetCycleNodes(degree, adjList);
        for(int i = edges.Length - 1; i >= 0; i--)
        {
            var edge = edges[i];
            if(cycleNodes.Contains(edge[0]) && cycleNodes.Contains(edge[1]))
            {
                return edge;
            }
        }

        return [0, 0];
    }

    public HashSet<int> GetCycleNodes(int[] degree, List<int>[] adjList)
    {
        var queue = new Queue<int>();
        for(int i = 0; i < degree.Length; i++)
        {
            if(degree[i] == 1)
            {
                queue.Enqueue(i);
            }
        }

        while(queue.Count != 0)
        {
            var node = queue.Dequeue();
            foreach(var neighbour in adjList[node])
            {
                if(degree[neighbour] == 0)
                {
                    continue;
                }

                degree[neighbour]--;
                
                if(degree[neighbour] == 1)
                {
                    queue.Enqueue(neighbour);
                }
            }

            degree[node]--;
        }

        var cycleNodes = new HashSet<int>();
        for(int i = 0; i < degree.Length; i++)
        {
            if(degree[i] > 0)
            {
                cycleNodes.Add(i);
            }
        }

        return cycleNodes;
    }
}