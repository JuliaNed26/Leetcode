public class Solution {
    public int[] FindRedundantConnection(int[][] edges) {
        var adjList = new List<int>[edges.Length + 1];
        foreach(var edge in edges)
        {
            adjList[edge[0]] ??= new List<int>();
            adjList[edge[1]] ??= new List<int>();
            adjList[edge[0]].Add(edge[1]);
            adjList[edge[1]].Add(edge[0]);
        }

        var cycleNodes = GetCycleNodes(adjList);
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

    public HashSet<int> GetCycleNodes(List<int>[] adjList)
    {
        const int unvisitedNode = 0;
        const int pathVisitedNode = 1;
        const int visitedNode = 2;

        var visitArray = new int[adjList.Length];
        var stack = new Stack<(int parent, int node)>();
        stack.Push((0,1));
        stack.Push((0,1));
        var startCycleNode = 0;
        var pathSequence = new Stack<int>();

        while(stack.Count != 0)
        {
            var (parent, node) = stack.Pop();
            var anyNeighbours = false;
            foreach(var neighbour in adjList[node])
            {
                if(neighbour != parent && visitArray[neighbour] != visitedNode)
                {
                    anyNeighbours = true;
                    stack.Push((node, neighbour));
                    stack.Push((node, neighbour));
                }
            }

            if(anyNeighbours)
            {
                if (visitArray[node] == pathVisitedNode)
                {
                    startCycleNode = node;
                    break;
                }

                visitArray[node] = pathVisitedNode;
                pathSequence.Push(node);
            }
            else
            {
                if (pathSequence.Peek() == node)
                {
                    pathSequence.Pop();
                }

                visitArray[node] = visitedNode;
            }
        }

        var cycleNodes = new HashSet<int>();
        foreach(var pathNode in pathSequence)
        {
            cycleNodes.Add(pathNode);

            if (pathNode == startCycleNode)
            {
                break;
            }
        }

        return cycleNodes;
    }
}
