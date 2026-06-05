public class Solution {
    public int[] FindOrder(int numCourses, int[][] prerequisites) {
        var graph = Enumerable.Range(0, numCourses)
                                .Select(_ => new List<int>(numCourses))
                                .ToArray();
        var inDegrees = Enumerable.Repeat(0, numCourses).ToArray();
        foreach(var course in prerequisites)
        {
            inDegrees[course[0]]++;
            graph[course[1]].Add(course[0]);
        }
        var nodesWithZeroInDegree = inDegrees.Select((value, idx) => new {value, idx})
                                                .Where(pair => pair.value == 0)
                                                .Select(pair => pair.idx)
                                                .ToList();
        var result = new List<int>(numCourses);
        var queue = new Queue<int>(nodesWithZeroInDegree);
        while(queue.Count != 0)
        {
            var curNode = queue.Dequeue();
            result.Add(curNode);
            foreach(var neighbour in graph[curNode])
            {
                inDegrees[neighbour]--;
                if(inDegrees[neighbour] == 0)
                {
                    queue.Enqueue(neighbour);
                }
            }
        }

        return result.Count == numCourses ? result.ToArray() : [];
    }
}