public class Solution {
    public IList<bool> CheckIfPrerequisite(int numCourses, int[][] prerequisites, int[][] queries) {
        var graph = Enumerable.Range(0, numCourses)
                              .Select(_ => new bool[numCourses])
                              .ToArray();
        foreach(var prereqPair in prerequisites)
        {
            graph[prereqPair[0]][prereqPair[1]] = true;
        }
        for(int i = 0; i < numCourses; i++)
        {
            graph[i][i] = true;
        }

        for(int i = 0; i < numCourses; i++)
        {
            for(int y = 0; y < numCourses; y++)
            {
                if(y == i)
                {
                    continue;
                }

                for(int x = 0; x < numCourses; x++)
                {
                    if(x == i)
                    {
                        continue;
                    }

                    graph[y][x] = graph[y][x] || (graph[y][i] && graph[i][x]);
                }
            }
        }

        var result = new List<bool>();
        foreach(var query in queries)
        {
            result.Add(graph[query[0]][query[1]]);
        }

        return result;
    }
}
