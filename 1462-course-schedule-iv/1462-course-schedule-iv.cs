public class Solution {
    public IList<bool> CheckIfPrerequisite(int numCourses, int[][] prerequisites, int[][] queries) {
        var graph = Enumerable.Range(0, numCourses)
                                .Select(_ => new HashSet<int>())
                                .ToArray();

        var inDegrees = new int[numCourses];
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
                queue.Enqueue(i);
            }
        }

        var isPrereq = Enumerable.Range(0, numCourses)
                                .Select(_ => new HashSet<int>())
                                .ToArray();

        while(queue.Count() != 0)
        {
            var cur = queue.Dequeue();
            foreach(var next in graph[cur])
            {
                isPrereq[next].Add(cur);
                isPrereq[next].UnionWith(isPrereq[cur]);
                inDegrees[next]--;
                if(inDegrees[next] == 0)
                {
                    queue.Enqueue(next);
                }
            }
        }

        var result = new List<bool>();
        foreach(var query in queries)
        {
            result.Add(isPrereq[query[1]].Contains(query[0]));
        }

        return result;
    }
}
