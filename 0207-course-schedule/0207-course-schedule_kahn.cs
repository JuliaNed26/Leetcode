public class Solution {
    public bool CanFinish(int numCourses, int[][] prerequisites) {
        var graph = Enumerable.Range(0, numCourses)
                            .Select(_ => new List<int>())
                            .ToList();
        var indegrees = new int[numCourses];
        var nodesWithZeroInDegrees = Enumerable.Range(0, numCourses).ToHashSet();

        foreach(var prerequisite in prerequisites)
        {
            graph[prerequisite[1]].Add(prerequisite[0]);
            ++indegrees[prerequisite[0]];
            nodesWithZeroInDegrees.Remove(prerequisite[0]);
        }

        var queue = new Queue<int>(nodesWithZeroInDegrees);
        int coursesPassed = 0;

        while(queue.Count != 0)
        {
            var curCourse = queue.Dequeue();
            coursesPassed++;
            foreach(var nextCourse in graph[curCourse])
            {
                indegrees[nextCourse]--;
                if (indegrees[nextCourse] == 0)
                {
                    queue.Enqueue(nextCourse);
                }
            }
        }

        return coursesPassed == numCourses;
    }
}
