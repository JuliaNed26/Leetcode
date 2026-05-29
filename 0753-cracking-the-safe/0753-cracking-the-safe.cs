public class Solution {
    Dictionary<string, LinkedList<string>> graph;

    public string CrackSafe(int n, int k) {
        graph = [];

        if(n == 1)
        {
            var result = new StringBuilder();
            for(int i = 0; i < k; i++)
            {
                result.Append(i);
            }

            return result.ToString();
        }

        var nodesQueue = new Queue<string>();
        var startingString = new string('0', n - 1);
        nodesQueue.Enqueue(startingString);
        while(nodesQueue.Count != 0)    
        {
            var curNode = nodesQueue.Dequeue();
            graph[curNode] = new LinkedList<string>();

            var neighbourStart = curNode.Length <= 1 ? "" : curNode[1..];
            for(int i = 0; i < k; i++)
            {
                var next = neighbourStart + i;
                if(!graph.ContainsKey(next))
                {
                    nodesQueue.Enqueue(next);
                }
                graph[curNode].AddLast(next);
            }
        }

        return GetCode(startingString) + startingString;
    }

    private string GetCode(string startingNode)
    {
        var result = "";
        var stack = new Stack<(string From, string To)>();
        var fromNode = startingNode;
        do
        {
            if(graph[fromNode].Count == 0)
            {
                result += fromNode[^1];
                fromNode = stack.Pop().From;
                continue;
            }

            var toNode = graph[fromNode].First.Value;
            stack.Push((fromNode, toNode));
            graph[fromNode].RemoveFirst();
            fromNode = toNode;
        }
        while(stack.Count != 0);

        return result;
    }
}