public class Solution {
    public bool CanFinish(int numCourses, int[][] prerequisites) {
        Dictionary<int, List<int>> graph = Enumerable.Range(0, numCourses)
                                                    .ToDictionary(i => i, _ => new List<int>());
        foreach(var prerequisite in prerequisites)
        {
            graph[prerequisite[1]].Add(prerequisite[0]);
        }

        HashSet<int> visited = [];
        for(int i = 0; i < numCourses; i++)
        {
            if (!Dfs(i))
            {
                return false;
            }
        }

        return true;

        bool Dfs(int i)
        {
            if (visited.Contains(i))
            {
                return false;
            }

            if (graph[i].Count == 0)
            {
                return true;
            }

            visited.Add(i);

            foreach(var neighbour in graph[i])
            {
                if (!Dfs(neighbour))
                {
                    return false;
                }
            }

            visited.Remove(i);
            graph[i] = [];
            return true;
        }
    }
}
