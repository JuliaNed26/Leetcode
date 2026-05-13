public class Solution {
    private Dictionary<string, LinkedList<string>> adj = new();
    private LinkedList<string> result = new();

    public IList<string> FindItinerary(IList<IList<string>> tickets) {
        foreach (var ticket in tickets) {
            if (!adj.ContainsKey(ticket[0]))
                adj[ticket[0]] = new LinkedList<string>();
            adj[ticket[0]].AddLast(ticket[1]);
        }

        foreach (var key in adj.Keys) {
            var sorted = new LinkedList<string>(adj[key].Order());
            adj[key] = sorted;
        }

        Dfs("JFK");
        return result.ToList();
    }

    private void Dfs(string src) {
        while (adj.ContainsKey(src) && adj[src].Count > 0) {
            var next = adj[src].First.Value;
            adj[src].RemoveFirst();  // O(1) with LinkedList
            Dfs(next);
        }
        result.AddFirst(src);  // post-order: dead-end goes to end of itinerary
    }
}
