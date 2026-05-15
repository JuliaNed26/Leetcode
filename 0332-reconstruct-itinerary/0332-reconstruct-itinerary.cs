public class Solution {

    public IList<string> FindItinerary(IList<IList<string>> tickets) {
        var graph = tickets.GroupBy(t => t[0])
                            .ToDictionary(
                                g => g.Key,
                                g => new LinkedList<string>(g.Select(t => t[1]).Order())
                            );

        List<string> result = [];
        var stack = new Stack<(string Src, string Dst)>();
        var curNode = "JFK";

        while(curNode != null) 
        {
            if(!graph.TryGetValue(curNode, out var neighbours) || neighbours.Count == 0)
            {
                result.Add(curNode);
                curNode = stack.TryPop(out var path)
                            ? path.Src
                            : null;
                continue;
            }

            stack.Push((curNode, neighbours.First.Value));
            curNode = neighbours.First.Value;
            neighbours.RemoveFirst();
        }

        result.Reverse();
        return result;
    }
}