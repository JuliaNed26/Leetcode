public class Solution {
    public IList<bool> CheckIfPrerequisite(int numCourses, int[][] prerequisites, int[][] queries) {
        var graph = Enumerable.Range(0, numCourses)
                                .Select(_ => new HashSet<int>())
                                .ToArray();

        var inDegrees = new int[numCourses];
        var sorted = new List<int>();
        foreach(var pair in prerequisites)
        {
            graph[pair[0]].Add(pair[1]);
            inDegrees[pair[1]]++;
        }
        var queue = new Queue<int>();
        var reachArr = Enumerable.Range(0, numCourses)
                                .Select(_ => new HashSet<int>())
                                .ToArray();
        for(int i = 0; i < inDegrees.Length; i++)
        {
            if(inDegrees[i] == 0)
            {
                GetReachability(i, graph, reachArr);
                queue.Enqueue(i);
            }
        }

        while(queue.Count() != 0)
        {
            var cur = queue.Dequeue();
            sorted.Add(cur);
            foreach(var next in graph[cur])
            {
                inDegrees[next]--;
                if(inDegrees[next] == 0)
                {
                    queue.Enqueue(next);
                }
            }
        }

        var resIdxs = new int[numCourses];
        for(int i = 0; i < numCourses; i++)
        {
            var course = sorted[i];
            resIdxs[course] = i;
        }

        var result = new List<bool>();
        foreach(var query in queries)
        {
            result.Add(resIdxs[query[0]] < resIdxs[query[1]] && reachArr[query[0]].Contains(query[1]));
        }

        return result;
    }

    private HashSet<int> GetReachability(int root, HashSet<int>[] graph, HashSet<int>[] reachArr)
    {
        foreach(var neighbour in graph[root])
        {
            reachArr[root].UnionWith(GetReachability(neighbour, graph, reachArr));
            reachArr[root].Add(neighbour);
        }

        return reachArr[root];
    }
}
